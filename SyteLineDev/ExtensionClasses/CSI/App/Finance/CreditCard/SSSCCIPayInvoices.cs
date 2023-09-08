//PROJECT NAME: Finance
//CLASS NAME: SSSCCIPayInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIPayInvoices : ISSSCCIPayInvoices
	{
		readonly IApplicationDB appDB;
		
		
		public SSSCCIPayInvoices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSCCIPayInvoicesSp(string BegInvNum,
		string EndInvNum,
		string Infobar)
		{
			InvNumType _BegInvNum = BegInvNum;
			InvNumType _EndInvNum = EndInvNum;
			Infobar _Infobar = Infobar;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIPayInvoicesSp";
				
				appDB.AddCommandParameter(cmd, "BegInvNum", _BegInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
