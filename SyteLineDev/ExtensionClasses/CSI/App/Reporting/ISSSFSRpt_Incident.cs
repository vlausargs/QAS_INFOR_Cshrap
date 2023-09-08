//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_Incident.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_Incident
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IncidentSp(string ExOptBegInc_num = null,
		string ExOptEndInc_num = null,
		string ExOptBegcust_num = null,
		string ExOptENDcust_num = null,
		string ExOptBegItem = null,
		string ExOptENDItem = null,
		string ExOptBegOwner = null,
		string ExOptENDOwner = null,
		string ExOptBegUnit = null,
		string ExOptENDUnit = null,
		string ExOptBegPriorCode = null,
		string ExOptENDPriorCode = null,
		string ExOptBegStatCode = null,
		string ExOptENDStatCode = null,
		DateTime? ExOptBegInc_date = null,
		DateTime? ExOptENDInc_date = null,
		int? StartInc_dateOffSET = null,
		int? ENDInc_dateOffSET = null,
		string ExOptBegReasonGen = null,
		string ExOptENDReasonGen = null,
		string ExOptBegReasonSpec = null,
		string ExOptENDReasonSpec = null,
		string ExOptBegSSR = null,
		string ExOptENDSSR = null,
		int? ExOptIncIntNotes = 1,
		int? ExOptIncExtNotes = 1,
		int? ExOptCustIntNotes = 1,
		int? ExOptCustExtNotes = 1,
		int? ExOptEvents = 1,
		int? ExOptEventIntNotes = 1,
		int? ExOptEventExtNotes = 1,
		int? ExOptReasons = 1,
		int? ExOptReasonNotes = 1,
		int? ExOptResNotes = 1,
		string SortBy = "I",
		string IncStat = "B",
		int? DisplayHeader = null,
		string pSite = null);
	}
}

