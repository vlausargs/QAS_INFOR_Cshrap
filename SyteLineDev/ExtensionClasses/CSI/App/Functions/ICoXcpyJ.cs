//PROJECT NAME: Data
//CLASS NAME: ICoXcpyJ.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoXcpyJ
	{
		(int? ReturnCode,
			string Infobar,
			decimal? ReturnIncPrice) CoXcpyJSp(
			string FeatStr,
			string Item,
			string ItemJob,
			string CurJob,
			int? CurSuffix,
			int? ExplodePhantom = 0,
			int? CalledFromItemCreate = 0,
			string CoNum = null,
			int? CoLine = null,
			string ToType = null,
			string Infobar = null,
			decimal? HrsPerDay = 0,
			int? CalcSubJobDates = 0,
			int? CopyUetValues = 0,
			int? CalcIncPrice = 0,
			decimal? ReturnIncPrice = 0);
	}
}

