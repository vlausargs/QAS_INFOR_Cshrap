//PROJECT NAME: Codes
//CLASS NAME: GetPrBankCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetPrBankCode : IGetPrBankCode
	{
		readonly IApplicationDB appDB;
		
		
		public GetPrBankCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BankCode,
		string Infobar) GetPrBankCodeSp(string BankCode,
		string Infobar)
		{
			BankCodeType _BankCode = BankCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPrBankCodeSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BankCode = _BankCode;
				Infobar = _Infobar;
				
				return (Severity, BankCode, Infobar);
			}
		}
	}
}
