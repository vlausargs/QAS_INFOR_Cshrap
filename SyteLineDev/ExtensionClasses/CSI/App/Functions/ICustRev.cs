//PROJECT NAME: Data
//CLASS NAME: ICustRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICustRev
	{
		(int? ReturnCode,
			decimal? ActRev) CustRevSp(
			string ProjNum,
			string MsNum,
			int? CalcAct,
			decimal? ActRev);
	}
}

