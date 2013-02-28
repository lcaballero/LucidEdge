using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;


namespace LucidEdge.DataBase.Execution
{
	public static class DatabaseExecutionExtensions
	{
		public static OutputResult ReadResult(this IDataReader data_reader)
		{
			return ReadResult(data_reader, data_reader.GetSchemaTable());
		}

		public static OutputResult ReadResult(
			this IDataReader data_reader, DataTable dt)
		{
			return
			new OutputResult
			{
				TableName = dt.TableName,

				FieldCount = data_reader.FieldCount,

				Columns =
					(0).To(data_reader.FieldCount)
						.Select(n => dt.Columns[n])
						.Select(
							col =>
							new OutputColumn
							{
								ColumnName = col.ColumnName,
								DataType = col.DataType,
								Ordinal = col.Ordinal
							})
						.ToList(),

				DataPoints =
					data_reader
						.While(
							(reader) => reader.Read(),
							(reader, row) =>
								(0).To(reader.FieldCount)
									.Select(
										i =>
										new OutputPoint
										{
											Ordinal = row,
											ColumnName = reader.GetName(i),
											DataType = reader.GetFieldType(i),
											Value = reader[i]
										})
									.ToList())
						.ToList()
			};
		}
	}
}
