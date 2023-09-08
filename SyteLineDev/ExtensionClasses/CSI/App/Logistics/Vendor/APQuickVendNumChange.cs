//PROJECT NAME: CSIVendor
//CLASS NAME: APQuickVendNumChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAPQuickVendNumChange
	{
		(int? ReturnCode, string pBankCurr, short? PCheckSeq, byte? Fixed, byte? PayHold, string BankCode, string BankName, string PayType, string CurrCode, string VendName, decimal? ExchRate, byte? IsFixedEuro, string PCurrAmtFormat, string Infobar) APQuickVendNumChangeSp(string pBankCode,
		string Site = null,
		string PVendNum = null,
		string pBankCurr = null,
		short? PCheckSeq = null,
		byte? Fixed = null,
		byte? PayHold = null,
		string BankCode = null,
		string BankName = null,
		string PayType = null,
		string CurrCode = null,
		string VendName = null,
		decimal? ExchRate = null,
		byte? IsFixedEuro = null,
		string PCurrAmtFormat = null,
		string Infobar = null);
	}
	
	public class APQuickVendNumChange : IAPQuickVendNumChange
	{
		readonly IApplicationDB appDB;
		
		public APQuickVendNumChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pBankCurr, short? PCheckSeq, byte? Fixed, byte? PayHold, string BankCode, string BankName, string PayType, string CurrCode, string VendName, decimal? ExchRate, byte? IsFixedEuro, string PCurrAmtFormat, string Infobar) APQuickVendNumChangeSp(string pBankCode,
		string Site = null,
		string PVendNum = null,
		string pBankCurr = null,
		short? PCheckSeq = null,
		byte? Fixed = null,
		byte? PayHold = null,
		string BankCode = null,
		string BankName = null,
		string PayType = null,
		string CurrCode = null,
		string VendName = null,
		decimal? ExchRate = null,
		byte? IsFixedEuro =null,
		string PCurrAmtFormat = null,
		string Infobar = null)
		{
			BankCodeType _pBankCode = pBankCode;
			SiteType _Site = Site;
			VendNumType _PVendNum = PVendNum;
			CurrCodeType _pBankCurr = pBankCurr;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			Flag _Fixed = Fixed;
			ListYesNoType _PayHold = PayHold;
			BankCodeType _BankCode = BankCode;
			NameType _BankName = BankName;
			VendorPayTypeType _PayType = PayType;
			CurrCodeType _CurrCode = CurrCode;
			NameType _VendName = VendName;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _IsFixedEuro = IsFixedEuro;
			InputMaskType _PCurrAmtFormat = PCurrAmtFormat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APQuickVendNumChangeSp";
				
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCurr", _pBankCurr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Fixed", _Fixed, ParameterDirection.InputOutput);
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
				
				pBankCurr = _pBankCurr;
				PCheckSeq = _PCheckSeq;
				Fixed = _Fixed;
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
				
				return (Severity, pBankCurr, PCheckSeq, Fixed, PayHold, BankCode, BankName, PayType, CurrCode, VendName, ExchRate, IsFixedEuro, PCurrAmtFormat, Infobar);
			}
		}
	}
}
