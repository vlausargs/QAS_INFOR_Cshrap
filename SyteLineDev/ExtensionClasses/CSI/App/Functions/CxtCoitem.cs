//PROJECT NAME: Data
//CLASS NAME: CxtCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CxtCoitem : ICxtCoitem
	{
		readonly IApplicationDB appDB;
		
		public CxtCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CxtCoitemSp(
			string CoNum,
			int? CoLine,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CxtCoitemSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
