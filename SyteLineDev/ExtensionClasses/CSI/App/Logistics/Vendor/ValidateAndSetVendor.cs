//PROJECT NAME: Logistics
//CLASS NAME: ValidateAndSetVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAndSetVendor : IValidateAndSetVendor
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateAndSetVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons,
		string VendPriceBy,
		decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar) ValidateAndSetVendorSp(string PVendNum,
		string POldVendNum,
		string PItem,
		string PReqNum,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		decimal? InPoQty,
		DateTime? EffectiveDate,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons,
		string VendPriceBy,
		decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			VendNumType _POldVendNum = POldVendNum;
			ItemType _PItem = PItem;
			ReqNumType _PReqNum = PReqNum;
			UMType _PUM = PUM;
			DateType _PDueDate = PDueDate;
			RefTypeIJKOTType _PRefType = PRefType;
			QtyTotlNoNegType _InPoQty = InPoQty;
			DateType _EffectiveDate = EffectiveDate;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			CostPrcType _PPlanCostConv = PPlanCostConv;
			CurrCodeType _PVendCurrCode = PVendCurrCode;
			UMType _PNewUM = PNewUM;
			DateType _PNewDte = PNewDte;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			ListOrderDueType _VendPriceBy = VendPriceBy;
			CostPrcType _TcCprMatCostConv = TcCprMatCostConv;
			CostPrcType _TcCprBrokerageCostConv = TcCprBrokerageCostConv;
			CostPrcType _TcCprDutyCostConv = TcCprDutyCostConv;
			CostPrcType _TcCprFreightCostConv = TcCprFreightCostConv;
			CostPrcType _TcCprInsuranceCostConv = TcCprInsuranceCostConv;
			CostPrcType _TcCprLocFrtCostConv = TcCprLocFrtCostConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateAndSetVendorSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldVendNum", _POldVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InPoQty", _InPoQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPlanCostConv", _PPlanCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendCurrCode", _PVendCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNewDte", _PNewDte, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendPriceBy", _VendPriceBy, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprMatCostConv", _TcCprMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprBrokerageCostConv", _TcCprBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprDutyCostConv", _TcCprDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprFreightCostConv", _TcCprFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprInsuranceCostConv", _TcCprInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprLocFrtCostConv", _TcCprLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAcct = _PAcct;
				PAcctUnit1 = _PAcctUnit1;
				PAcctUnit2 = _PAcctUnit2;
				PAcctUnit3 = _PAcctUnit3;
				PAcctUnit4 = _PAcctUnit4;
				PPlanCostConv = _PPlanCostConv;
				PVendCurrCode = _PVendCurrCode;
				PNewUM = _PNewUM;
				PNewDte = _PNewDte;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				VendPriceBy = _VendPriceBy;
				TcCprMatCostConv = _TcCprMatCostConv;
				TcCprBrokerageCostConv = _TcCprBrokerageCostConv;
				TcCprDutyCostConv = _TcCprDutyCostConv;
				TcCprFreightCostConv = _TcCprFreightCostConv;
				TcCprInsuranceCostConv = _TcCprInsuranceCostConv;
				TcCprLocFrtCostConv = _TcCprLocFrtCostConv;
				Infobar = _Infobar;
				
				return (Severity, PAcct, PAcctUnit1, PAcctUnit2, PAcctUnit3, PAcctUnit4, PPlanCostConv, PVendCurrCode, PNewUM, PNewDte, PromptMsg, PromptButtons, VendPriceBy, TcCprMatCostConv, TcCprBrokerageCostConv, TcCprDutyCostConv, TcCprFreightCostConv, TcCprInsuranceCostConv, TcCprLocFrtCostConv, Infobar);
			}
		}
	}
}
