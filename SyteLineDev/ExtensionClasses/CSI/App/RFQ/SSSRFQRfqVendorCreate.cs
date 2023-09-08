//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQRfqVendorCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQRfqVendorCreate : ISSSRFQRfqVendorCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQRfqVendorCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRFQRfqVendorCreateSp(
			string RfqNum,
			int? RfqLine,
			Guid? SessionID,
			string Infobar)
		{
			RFQNumType _RfqNum = RfqNum;
			RFQLineType _RfqLine = RfqLine;
			RowPointerType _SessionID = SessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQRfqVendorCreateSp";
				
				appDB.AddCommandParameter(cmd, "RfqNum", _RfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RfqLine", _RfqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
