//PROJECT NAME: Production
//CLASS NAME: ICheckMatlCBPct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckMatlCBPct
	{
		(int? ReturnCode, string Infobar) CheckMatlCBPctSp(string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string Infobar = null);
	}
}

