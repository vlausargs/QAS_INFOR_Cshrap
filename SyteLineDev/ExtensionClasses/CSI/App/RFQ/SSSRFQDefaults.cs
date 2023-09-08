//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQDefaults : ISSSRFQDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Buyer,
		DateTime? ReplyDate,
		string Infobar) SSSRFQDefaultsSp(string Buyer,
		DateTime? ReplyDate,
		string Infobar)
		{
			UsernameType _Buyer = Buyer;
			DateType _ReplyDate = ReplyDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReplyDate", _ReplyDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Buyer = _Buyer;
				ReplyDate = _ReplyDate;
				Infobar = _Infobar;
				
				return (Severity, Buyer, ReplyDate, Infobar);
			}
		}
	}
}
