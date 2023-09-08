//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SroEstimate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SroEstimate
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SroEstimateSp(string ExOptBegSRO_Num = null,
		string ExOptEndSRO_Num = null,
		int? ExOptBegSRO_Line = null,
		int? ExOptEndSRO_Line = null,
		int? ExOptBegSRO_Oper = null,
		int? ExOptEndSRO_Oper = null,
		string ExOptBegCust_Num = null,
		string ExOptEndCust_Num = null,
		DateTime? ExOptacEstDate = null,
		DateTime? ExOptacValidThru = null,
		int? ExOptFreightMisc = null,
		int? ExOptacCalcTax = null,
		int? ExOptacIncSroNotes = null,
		int? ExOptacIncLineNotes = null,
		int? ExOptacIncOperNotes = null,
		int? ExOptacIncCustNotes = null,
		int? ExOptacIntNotes = null,
		int? ExOptacExtNotes = null,
		int? ExOptacDisplayHeader = null,
		int? ExOptacIncTransNotes = null,
		string pSite = null);
	}
}

