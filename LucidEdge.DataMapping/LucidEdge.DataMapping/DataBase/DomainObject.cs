﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LucidEdge.DataMapping
{
	public class DomainObject : IDataMapping
	{
		public IDictionary<string,IDataPoint> Map { get; set; }
	}
}
