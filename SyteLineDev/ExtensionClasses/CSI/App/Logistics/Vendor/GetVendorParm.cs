//PROJECT NAME: Logistics
//CLASS NAME: GetVendorParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVendorParm : IGetVendorParm
	{
		readonly IApplicationDB appDB;
		
		
		public GetVendorParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string VendPriceBy) GetVendorParmSp(string VendNum,
		string VendPriceBy)
		{
			VendNumType _VendNum = VendNum;
			ListOrderDueType _VendPriceBy = VendPriceBy;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendorParmSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendPriceBy", _VendPriceBy, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VendPriceBy = _VendPriceBy;
				
				return (Severity, VendPriceBy);
			}
		}
	}
}
