//PROJECT NAME: CSICustomer
//CLASS NAME: Home_GetTodaysKeySalespersonValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHome_GetTodaysKeySalespersonValues
	{
		int Home_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionAmount,
		                                         ref decimal? BookingAmount,
		                                         ref decimal? EstimateAmount);
	}
	
	public class Home_GetTodaysKeySalespersonValues : IHome_GetTodaysKeySalespersonValues
	{
		readonly IApplicationDB appDB;
		
		public Home_GetTodaysKeySalespersonValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Home_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionAmount,
		                                                ref decimal? BookingAmount,
		                                                ref decimal? EstimateAmount)
		{
			AmountType _CommissionAmount = CommissionAmount;
			AmountType _BookingAmount = BookingAmount;
			AmountType _EstimateAmount = EstimateAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_GetTodaysKeySalespersonValuesSp";
				
				appDB.AddCommandParameter(cmd, "CommissionAmount", _CommissionAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BookingAmount", _BookingAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EstimateAmount", _EstimateAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CommissionAmount = _CommissionAmount;
				BookingAmount = _BookingAmount;
				EstimateAmount = _EstimateAmount;
				
				return Severity;
			}
		}
	}
}
