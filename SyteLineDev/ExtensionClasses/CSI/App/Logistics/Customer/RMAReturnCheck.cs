//PROJECT NAME: CSICustomer
//CLASS NAME: RMAReturnCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRMAReturnCheck
	{
		int RMAReturnCheckSp(string RMANum,
		                     string CustNum,
		                     ref string Infobar);
	}
	
	public class RMAReturnCheck : IRMAReturnCheck
	{
		readonly IApplicationDB appDB;
		
		public RMAReturnCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RMAReturnCheckSp(string RMANum,
		                            string CustNum,
		                            ref string Infobar)
		{
			RmaNumType _RMANum = RMANum;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RMAReturnCheckSp";
				
				appDB.AddCommandParameter(cmd, "RMANum", _RMANum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
