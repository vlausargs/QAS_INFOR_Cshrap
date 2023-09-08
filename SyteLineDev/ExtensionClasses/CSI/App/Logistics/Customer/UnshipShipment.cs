//PROJECT NAME: Logistics
//CLASS NAME: UnshipShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnshipShipment : IUnshipShipment
	{
		readonly IApplicationDB appDB;
		
		
		public UnshipShipment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FirstSequenceWithError,
		int? RecordsPosted,
		string PromptMsg,
		string PromptButtons,
		string InfoBar) UnshipShipmentSp(decimal? ShipmentId,
		string Whse,
		int? IgnoreLCR,
		int? IgnoreCount,
		int? ChangeStatus,
		int? Return2Stock,
		DateTime? TransDate,
		int? FirstSequenceWithError,
		int? RecordsPosted,
		string PromptMsg = null,
		string PromptButtons = null,
		string InfoBar = null)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			WhseType _Whse = Whse;
			ListYesNoType _IgnoreLCR = IgnoreLCR;
			ListYesNoType _IgnoreCount = IgnoreCount;
			ListYesNoType _ChangeStatus = ChangeStatus;
			ListYesNoType _Return2Stock = Return2Stock;
			DateTimeType _TransDate = TransDate;
			IntType _FirstSequenceWithError = FirstSequenceWithError;
			IntType _RecordsPosted = RecordsPosted;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnshipShipmentSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreLCR", _IgnoreLCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreCount", _IgnoreCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChangeStatus", _ChangeStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return2Stock", _Return2Stock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstSequenceWithError", _FirstSequenceWithError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordsPosted", _RecordsPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSequenceWithError = _FirstSequenceWithError;
				RecordsPosted = _RecordsPosted;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				InfoBar = _InfoBar;
				
				return (Severity, FirstSequenceWithError, RecordsPosted, PromptMsg, PromptButtons, InfoBar);
			}
		}
	}
}
