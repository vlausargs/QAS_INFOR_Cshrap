//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleRouting : IRpt_ProductionScheduleRouting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionScheduleRouting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleRoutingSp(string StartScheduleID = null,
		string EndScheduleID = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		string ScheduleIDStat = null,
		string ScheduleReleaseStat = null,
		int? PrintBarcodeFmt = null,
		string BarcodeWhichOper = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? JobRouteNotes = null,
		int? JobMatlNotes = null,
		int? IncludePSRel = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			PsNumType _StartScheduleID = StartScheduleID;
			PsNumType _EndScheduleID = EndScheduleID;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			DateType _StartDueDate = StartDueDate;
			DateType _EndDueDate = EndDueDate;
			Infobar _ScheduleIDStat = ScheduleIDStat;
			Infobar _ScheduleReleaseStat = ScheduleReleaseStat;
			ListYesNoType _PrintBarcodeFmt = PrintBarcodeFmt;
			Infobar _BarcodeWhichOper = BarcodeWhichOper;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _JobRouteNotes = JobRouteNotes;
			ListYesNoType _JobMatlNotes = JobMatlNotes;
			ListYesNoType _IncludePSRel = IncludePSRel;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleRoutingSp";
				
				appDB.AddCommandParameter(cmd, "StartScheduleID", _StartScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndScheduleID", _EndScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleIDStat", _ScheduleIDStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleReleaseStat", _ScheduleReleaseStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBarcodeFmt", _PrintBarcodeFmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BarcodeWhichOper", _BarcodeWhichOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRouteNotes", _JobRouteNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlNotes", _JobMatlNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludePSRel", _IncludePSRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
