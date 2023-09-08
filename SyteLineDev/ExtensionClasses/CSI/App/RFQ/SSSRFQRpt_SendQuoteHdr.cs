//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQRpt_SendQuoteHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQRpt_SendQuoteHdr : ISSSRFQRpt_SendQuoteHdr
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQRpt_SendQuoteHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum,
			string Infobar) SSSRFQRpt_SendQuoteHdrSp(
			string RfqNum,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum,
			string Infobar)
		{
			RFQNumType _RfqNum = RfqNum;
			ContactType _OurContact = OurContact;
			PhoneType _OurPhone = OurPhone;
			LongAddress _OurAddr = OurAddr;
			PhoneType _OurFaxNum = OurFaxNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRpt_SendQuoteHdrSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OurContact", _OurContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OurPhone", _OurPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OurAddr", _OurAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OurFaxNum", _OurFaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OurContact = _OurContact;
				OurPhone = _OurPhone;
				OurAddr = _OurAddr;
				OurFaxNum = _OurFaxNum;
				Infobar = _Infobar;
				
				return (Severity, OurContact, OurPhone, OurAddr, OurFaxNum, Infobar);
			}
		}
	}
}
