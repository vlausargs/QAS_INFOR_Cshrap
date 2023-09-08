//PROJECT NAME: Data
//CLASS NAME: IPrtAcctDisForCancellation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtAcctDisForCancellation
	{
		int? PrtAcctDisForCancellationSp(
			string pAcct,
			decimal? pAmount,
			string pList,
			string pCurrCode,
			string pCrDbTxt,
			string pChartDescription,
			int? pDomCurrPlaces,
			int? pDetailSeq,
			int? pCancellation = 0,
			DateTime? pDate = null,
			decimal? pForAmount = null);
	}
}

