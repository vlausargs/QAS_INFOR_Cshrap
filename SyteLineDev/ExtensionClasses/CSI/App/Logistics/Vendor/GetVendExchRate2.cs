//PROJECT NAME: Logistics
//CLASS NAME: GetVendExchRate2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVendExchRate2 : IGetVendExchRate2
	{
		readonly IApplicationDB appDB;
		
		
		public GetVendExchRate2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
		string Infobar) GetVendExchRate2Sp(string PaymentBankCode,
		string VendNum,
		DateTime? CheckDate,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 1)
		{
			BankCodeType _PaymentBankCode = PaymentBankCode;
			VendNumType _VendNum = VendNum;
			DateType _CheckDate = CheckDate;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			IntType _UseBuyRate = UseBuyRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendExchRate2Sp";
				
				appDB.AddCommandParameter(cmd, "PaymentBankCode", _PaymentBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}
	}
}
