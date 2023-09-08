//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROPicklist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROPicklist
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPicklistSp(string ExOptBegSRO_Num = null,
		string ExOptEndSRO_Num = null,
		int? ExOptBegSRO_Line = null,
		int? ExOptEndSRO_Line = null,
		int? ExOptBegSRO_Oper = null,
		int? ExOptEndSRO_Oper = null,
		string ExOptBegSRO_Type = null,
		string ExOptEndSRO_Type = null,
		string ExOptacSROStat = null,
		string ExOptacLineStat = null,
		string ExOptacOperStat = null,
		string ExOptacWhse = null,
		string ExOptacTransWhse = null,
		int? ExOptacInclPosted = null,
		int? ExOptacBarcode = null,
		int? ExOptacShowAddr = null,
		int? ExOptacShowAllLoc = null,
		int? ExOptacShowSerials = null,
		int? ExOptacIncSroNotes = null,
		int? ExOptacIncLineNotes = null,
		int? ExOptacIncOperNotes = null,
		int? ExOptacIncCustNotes = null,
		int? ExOptacIntNotes = null,
		int? ExOptacExtNotes = null,
		int? DisplayHeader = null,
		string OrderBy = "I",
		string pSite = null);
	}
}

