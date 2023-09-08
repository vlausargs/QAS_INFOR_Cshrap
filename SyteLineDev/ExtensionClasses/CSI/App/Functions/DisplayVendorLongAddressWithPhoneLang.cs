//PROJECT NAME: Data
//CLASS NAME: DisplayVendorLongAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayVendorLongAddressWithPhoneLang : IDisplayVendorLongAddressWithPhoneLang
	{
		readonly IApplicationDB appDB;
		
		public DisplayVendorLongAddressWithPhoneLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string LongAddr) DisplayVendorLongAddressWithPhoneLangSp(
			string VendNum,
			string MessageLanguage,
			string Contact = null,
			string LongAddr = null)
		{
			VendNumType _VendNum = VendNum;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			ContactType _Contact = Contact;
			LongAddress _LongAddr = LongAddr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DisplayVendorLongAddressWithPhoneLangSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongAddr", _LongAddr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LongAddr = _LongAddr;
				
				return (Severity, LongAddr);
			}
		}
	}
}
