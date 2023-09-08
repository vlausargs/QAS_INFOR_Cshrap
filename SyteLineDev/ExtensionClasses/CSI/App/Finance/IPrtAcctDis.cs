//PROJECT NAME: Finance
//CLASS NAME: IPrtAcctDis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPrtAcctDis
	{
		int? PrtAcctDisSp(
			string pAcct,
			decimal? pAmount,
			string pList,
			string pCurrCode,
			string pCrDbTxt,
			string pChartDescription,
			int? pDomCurrPlaces,
			int? pDetailSeq,
			DateTime? pDate,
			decimal? pForAmount);
	}
}

