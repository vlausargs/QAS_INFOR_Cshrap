//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetUptmpser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetUptmpser
	{
		(int? ReturnCode, int? SerialTracked,
		string Infobar) RSQC_SetUptmpserSp(string RefType,
		string RefNum,
		int? RefLine,
		int? RefRelease,
		int? OperNum,
		int? TestSeq,
		string MrrNum,
		int? RcvrNum,
		string Item,
		string Entity,
		int? SerialTracked,
		string Infobar);
	}
}

