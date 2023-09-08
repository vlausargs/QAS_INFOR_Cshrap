//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateShipCoLcr : IValidateShipCoLcr
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateShipCoLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateShipCoLcrSp(string PShipCoCoNum,
		int? PErrorOnly,
		int? PLcrOkFlag,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? PBatchId)
		{
			CoNumType _PShipCoCoNum = PShipCoCoNum;
			ListYesNoType _PErrorOnly = PErrorOnly;
			ListYesNoType _PLcrOkFlag = PLcrOkFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			BatchIdType _PBatchId = PBatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateShipCoLcrSp";
				
				appDB.AddCommandParameter(cmd, "PShipCoCoNum", _PShipCoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PErrorOnly", _PErrorOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLcrOkFlag", _PLcrOkFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
