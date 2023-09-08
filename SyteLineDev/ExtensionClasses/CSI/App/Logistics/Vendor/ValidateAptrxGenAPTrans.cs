//PROJECT NAME: Logistics
//CLASS NAME: ValidateAptrxGenAPTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAptrxGenAPTrans : IValidateAptrxGenAPTrans
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateAptrxGenAPTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateAptrxGenAPTransSp(decimal? PMatlCost,
		string PVendCurrCode,
		string PVchAdj,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			AmountType _PMatlCost = PMatlCost;
			CurrCodeType _PVendCurrCode = PVendCurrCode;
			VchPrStatusType _PVchAdj = PVchAdj;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateAptrxGenAPTransSp";
				
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendCurrCode", _PVendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVchAdj", _PVchAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
