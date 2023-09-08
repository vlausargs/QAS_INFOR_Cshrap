//PROJECT NAME: Logistics
//CLASS NAME: RmaRepl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaRepl : IRmaRepl
	{
		readonly IApplicationDB appDB;
		
		
		public RmaRepl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RmaCoNum,
		int? RmaCoLine,
		string Infobar) RmaReplSp(string RmaNum,
		int? RmaLine,
		string RmaCoNum,
		int? RmaCoLine,
		string Infobar)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			CoNumType _RmaCoNum = RmaCoNum;
			CoLineType _RmaCoLine = RmaCoLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaCoNum", _RmaCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RmaCoLine", _RmaCoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RmaCoNum = _RmaCoNum;
				RmaCoLine = _RmaCoLine;
				Infobar = _Infobar;
				
				return (Severity, RmaCoNum, RmaCoLine, Infobar);
			}
		}
	}
}
