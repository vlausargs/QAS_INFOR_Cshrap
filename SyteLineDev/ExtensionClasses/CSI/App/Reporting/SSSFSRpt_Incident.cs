//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_Incident.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_Incident : ISSSFSRpt_Incident
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_Incident(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IncidentSp(string ExOptBegInc_num = null,
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
		string pSite = null)
		{
			FSIncNumType _ExOptBegInc_num = ExOptBegInc_num;
			FSIncNumType _ExOptEndInc_num = ExOptEndInc_num;
			CustNumType _ExOptBegcust_num = ExOptBegcust_num;
			CustNumType _ExOptENDcust_num = ExOptENDcust_num;
			ItemType _ExOptBegItem = ExOptBegItem;
			ItemType _ExOptENDItem = ExOptENDItem;
			FSPartnerType _ExOptBegOwner = ExOptBegOwner;
			FSPartnerType _ExOptENDOwner = ExOptENDOwner;
			SerNumType _ExOptBegUnit = ExOptBegUnit;
			SerNumType _ExOptENDUnit = ExOptENDUnit;
			FSIncPriorCodeType _ExOptBegPriorCode = ExOptBegPriorCode;
			FSIncPriorCodeType _ExOptENDPriorCode = ExOptENDPriorCode;
			FSStatCodeType _ExOptBegStatCode = ExOptBegStatCode;
			FSStatCodeType _ExOptENDStatCode = ExOptENDStatCode;
			DateType _ExOptBegInc_date = ExOptBegInc_date;
			DateType _ExOptENDInc_date = ExOptENDInc_date;
			DateOffsetType _StartInc_dateOffSET = StartInc_dateOffSET;
			DateOffsetType _ENDInc_dateOffSET = ENDInc_dateOffSET;
			FSReasonType _ExOptBegReasonGen = ExOptBegReasonGen;
			FSReasonType _ExOptENDReasonGen = ExOptENDReasonGen;
			FSReasonType _ExOptBegReasonSpec = ExOptBegReasonSpec;
			FSReasonType _ExOptENDReasonSpec = ExOptENDReasonSpec;
			FSPartnerType _ExOptBegSSR = ExOptBegSSR;
			FSPartnerType _ExOptENDSSR = ExOptENDSSR;
			ListYesNoType _ExOptIncIntNotes = ExOptIncIntNotes;
			ListYesNoType _ExOptIncExtNotes = ExOptIncExtNotes;
			ListYesNoType _ExOptCustIntNotes = ExOptCustIntNotes;
			ListYesNoType _ExOptCustExtNotes = ExOptCustExtNotes;
			ListYesNoType _ExOptEvents = ExOptEvents;
			ListYesNoType _ExOptEventIntNotes = ExOptEventIntNotes;
			ListYesNoType _ExOptEventExtNotes = ExOptEventExtNotes;
			ListYesNoType _ExOptReasons = ExOptReasons;
			ListYesNoType _ExOptReasonNotes = ExOptReasonNotes;
			ListYesNoType _ExOptResNotes = ExOptResNotes;
			UnusedCharType _SortBy = SortBy;
			UnusedCharType _IncStat = IncStat;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_IncidentSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegInc_num", _ExOptBegInc_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndInc_num", _ExOptEndInc_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegcust_num", _ExOptBegcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDcust_num", _ExOptENDcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegItem", _ExOptBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDItem", _ExOptENDItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegOwner", _ExOptBegOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDOwner", _ExOptENDOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegUnit", _ExOptBegUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDUnit", _ExOptENDUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegPriorCode", _ExOptBegPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDPriorCode", _ExOptENDPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegStatCode", _ExOptBegStatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDStatCode", _ExOptENDStatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegInc_date", _ExOptBegInc_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDInc_date", _ExOptENDInc_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInc_dateOffSET", _StartInc_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDInc_dateOffSET", _ENDInc_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegReasonGen", _ExOptBegReasonGen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDReasonGen", _ExOptENDReasonGen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegReasonSpec", _ExOptBegReasonSpec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDReasonSpec", _ExOptENDReasonSpec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSSR", _ExOptBegSSR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSSR", _ExOptENDSSR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptIncIntNotes", _ExOptIncIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptIncExtNotes", _ExOptIncExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCustIntNotes", _ExOptCustIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCustExtNotes", _ExOptCustExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEvents", _ExOptEvents, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEventIntNotes", _ExOptEventIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEventExtNotes", _ExOptEventExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptReasons", _ExOptReasons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptReasonNotes", _ExOptReasonNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptResNotes", _ExOptResNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncStat", _IncStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
