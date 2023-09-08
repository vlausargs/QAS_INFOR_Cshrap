//PROJECT NAME: Data
//CLASS NAME: THAGetWhtInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAGetWhtInfo : ITHAGetWhtInfo
	{
		readonly IApplicationDB appDB;
		
		public THAGetWhtInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Whttaxtype,
			string TaxRegNum,
			string CompName,
			string Prop1,
			string Prop2,
			string Prop3) THAGetWhtInfoSp(
			string VendNum = null,
			int? Voucher = null,
			string Whttaxtype = null,
			string TaxRegNum = null,
			string CompName = null,
			string Prop1 = null,
			string Prop2 = null,
			string Prop3 = null,
			string BankCode = null)
		{
			VendNumType _VendNum = VendNum;
			VoucherType _Voucher = Voucher;
			StringType _Whttaxtype = Whttaxtype;
			TaxRegNumType _TaxRegNum = TaxRegNum;
			NameType _CompName = CompName;
			AddressType _Prop1 = Prop1;
			AddressType _Prop2 = Prop2;
			AddressType _Prop3 = Prop3;
			BankCodeType _BankCode = BankCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetWhtInfoSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whttaxtype", _Whttaxtype, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxRegNum", _TaxRegNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CompName", _CompName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prop1", _Prop1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prop2", _Prop2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prop3", _Prop3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Whttaxtype = _Whttaxtype;
				TaxRegNum = _TaxRegNum;
				CompName = _CompName;
				Prop1 = _Prop1;
				Prop2 = _Prop2;
				Prop3 = _Prop3;
				
				return (Severity, Whttaxtype, TaxRegNum, CompName, Prop1, Prop2, Prop3);
			}
		}
	}
}
