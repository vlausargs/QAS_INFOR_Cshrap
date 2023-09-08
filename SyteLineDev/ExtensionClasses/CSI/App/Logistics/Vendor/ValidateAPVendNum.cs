//PROJECT NAME: Logistics
//CLASS NAME: ValidateAPVendNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAPVendNum : IValidateAPVendNum
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateAPVendNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PayHold,
		string BankCode,
		string BankName,
		string PayType,
		string CurrCode,
		string VendName,
		decimal? ExchRate,
		int? IsFixedEuro,
		string PCurrAmtFormat,
		string Infobar) ValidateAPVendNumSp(string PVendNum,
		int? PayHold,
		string BankCode,
		string BankName,
		string PayType,
		string CurrCode,
		string VendName,
		decimal? ExchRate,
		int? IsFixedEuro,
		string PCurrAmtFormat,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			ListYesNoType _PayHold = PayHold;
			BankCodeType _BankCode = BankCode;
			NameType _BankName = BankName;
			VendorPayTypeType _PayType = PayType;
			CurrCodeType _CurrCode = CurrCode;
			NameType _VendName = VendName;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _IsFixedEuro = IsFixedEuro;
			InputMaskType _PCurrAmtFormat = PCurrAmtFormat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateAPVendNumSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankName", _BankName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendName", _VendName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsFixedEuro", _IsFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrAmtFormat", _PCurrAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PayHold = _PayHold;
				BankCode = _BankCode;
				BankName = _BankName;
				PayType = _PayType;
				CurrCode = _CurrCode;
				VendName = _VendName;
				ExchRate = _ExchRate;
				IsFixedEuro = _IsFixedEuro;
				PCurrAmtFormat = _PCurrAmtFormat;
				Infobar = _Infobar;
				
				return (Severity, PayHold, BankCode, BankName, PayType, CurrCode, VendName, ExchRate, IsFixedEuro, PCurrAmtFormat, Infobar);
			}
		}
	}
}
