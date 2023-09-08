//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUser2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetUser2 : IRSQC_GetUser2
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetUser2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_emp_num,
		string o_name,
		string Infobar) RSQC_GetUser2Sp(string o_emp_num,
		string o_name,
		string Infobar)
		{
			EmpNumType _o_emp_num = o_emp_num;
			NameType _o_name = o_name;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetUser2Sp";
				
				appDB.AddCommandParameter(cmd, "o_emp_num", _o_emp_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_name", _o_name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_emp_num = _o_emp_num;
				o_name = _o_name;
				Infobar = _Infobar;
				
				return (Severity, o_emp_num, o_name, Infobar);
			}
		}
	}
}
