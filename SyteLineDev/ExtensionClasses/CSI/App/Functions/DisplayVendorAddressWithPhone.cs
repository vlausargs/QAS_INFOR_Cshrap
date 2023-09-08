//PROJECT NAME: Data
//CLASS NAME: DisplayVendorAddressWithPhone.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayVendorAddressWithPhone : IDisplayVendorAddressWithPhone
	{
		readonly IApplicationDB appDB;
		
		public DisplayVendorAddressWithPhone(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayVendorAddressWithPhoneSp(
			string VendNum)
		{
			VendNumType _VendNum = VendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayVendorAddressWithPhoneSp](@VendNum)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
