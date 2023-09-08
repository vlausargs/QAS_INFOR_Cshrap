//PROJECT NAME: Logistics
//CLASS NAME: VendLcrRebalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendLcrRebalance : IVendLcrRebalance
	{
		readonly IApplicationDB appDB;
		
		
		public VendLcrRebalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? VendLcrsRebalanced,
		string Infobar) VendLcrRebalanceSp(string StartingVendNum,
		string EndingVendNum,
		string StartingLcrNum,
		string EndingLcrNum,
		int? VendLcrsRebalanced,
		string Infobar)
		{
			VendNumType _StartingVendNum = StartingVendNum;
			VendNumType _EndingVendNum = EndingVendNum;
			VendLcrNumType _StartingLcrNum = StartingLcrNum;
			VendLcrNumType _EndingLcrNum = EndingLcrNum;
			IntType _VendLcrsRebalanced = VendLcrsRebalanced;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendLcrRebalanceSp";
				
				appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLcrNum", _StartingLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLcrNum", _EndingLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendLcrsRebalanced", _VendLcrsRebalanced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VendLcrsRebalanced = _VendLcrsRebalanced;
				Infobar = _Infobar;
				
				return (Severity, VendLcrsRebalanced, Infobar);
			}
		}
	}
}
