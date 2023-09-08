//PROJECT NAME: CSIVendor
//CLASS NAME: GetFirstRankedVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetFirstRankedVendor
	{
		int GetFirstRankedVendorSp(string Item,
		                           ref string VendNum,
		                           ref string VendorName);
	}
	
	public class GetFirstRankedVendor : IGetFirstRankedVendor
	{
		readonly IApplicationDB appDB;
		
		public GetFirstRankedVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetFirstRankedVendorSp(string Item,
		                                  ref string VendNum,
		                                  ref string VendorName)
		{
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			NameType _VendorName = VendorName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFirstRankedVendorSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorName", _VendorName, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VendNum = _VendNum;
				VendorName = _VendorName;
				
				return Severity;
			}
		}
	}
}
