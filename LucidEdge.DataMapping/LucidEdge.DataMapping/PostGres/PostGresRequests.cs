﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using NpgsqlTypes;


namespace LucidEdge.DataMapping.PostGres
{
	public static partial class Requests
	{
		public static Lazy<Func<NpgsqlConnection>> DefaultConnection =
			new Lazy<Func<NpgsqlConnection>>(
				() => (() => OpenConnection()));

		public static int Insert(
			this string sql,
			IEnumerable<IDataPoint> inputs,
			NpgsqlCommand cmd = null)
		{
			return
			(cmd ?? Requests.DefaultConnection.Value().CreateCommand())
				.With(sql)
				.With(inputs)
				.ExecuteNonQuery();
		}

		public static IEnumerable<T> Read<T>(
			this string sql,
			IEnumerable<IDataPoint> parameters = null,
			NpgsqlCommand cmd = null)
				where T : IDataMapping, new()
		{
			return
			(cmd ?? Requests.DefaultConnection.Value().CreateCommand())
				.With(sql)
				.With(parameters ?? new List<IDataPoint>())
				.ExecuteReader()
				.ReadResult()				// TODO: make this async
				.Rows
				.Select(
					pts =>
					new T
					{
						Map = pts.ToDictionary(
							p => p.ColumnName,
							p => p,
							StringComparer.InvariantCultureIgnoreCase)
					});
		}

		public static int Create(this string sql, NpgsqlCommand cmd = null)
		{
			return
			(cmd ?? Requests.DefaultConnection.Value().CreateCommand())
				.With(sql)
				.ExecuteNonQuery();
		}

		public static int DropTable(this string sql, NpgsqlCommand cmd = null)
		{
			return
			(cmd ?? Requests.DefaultConnection.Value().CreateCommand())
				.With(sql)
				.ExecuteNonQuery();
		}

		private static NpgsqlConnection OpenConnection()
		{
			NpgsqlConnection conn = new NpgsqlConnection();

			conn.ConnectionString = new PostGresConnection().ToString();
			conn.Open();

			return conn;
		}

		public static OutputResult ToResult(this string cmdtext)
		{
			using (NpgsqlConnection conn = OpenConnection())
			{
				NpgsqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = cmdtext;

				NpgsqlDataReader reader = cmd.ExecuteReader();

				return reader.ReadResult();
			}
		}

		public static NpgsqlCommand With(this NpgsqlCommand cmd, IEnumerable<IDataPoint> dps)
		{
			dps.ToList().ForEach(dp => cmd.Parameters.AddWithValue(dp.ColumnName, dp.Value));
			return cmd;
		}

		public static NpgsqlCommand With(this NpgsqlCommand cmd, string text)
		{
			cmd.CommandText = text;
			return cmd;
		}
	}
}
