//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQSendQuoteHdr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQSendQuoteHdr : ISSSRFQSendQuoteHdr
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQSendQuoteHdr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Profile,
			string Hdr,
			string AttList,
			string Infobar) SSSRFQSendQuoteHdrSp(
			string RfqNum,
			int? RfqLine,
			string Profile,
			string Hdr,
			string AttList,
			string Infobar)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RFQProfileType _Profile = Profile;
			LongListType _Hdr = Hdr;
			StringType _AttList = AttList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQSendQuoteHdrSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Profile", _Profile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Hdr", _Hdr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AttList", _AttList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Profile = _Profile;
				Hdr = _Hdr;
				AttList = _AttList;
				Infobar = _Infobar;
				
				return (Severity, Profile, Hdr, AttList, Infobar);
			}
		}
	}
}
