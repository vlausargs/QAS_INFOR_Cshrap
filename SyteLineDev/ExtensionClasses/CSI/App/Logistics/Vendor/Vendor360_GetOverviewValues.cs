//PROJECT NAME: Logistics
//CLASS NAME: Vendor360_GetOverviewValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Vendor360_GetOverviewValues : IVendor360_GetOverviewValues
	{
		readonly IApplicationDB appDB;
		
		
		public Vendor360_GetOverviewValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LateOrders,
		decimal? POFundsCommittedAmount) Vendor360_GetOverviewValuesSp(string VendorID,
		decimal? LateOrders,
		decimal? POFundsCommittedAmount)
		{
			VendNumType _VendorID = VendorID;
			AmountType _LateOrders = LateOrders;
			AmountType _POFundsCommittedAmount = POFundsCommittedAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Vendor360_GetOverviewValuesSp";
				
				appDB.AddCommandParameter(cmd, "VendorID", _VendorID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LateOrders", _LateOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POFundsCommittedAmount", _POFundsCommittedAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LateOrders = _LateOrders;
				POFundsCommittedAmount = _POFundsCommittedAmount;
				
				return (Severity, LateOrders, POFundsCommittedAmount);
			}
		}
	}
}
