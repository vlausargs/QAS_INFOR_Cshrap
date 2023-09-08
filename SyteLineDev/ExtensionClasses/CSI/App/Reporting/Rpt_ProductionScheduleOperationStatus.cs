//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleOperationStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleOperationStatus : IRpt_ProductionScheduleOperationStatus
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionScheduleOperationStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleOperationStatusSp(string ScheduleIDStarting = null,
		string ScheduleIDEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string ScheduleIDStatus = null,
		string ScheduleReleaseStatus = null,
		int? ControlPointsOnly = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			PsNumType _ScheduleIDStarting = ScheduleIDStarting;
			PsNumType _ScheduleIDEnding = ScheduleIDEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateType _DateStarting = DateStarting;
			DateType _DateEnding = DateEnding;
			InfobarType _ScheduleIDStatus = ScheduleIDStatus;
			InfobarType _ScheduleReleaseStatus = ScheduleReleaseStatus;
			FlagNyType _ControlPointsOnly = ControlPointsOnly;
			DateOffsetType _DateStartingOffset = DateStartingOffset;
			DateOffsetType _DateEndingOffset = DateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleOperationStatusSp";
				
				appDB.AddCommandParameter(cmd, "ScheduleIDStarting", _ScheduleIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleIDEnding", _ScheduleIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleIDStatus", _ScheduleIDStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleReleaseStatus", _ScheduleReleaseStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPointsOnly", _ControlPointsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffset", _DateEndingOffset, ParameterDirection.Input);
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
