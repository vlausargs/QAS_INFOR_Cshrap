//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionSchedule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionSchedule : IRpt_ProductionSchedule
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionSchedule(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleSp(string StartScheduleID = null,
		string EndScheduleID = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string SchIDStatus = "R",
		string SchRelStatus = "R",
		string BinType = "D",
		string SumOrDetail = "D",
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			PsNumType _StartScheduleID = StartScheduleID;
			PsNumType _EndScheduleID = EndScheduleID;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			GenericDateType _StartDate = StartDate;
			GenericDateType _EndDate = EndDate;
			Infobar _SchIDStatus = SchIDStatus;
			Infobar _SchRelStatus = SchRelStatus;
			Infobar _BinType = BinType;
			Infobar _SumOrDetail = SumOrDetail;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleSp";
				
				appDB.AddCommandParameter(cmd, "StartScheduleID", _StartScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndScheduleID", _EndScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchIDStatus", _SchIDStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchRelStatus", _SchRelStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BinType", _BinType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SumOrDetail", _SumOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
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
