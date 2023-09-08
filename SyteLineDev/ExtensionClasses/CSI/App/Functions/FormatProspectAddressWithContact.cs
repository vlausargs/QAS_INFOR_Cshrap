//PROJECT NAME: Data
//CLASS NAME: FormatProspectAddressWithContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatProspectAddressWithContact : IFormatProspectAddressWithContact
	{
		readonly IApplicationDB appDB;
		
		public FormatProspectAddressWithContact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatProspectAddressWithContactFn(
			string ProspectId,
			string Contact = null)
		{
			ProspectIDType _ProspectId = ProspectId;
			ContactType _Contact = Contact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatProspectAddressWithContact](@ProspectId, @Contact)";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
