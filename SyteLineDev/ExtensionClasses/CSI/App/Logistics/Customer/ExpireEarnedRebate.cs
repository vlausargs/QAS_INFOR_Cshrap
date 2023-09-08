//PROJECT NAME: CSICustomer
//CLASS NAME: ExpireEarnedRebate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IExpireEarnedRebate
	{
		int ExpireEarnedRebateSp(decimal? EarnedRebateId,
		                         string Infobar);
	}
	
	public class ExpireEarnedRebate : IExpireEarnedRebate
	{
		readonly IApplicationDB appDB;
		
		public ExpireEarnedRebate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ExpireEarnedRebateSp(decimal? EarnedRebateId,
		                                string Infobar)
		{
			EarnedRebateIdType _EarnedRebateId = EarnedRebateId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExpireEarnedRebateSp";
				
				appDB.AddCommandParameter(cmd, "EarnedRebateId", _EarnedRebateId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
