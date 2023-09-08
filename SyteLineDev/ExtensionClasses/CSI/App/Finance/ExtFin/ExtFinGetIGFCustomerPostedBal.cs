//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetIGFCustomerPostedBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetIGFCustomerPostedBal : IExtFinGetIGFCustomerPostedBal
	{
		readonly IApplicationDB appDB;
		
		public ExtFinGetIGFCustomerPostedBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinGetIGFCustomerPostedBalSp(
			string StartingCustNum = null,
			string EndingCustNum = null,
			string Infobar = null)
		{
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetIGFCustomerPostedBalSp";
				
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
