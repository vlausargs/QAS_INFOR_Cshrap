//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleSummary : IRpt_ProductionScheduleSummary
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ProductionScheduleSummary(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ProductionScheduleSummarySp(
			string StartScheduleID = null,
			string EndScheduleID = null,
			string StartItem = null,
			string EndItem = null,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string SchIDStatus = "R",
			string SchRelStatus = "R",
			string BinType = "D",
			int? StartDateOffset = null,
			int? EndDateOffset = null)
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
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleSummarySp";
				
				appDB.AddCommandParameter(cmd, "StartScheduleID", _StartScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndScheduleID", _EndScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchIDStatus", _SchIDStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchRelStatus", _SchRelStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BinType", _BinType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
