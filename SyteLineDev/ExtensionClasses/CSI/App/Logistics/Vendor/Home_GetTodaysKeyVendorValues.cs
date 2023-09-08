//PROJECT NAME: CSIVendor
//CLASS NAME: Home_GetTodaysKeyVendorValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IHome_GetTodaysKeyVendorValues
	{
		int Home_GetTodaysKeyVendorValuesSp(ref decimal? LateAmount,
		                                    ref decimal? FundsCommittedAmount,
		                                    ref decimal? OpenPayablesAmount);
	}
	
	public class Home_GetTodaysKeyVendorValues : IHome_GetTodaysKeyVendorValues
	{
		readonly IApplicationDB appDB;
		
		public Home_GetTodaysKeyVendorValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Home_GetTodaysKeyVendorValuesSp(ref decimal? LateAmount,
		                                           ref decimal? FundsCommittedAmount,
		                                           ref decimal? OpenPayablesAmount)
		{
			AmountType _LateAmount = LateAmount;
			AmountType _FundsCommittedAmount = FundsCommittedAmount;
			AmountType _OpenPayablesAmount = OpenPayablesAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_GetTodaysKeyVendorValuesSp";
				
				appDB.AddCommandParameter(cmd, "LateAmount", _LateAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FundsCommittedAmount", _FundsCommittedAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OpenPayablesAmount", _OpenPayablesAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LateAmount = _LateAmount;
				FundsCommittedAmount = _FundsCommittedAmount;
				OpenPayablesAmount = _OpenPayablesAmount;
				
				return Severity;
			}
		}
	}
}
