//PROJECT NAME: CSICustomer
//CLASS NAME: SubmitOrderConfirmation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISubmitOrderConfirmation
	{
		int SubmitOrderConfirmationSp(string CoNum,
		                              string Username);
	}
	
	public class SubmitOrderConfirmation : ISubmitOrderConfirmation
	{
		readonly IApplicationDB appDB;
		
		public SubmitOrderConfirmation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SubmitOrderConfirmationSp(string CoNum,
		                                     string Username)
		{
			CoNumType _CoNum = CoNum;
			UsernameType _Username = Username;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SubmitOrderConfirmationSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
