//PROJECT NAME: CSIVendor
//CLASS NAME: EvaluateAutoVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IEvaluateAutoVoucher
	{
		(int? ReturnCode, decimal? MaterialAmount, byte? FixedRate, string CurrCode, decimal? ExchangeRate, byte? IncludeTaxInCost, string AutoVoucherMethod, byte? AutoVoucher, Guid? PProcessID, string TermsCode, short? CanAutoGenerateVoucher, string Infobar) EvaluateAutoVoucherSp(decimal? MaterialAmount,
		byte? FixedRate,
		string CurrCode,
		decimal? ExchangeRate,
		byte? IncludeTaxInCost,
		string AutoVoucherMethod,
		byte? AutoVoucher,
		Guid? PProcessID,
		string TermsCode,
		short? CanAutoGenerateVoucher,
		string Infobar,
		DateTime? TransDate = null);
	}
	
	public class EvaluateAutoVoucher : IEvaluateAutoVoucher
	{
		readonly IApplicationDB appDB;
		
		public EvaluateAutoVoucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? MaterialAmount, byte? FixedRate, string CurrCode, decimal? ExchangeRate, byte? IncludeTaxInCost, string AutoVoucherMethod, byte? AutoVoucher, Guid? PProcessID, string TermsCode, short? CanAutoGenerateVoucher, string Infobar) EvaluateAutoVoucherSp(decimal? MaterialAmount,
		byte? FixedRate,
		string CurrCode,
		decimal? ExchangeRate,
		byte? IncludeTaxInCost,
		string AutoVoucherMethod,
		byte? AutoVoucher,
		Guid? PProcessID,
		string TermsCode,
		short? CanAutoGenerateVoucher,
		string Infobar,
		DateTime? TransDate = null)
		{
			AmountType _MaterialAmount = MaterialAmount;
			ListYesNoType _FixedRate = FixedRate;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchangeRate = ExchangeRate;
			ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
			AutoVoucherMethodType _AutoVoucherMethod = AutoVoucherMethod;
			ListYesNoType _AutoVoucher = AutoVoucher;
			RowPointerType _PProcessID = PProcessID;
			TermsCodeType _TermsCode = TermsCode;
			PrivilegeType _CanAutoGenerateVoucher = CanAutoGenerateVoucher;
			InfobarType _Infobar = Infobar;
			DateType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EvaluateAutoVoucherSp";
				
				appDB.AddCommandParameter(cmd, "MaterialAmount", _MaterialAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedRate", _FixedRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchangeRate", _ExchangeRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoVoucherMethod", _AutoVoucherMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoVoucher", _AutoVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAutoGenerateVoucher", _CanAutoGenerateVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaterialAmount = _MaterialAmount;
				FixedRate = _FixedRate;
				CurrCode = _CurrCode;
				ExchangeRate = _ExchangeRate;
				IncludeTaxInCost = _IncludeTaxInCost;
				AutoVoucherMethod = _AutoVoucherMethod;
				AutoVoucher = _AutoVoucher;
				PProcessID = _PProcessID;
				TermsCode = _TermsCode;
				CanAutoGenerateVoucher = _CanAutoGenerateVoucher;
				Infobar = _Infobar;
				
				return (Severity, MaterialAmount, FixedRate, CurrCode, ExchangeRate, IncludeTaxInCost, AutoVoucherMethod, AutoVoucher, PProcessID, TermsCode, CanAutoGenerateVoucher, Infobar);
			}
		}
	}
}
