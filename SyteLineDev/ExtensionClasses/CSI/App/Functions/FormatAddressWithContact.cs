//PROJECT NAME: Data
//CLASS NAME: FormatAddressWithContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatAddressWithContact : IFormatAddressWithContact
	{
		readonly IApplicationDB appDB;
		
		public FormatAddressWithContact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatAddressWithContactSp(
			string CustNum,
			int? CustSeq,
			string Contact = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ContactType _Contact = Contact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatAddressWithContactSp](@CustNum, @CustSeq, @Contact)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
