//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetExternalPostedBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetExternalPostedBal : IExtFinGetExternalPostedBal
	{
		readonly IApplicationDB appDB;
		
		public ExtFinGetExternalPostedBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PostedBalance,
			string Infobar) ExtFinGetExternalPostedBalSp(
			string Customer,
			decimal? PostedBalance,
			string Infobar)
		{
			CustNumType _Customer = Customer;
			AmountType _PostedBalance = PostedBalance;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetExternalPostedBalSp";
				
				appDB.AddCommandParameter(cmd, "Customer", _Customer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedBalance", _PostedBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostedBalance = _PostedBalance;
				Infobar = _Infobar;
				
				return (Severity, PostedBalance, Infobar);
			}
		}
	}
}
