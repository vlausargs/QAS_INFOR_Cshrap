//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROStatus : ISSSFSRpt_SROStatus
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROStatusSp(string ExOptBegSRO_num = null,
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
		string pSite = null)
		{
			FSSRONumType _ExOptBegSRO_num = ExOptBegSRO_num;
			FSSRONumType _ExOptENDSRO_num = ExOptENDSRO_num;
			FSSROLineType _ExOptBegSRO_Line = ExOptBegSRO_Line;
			FSSROLineType _ExOptENDSRO_Line = ExOptENDSRO_Line;
			FSSROOperType _ExOptBegSRO_Oper = ExOptBegSRO_Oper;
			FSSROOperType _ExOptENDSRO_Oper = ExOptENDSRO_Oper;
			FSPartnerType _StartLeadPartner = StartLeadPartner;
			FSPartnerType _EndLeadPartner = EndLeadPartner;
			FSPartnerType _StartBillMgr = StartBillMgr;
			FSPartnerType _EndBillMgr = EndBillMgr;
			FSSROTypeType _ExOptBegSRO_Type = ExOptBegSRO_Type;
			FSSROTypeType _ExOptENDSRO_Type = ExOptENDSRO_Type;
			FSRegionType _ExOptBegRegion = ExOptBegRegion;
			FSRegionType _ExOptENDRegion = ExOptENDRegion;
			CustNumType _ExOptBegcust_num = ExOptBegcust_num;
			CustNumType _ExOptENDcust_num = ExOptENDcust_num;
			CustPoType _ExOptBegCust_Po = ExOptBegCust_Po;
			CustPoType _ExOptENDCust_Po = ExOptENDCust_Po;
			ItemType _ExOptBegItem = ExOptBegItem;
			ItemType _ExOptENDItem = ExOptENDItem;
			InfobarType _ExOptacSROStat = ExOptacSROStat;
			InfobarType _ExOptacSROBillStat = ExOptacSROBillStat;
			InfobarType _ExOptacLineStat = ExOptacLineStat;
			InfobarType _ExOptacLineBillStat = ExOptacLineBillStat;
			InfobarType _ExOptacOperStat = ExOptacOperStat;
			InfobarType _ExOptacOperBillStat = ExOptacOperBillStat;
			DateType _ExOptBegSROOpen_date = ExOptBegSROOpen_date;
			DateType _ExOptENDSROOpen_date = ExOptENDSROOpen_date;
			DateType _ExOptBegSROStart_date = ExOptBegSROStart_date;
			DateType _ExOptENDSROStart_date = ExOptENDSROStart_date;
			DateOffsetType _StartSROOpen_dateOffSET = StartSROOpen_dateOffSET;
			DateOffsetType _ENDSROOpen_dateOffSET = ENDSROOpen_dateOffSET;
			DateOffsetType _StartSROStart_dateOffSET = StartSROStart_dateOffSET;
			DateOffsetType _ENDSROStart_dateOffSET = ENDSROStart_dateOffSET;
			UnusedCharType _SortBy = SortBy;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROStatusSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_num", _ExOptBegSRO_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSRO_num", _ExOptENDSRO_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Line", _ExOptBegSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSRO_Line", _ExOptENDSRO_Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Oper", _ExOptBegSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSRO_Oper", _ExOptENDSRO_Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLeadPartner", _StartLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLeadPartner", _EndLeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBillMgr", _StartBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBillMgr", _EndBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSRO_Type", _ExOptBegSRO_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSRO_Type", _ExOptENDSRO_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegRegion", _ExOptBegRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDRegion", _ExOptENDRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegcust_num", _ExOptBegcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDcust_num", _ExOptENDcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCust_Po", _ExOptBegCust_Po, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDCust_Po", _ExOptENDCust_Po, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegItem", _ExOptBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDItem", _ExOptENDItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacSROStat", _ExOptacSROStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacSROBillStat", _ExOptacSROBillStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacLineStat", _ExOptacLineStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacLineBillStat", _ExOptacLineBillStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacOperStat", _ExOptacOperStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacOperBillStat", _ExOptacOperBillStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSROOpen_date", _ExOptBegSROOpen_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSROOpen_date", _ExOptENDSROOpen_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegSROStart_date", _ExOptBegSROStart_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDSROStart_date", _ExOptENDSROStart_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROOpen_dateOffSET", _StartSROOpen_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDSROOpen_dateOffSET", _ENDSROOpen_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROStart_dateOffSET", _StartSROStart_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDSROStart_dateOffSET", _ENDSROStart_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
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
