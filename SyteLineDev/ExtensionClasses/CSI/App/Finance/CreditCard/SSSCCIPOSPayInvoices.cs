//PROJECT NAME: Finance
//CLASS NAME: SSSCCIPOSPayInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIPOSPayInvoices : ISSSCCIPOSPayInvoices
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIPOSPayInvoices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSCCIPOSPayInvoicesSp(
			string POSNum,
			string InvNum,
			string OrderNum,
			string CustNum,
			string InvCred,
			string Infobar)
		{
			CoNumType _POSNum = POSNum;
			InvNumType _InvNum = InvNum;
			CoNumType _OrderNum = OrderNum;
			CustNumType _CustNum = CustNum;
			StringType _InvCred = InvCred;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIPOSPayInvoicesSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
