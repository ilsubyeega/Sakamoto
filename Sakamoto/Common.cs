﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sakamoto
{
	public static class Common
	{
		public static DateTime build_date = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
	}
}
