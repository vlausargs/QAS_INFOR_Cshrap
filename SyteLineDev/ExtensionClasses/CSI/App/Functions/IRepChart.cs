//PROJECT NAME: Data
//CLASS NAME: IRepChart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepChart
	{
		(int? ReturnCode,
			string Infobar) RepChartSp(
			string pDestSite,
			string pAcct,
			int? pOverwriteExistingRecords = 0,
			int? pCopyReportsToAcct = 0,
			int? pCopyNotes = 0,
			string pDescription = null,
			string pType = null,
			DateTime? pEffDate = null,
			DateTime? pObsDate = null,
			string pAccessUnit1 = null,
			string pAccessUnit2 = null,
			string pAccessUnit3 = null,
			string pAccessUnit4 = null,
			string pTransMethod = null,
			int? pUseBuyRate = null,
			string pReportsToAcct = null,
			string pAcctClass = null,
			string Infobar = null,
			int? pIsControl = 0);
	}
}

