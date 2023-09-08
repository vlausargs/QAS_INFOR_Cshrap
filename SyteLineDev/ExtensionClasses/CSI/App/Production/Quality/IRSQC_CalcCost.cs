//PROJECT NAME: Production
//CLASS NAME: IRSQC_CalcCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CalcCost
	{
		int? RSQC_CalcCostSp(
			string i_DocNum,
			string i_DocType);
	}
}

