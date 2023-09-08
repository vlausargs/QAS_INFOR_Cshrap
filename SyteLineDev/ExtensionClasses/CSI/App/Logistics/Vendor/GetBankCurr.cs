//PROJECT NAME: Logistics
//CLASS NAME: GetBankCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetBankCurr : IGetBankCurr
	{
		readonly IApplicationDB appDB;
		
		
		public GetBankCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pBankCurr,
		string Infobar) GetBankCurrSp(string pBankCode,
		string pBankCurr,
		string Infobar)
		{
			BankCodeType _pBankCode = pBankCode;
			CurrCodeType _pBankCurr = pBankCurr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetBankCurrSp";
				
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCurr", _pBankCurr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pBankCurr = _pBankCurr;
				Infobar = _Infobar;
				
				return (Severity, pBankCurr, Infobar);
			}
		}
	}
}
