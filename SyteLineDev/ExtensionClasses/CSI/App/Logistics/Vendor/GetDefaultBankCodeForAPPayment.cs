//PROJECT NAME: CSIVendor
//CLASS NAME: GetDefaultBankCodeForAPPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetDefaultBankCodeForAPPayment
	{
		(int? ReturnCode, string BankCode) GetDefaultBankCodeForAPPaymentSp(string BankCode,
		string PayType = null);
	}
	
	public class GetDefaultBankCodeForAPPayment : IGetDefaultBankCodeForAPPayment
	{
		readonly IApplicationDB appDB;
		
		public GetDefaultBankCodeForAPPayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BankCode) GetDefaultBankCodeForAPPaymentSp(string BankCode,
		string PayType = null)
		{
			BankCodeType _BankCode = BankCode;
			StringType _PayType = PayType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDefaultBankCodeForAPPaymentSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BankCode = _BankCode;
				
				return (Severity, BankCode);
			}
		}
	}
}
