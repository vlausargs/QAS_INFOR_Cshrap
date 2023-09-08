//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROStatusSp(string ExOptBegSRO_num = null,
		string ExOptENDSRO_num = null,
		int? ExOptBegSRO_Line = null,
		int? ExOptENDSRO_Line = null,
		int? ExOptBegSRO_Oper = null,
		int? ExOptENDSRO_Oper = null,
		string StartLeadPartner = null,
		string EndLeadPartner = null,
		string StartBillMgr = null,
		string EndBillMgr = null,
		string ExOptBegSRO_Type = null,
		string ExOptENDSRO_Type = null,
		string ExOptBegRegion = null,
		string ExOptENDRegion = null,
		string ExOptBegcust_num = null,
		string ExOptENDcust_num = null,
		string ExOptBegCust_Po = null,
		string ExOptENDCust_Po = null,
		string ExOptBegItem = null,
		string ExOptENDItem = null,
		string ExOptacSROStat = null,
		string ExOptacSROBillStat = null,
		string ExOptacLineStat = null,
		string ExOptacLineBillStat = null,
		string ExOptacOperStat = null,
		string ExOptacOperBillStat = null,
		DateTime? ExOptBegSROOpen_date = null,
		DateTime? ExOptENDSROOpen_date = null,
		DateTime? ExOptBegSROStart_date = null,
		DateTime? ExOptENDSROStart_date = null,
		int? StartSROOpen_dateOffSET = null,
		int? ENDSROOpen_dateOffSET = null,
		int? StartSROStart_dateOffSET = null,
		int? ENDSROStart_dateOffSET = null,
		string SortBy = "O",
		string pSite = null);
	}
}

