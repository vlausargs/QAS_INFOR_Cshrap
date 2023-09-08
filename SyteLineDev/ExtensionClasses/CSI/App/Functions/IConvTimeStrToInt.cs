//PROJECT NAME: Data
//CLASS NAME: IConvTimeStrToInt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvTimeStrToInt
	{
		int? ConvTimeStrToIntFn(
			string TimeStr);
	}
}

