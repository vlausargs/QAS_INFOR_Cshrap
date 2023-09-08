//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBShipmentSchLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBShipmentSchLine
	{
		int LoadESBShipmentSchLineSp(string ActionExpression,
		                             string CoNum,
		                             string CustNum,
		                             short? CoLine,
		                             string ShipmentLineID,
		                             string DocumentReference,
		                             DateTime? CobEffDate,
		                             DateTime? CobExpDate,
		                             decimal? CoItemQuantity,
		                             string CoItemISOUM,
		                             string CoItemStatus,
		                             DateTime? CoItemStartDate,
		                             DateTime? CoItemEndDate,
		                             string CoItemShipToParty,
		                             string CoItemUsageType,
		                             string CoItemExternalPickupSheet,
		                             string ShipmentRevisionID,
		                             ref string Infobar);
	}
	
	public class LoadESBShipmentSchLine : ILoadESBShipmentSchLine
	{
		readonly IApplicationDB appDB;
		
		public LoadESBShipmentSchLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBShipmentSchLineSp(string ActionExpression,
		                                    string CoNum,
		                                    string CustNum,
		                                    short? CoLine,
		                                    string ShipmentLineID,
		                                    string DocumentReference,
		                                    DateTime? CobEffDate,
		                                    DateTime? CobExpDate,
		                                    decimal? CoItemQuantity,
		                                    string CoItemISOUM,
		                                    string CoItemStatus,
		                                    DateTime? CoItemStartDate,
		                                    DateTime? CoItemEndDate,
		                                    string CoItemShipToParty,
		                                    string CoItemUsageType,
		                                    string CoItemExternalPickupSheet,
		                                    string ShipmentRevisionID,
		                                    ref string Infobar)
		{
			StringType _ActionExpression = ActionExpression;
			StringType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			CoLineType _CoLine = CoLine;
			ShipmentLineIDType _ShipmentLineID = ShipmentLineID;
			StringType _DocumentReference = DocumentReference;
			DateTimeType _CobEffDate = CobEffDate;
			DateTimeType _CobExpDate = CobExpDate;
			QtyUnitNoNegType _CoItemQuantity = CoItemQuantity;
			UMType _CoItemISOUM = CoItemISOUM;
			LongStringType _CoItemStatus = CoItemStatus;
			DateTimeType _CoItemStartDate = CoItemStartDate;
			DateTimeType _CoItemEndDate = CoItemEndDate;
			StringType _CoItemShipToParty = CoItemShipToParty;
			LongStringType _CoItemUsageType = CoItemUsageType;
			ExternalPickUpSheetIDType _CoItemExternalPickupSheet = CoItemExternalPickupSheet;
			RevisionIDType _ShipmentRevisionID = ShipmentRevisionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBShipmentSchLineSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLineID", _ShipmentLineID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentReference", _DocumentReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CobEffDate", _CobEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CobExpDate", _CobExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemQuantity", _CoItemQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemISOUM", _CoItemISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemStatus", _CoItemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemStartDate", _CoItemStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemEndDate", _CoItemEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemShipToParty", _CoItemShipToParty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemUsageType", _CoItemUsageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemExternalPickupSheet", _CoItemExternalPickupSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentRevisionID", _ShipmentRevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
