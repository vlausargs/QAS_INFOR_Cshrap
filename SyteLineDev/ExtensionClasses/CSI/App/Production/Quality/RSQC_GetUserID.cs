//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUserID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetUserID : IRSQC_GetUserID
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetUserID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EmpNum,
		string Infobar) RSQC_GetUserIDSp(string EmpNum,
		string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetUserIDSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpNum = _EmpNum;
				Infobar = _Infobar;
				
				return (Severity, EmpNum, Infobar);
			}
		}
	}
}
