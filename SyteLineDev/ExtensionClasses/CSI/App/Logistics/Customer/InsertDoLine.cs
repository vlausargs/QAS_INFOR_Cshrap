//PROJECT NAME: Logistics
//CLASS NAME: InsertDoLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InsertDoLine : IInsertDoLine
	{
		readonly IApplicationDB appDB;
		
		
		public InsertDoLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DoLine,
		string ErrorMsg) InsertDoLineSp(string DoNum,
		int? DoLine,
		string ErrorMsg)
		{
			DoNumType _DoNum = DoNum;
			CoLineType _DoLine = DoLine;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertDoLineSp";
				
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DoLine = _DoLine;
				ErrorMsg = _ErrorMsg;
				
				return (Severity, DoLine, ErrorMsg);
			}
		}
	}
}
