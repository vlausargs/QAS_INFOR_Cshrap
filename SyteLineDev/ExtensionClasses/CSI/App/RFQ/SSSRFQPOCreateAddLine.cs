//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreateAddLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreateAddLine : ISSSRFQPOCreateAddLine
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQPOCreateAddLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSRFQPOCreateAddLineSp(string RFQNum,
		int? RFQLine,
		string Infobar)
		{
			RFQNumType _RFQNum = RFQNum;
			RFQLineType _RFQLine = RFQLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQPOCreateAddLineSp";
				
				appDB.AddCommandParameter(cmd, "RFQNum", _RFQNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
