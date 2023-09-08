//PROJECT NAME: Data
//CLASS NAME: FormatLongAddressWithContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatLongAddressWithContact : IFormatLongAddressWithContact
	{
		readonly IApplicationDB appDB;
		
		public FormatLongAddressWithContact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string LongAddr) FormatLongAddressWithContactSp(
			string CustNum,
			int? CustSeq,
			string Contact = null,
			string LongAddr = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ContactType _Contact = Contact;
			LongAddress _LongAddr = LongAddr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatLongAddressWithContactSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongAddr", _LongAddr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LongAddr = _LongAddr;
				
				return (Severity, LongAddr);
			}
		}
	}
}
