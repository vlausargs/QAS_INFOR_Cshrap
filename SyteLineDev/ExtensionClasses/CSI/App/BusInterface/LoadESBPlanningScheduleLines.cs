//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPlanningScheduleLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBPlanningScheduleLines
	{
		int LoadESBPlanningScheduleLinesSp(string ActionExpression,
		                                   string CustNum,
		                                   string CoNumSeq,
		                                   string CobCoStatus,
		                                   short? CoLine,
		                                   string CoLineStatus,
		                                   string ShipmentLineID,
		                                   string BucketType,
		                                   DateTime? StartDate,
		                                   DateTime? EndDate,
		                                   decimal? ItemQuantity,
		                                   string ISOUM,
		                                   string PlanTypeCode,
		                                   string UsageType,
		                                   string PlanningRevisionID,
		                                   ref string Infobar);
	}
	
	public class LoadESBPlanningScheduleLines : ILoadESBPlanningScheduleLines
	{
		readonly IApplicationDB appDB;
		
		public LoadESBPlanningScheduleLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBPlanningScheduleLinesSp(string ActionExpression,
		                                          string CustNum,
		                                          string CoNumSeq,
		                                          string CobCoStatus,
		                                          short? CoLine,
		                                          string CoLineStatus,
		                                          string ShipmentLineID,
		                                          string BucketType,
		                                          DateTime? StartDate,
		                                          DateTime? EndDate,
		                                          decimal? ItemQuantity,
		                                          string ISOUM,
		                                          string PlanTypeCode,
		                                          string UsageType,
		                                          string PlanningRevisionID,
		                                          ref string Infobar)
		{
			StringType _ActionExpression = ActionExpression;
			StringType _CustNum = CustNum;
			StringType _CoNumSeq = CoNumSeq;
			LongStringType _CobCoStatus = CobCoStatus;
			CoLineType _CoLine = CoLine;
			LongStringType _CoLineStatus = CoLineStatus;
			ShipmentLineIDType _ShipmentLineID = ShipmentLineID;
			LongStringType _BucketType = BucketType;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			QtyUnitNoNegType _ItemQuantity = ItemQuantity;
			UMType _ISOUM = ISOUM;
			LongStringType _PlanTypeCode = PlanTypeCode;
			LongStringType _UsageType = UsageType;
			RevisionIDType _PlanningRevisionID = PlanningRevisionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPlanningScheduleLinesSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNumSeq", _CoNumSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CobCoStatus", _CobCoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLineStatus", _CoLineStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLineID", _ShipmentLineID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BucketType", _BucketType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQuantity", _ItemQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOUM", _ISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanTypeCode", _PlanTypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsageType", _UsageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanningRevisionID", _PlanningRevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
