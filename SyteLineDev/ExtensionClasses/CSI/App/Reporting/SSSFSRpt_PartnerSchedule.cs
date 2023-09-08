//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_PartnerSchedule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_PartnerSchedule : ISSSFSRpt_PartnerSchedule
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_PartnerSchedule(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_PartnerScheduleSp(string BeginSRONum = null,
		string EndSRONum = null,
		DateTime? BeginSchedDate = null,
		DateTime? EndSchedDate = null,
		string BeginPartnerID = null,
		string EndPartnerID = null,
		string BeginIncident = null,
		string EndIncident = null,
		int? ScheduleDetailYN = null,
		int? CustomerDetailYN = null,
		int? ScheduleTextYN = null,
		int? PageBreak = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? MiscRef = 1,
		int? SRORef = 1,
		int? IncRef = 1,
		string OrderBy = "P",
		string pSite = null)
		{
			FSSRONumType _BeginSRONum = BeginSRONum;
			FSSRONumType _EndSRONum = EndSRONum;
			DateType _BeginSchedDate = BeginSchedDate;
			DateType _EndSchedDate = EndSchedDate;
			FSPartnerType _BeginPartnerID = BeginPartnerID;
			FSPartnerType _EndPartnerID = EndPartnerID;
			FSIncNumType _BeginIncident = BeginIncident;
			FSIncNumType _EndIncident = EndIncident;
			ListYesNoType _ScheduleDetailYN = ScheduleDetailYN;
			ListYesNoType _CustomerDetailYN = CustomerDetailYN;
			ListYesNoType _ScheduleTextYN = ScheduleTextYN;
			ListYesNoType _PageBreak = PageBreak;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _MiscRef = MiscRef;
			ListYesNoType _SRORef = SRORef;
			ListYesNoType _IncRef = IncRef;
			StringType _OrderBy = OrderBy;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_PartnerScheduleSp";
				
				appDB.AddCommandParameter(cmd, "BeginSRONum", _BeginSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSRONum", _EndSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginSchedDate", _BeginSchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSchedDate", _EndSchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginPartnerID", _BeginPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPartnerID", _EndPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginIncident", _BeginIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndIncident", _EndIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDetailYN", _ScheduleDetailYN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerDetailYN", _CustomerDetailYN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleTextYN", _ScheduleTextYN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBreak", _PageBreak, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscRef", _MiscRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRORef", _SRORef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncRef", _IncRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
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
