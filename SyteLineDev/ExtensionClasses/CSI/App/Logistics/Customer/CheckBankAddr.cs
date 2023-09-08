//PROJECT NAME: Logistics
//CLASS NAME: CheckBankAddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckBankAddr : ICheckBankAddr
	{
		readonly IApplicationDB appDB;
		
		
		public CheckBankAddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckBankAddrSp(string bankcode = null,
		string PayType = null,
		string CustBank = null,
		int? PrintDraft = null,
		string Infobar = null,
		string PSite = null)
		{
			BankCodeType _bankcode = bankcode;
			CustPayTypeType _PayType = PayType;
			BankCodeType _CustBank = CustBank;
			ListYesNoType _PrintDraft = PrintDraft;
			Infobar _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckBankAddrSp";
				
				appDB.AddCommandParameter(cmd, "bankcode", _bankcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustBank", _CustBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDraft", _PrintDraft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
