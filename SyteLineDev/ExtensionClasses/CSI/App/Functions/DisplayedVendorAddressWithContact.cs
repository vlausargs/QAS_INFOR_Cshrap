//PROJECT NAME: Data
//CLASS NAME: DisplayedVendorAddressWithContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayedVendorAddressWithContact : IDisplayedVendorAddressWithContact
	{
		readonly IApplicationDB appDB;
		
		public DisplayedVendorAddressWithContact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayedVendorAddressWithContactSp(
			string VendNum,
			string Contact = null)
		{
			VendNumType _VendNum = VendNum;
			ContactType _Contact = Contact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayedVendorAddressWithContactSp](@VendNum, @Contact)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
