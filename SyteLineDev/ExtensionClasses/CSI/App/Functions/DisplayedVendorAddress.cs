//PROJECT NAME: Data
//CLASS NAME: DisplayedVendorAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayedVendorAddress : IDisplayedVendorAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayedVendorAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayedVendorAddressSp(
			string VendNum)
		{
			VendNumType _VendNum = VendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayedVendorAddressSp](@VendNum)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
