//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQRpt_SendQuoteLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQRpt_SendQuoteLine : ISSSRFQRpt_SendQuoteLine
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQRpt_SendQuoteLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSRFQRpt_SendQuoteLineSp(
			string RfqNum,
			int? RfqLine,
			int? RfqSeq,
			string OurContact,
			string OurPhone,
			string OurAddr,
			string OurFaxNum)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQSeqType _RfqSeq = RfqSeq;
			ContactType _OurContact = OurContact;
			PhoneType _OurPhone = OurPhone;
			LongAddress _OurAddr = OurAddr;
			PhoneType _OurFaxNum = OurFaxNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRpt_SendQuoteLineSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqSeq", _RfqSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OurContact", _OurContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OurPhone", _OurPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OurAddr", _OurAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OurFaxNum", _OurFaxNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
