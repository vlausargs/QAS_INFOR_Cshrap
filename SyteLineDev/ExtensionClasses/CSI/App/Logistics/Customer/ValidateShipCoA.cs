//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateShipCoA : IValidateShipCoA
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateShipCoA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PShipCoActive,
		int? PShipCoLines,
		int? PShipCoReadyToProcess,
		int? PShipCoPicked,
		int? PShipCoShipped,
		int? PShipCoPacked,
		int? PShipCoInvoiced,
		decimal? PLcrAmt,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateShipCoASp(string PShipCoCoNum,
		decimal? PSubColLcrAmt,
		int? PShipCoActive,
		int? PShipCoLines,
		int? PShipCoReadyToProcess,
		int? PShipCoPicked,
		int? PShipCoShipped,
		int? PShipCoPacked,
		int? PShipCoInvoiced,
		decimal? PLcrAmt,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? RecalcOnly = 0)
		{
			CoNumType _PShipCoCoNum = PShipCoCoNum;
			AmountType _PSubColLcrAmt = PSubColLcrAmt;
			ListYesNoType _PShipCoActive = PShipCoActive;
			NumberOfLinesType _PShipCoLines = PShipCoLines;
			NumberOfLinesType _PShipCoReadyToProcess = PShipCoReadyToProcess;
			NumberOfLinesType _PShipCoPicked = PShipCoPicked;
			NumberOfLinesType _PShipCoShipped = PShipCoShipped;
			NumberOfLinesType _PShipCoPacked = PShipCoPacked;
			NumberOfLinesType _PShipCoInvoiced = PShipCoInvoiced;
			AmountType _PLcrAmt = PLcrAmt;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RecalcOnly = RecalcOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateShipCoASp";
				
				appDB.AddCommandParameter(cmd, "PShipCoCoNum", _PShipCoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSubColLcrAmt", _PSubColLcrAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipCoActive", _PShipCoActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoLines", _PShipCoLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoReadyToProcess", _PShipCoReadyToProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoPicked", _PShipCoPicked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoShipped", _PShipCoShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoPacked", _PShipCoPacked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PShipCoInvoiced", _PShipCoInvoiced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLcrAmt", _PLcrAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecalcOnly", _RecalcOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PShipCoActive = _PShipCoActive;
				PShipCoLines = _PShipCoLines;
				PShipCoReadyToProcess = _PShipCoReadyToProcess;
				PShipCoPicked = _PShipCoPicked;
				PShipCoShipped = _PShipCoShipped;
				PShipCoPacked = _PShipCoPacked;
				PShipCoInvoiced = _PShipCoInvoiced;
				PLcrAmt = _PLcrAmt;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PShipCoActive, PShipCoLines, PShipCoReadyToProcess, PShipCoPicked, PShipCoShipped, PShipCoPacked, PShipCoInvoiced, PLcrAmt, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
