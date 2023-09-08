//PROJECT NAME: Production
//CLASS NAME: RSQC_Parmgn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_Parmgn : IRSQC_Parmgn
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_Parmgn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_check_gage,
		int? o_check_method,
		string Infobar) RSQC_ParmgnSp(int? o_check_gage,
		int? o_check_method,
		string Infobar)
		{
			ListYesNoType _o_check_gage = o_check_gage;
			ListYesNoType _o_check_method = o_check_method;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ParmgnSp";
				
				appDB.AddCommandParameter(cmd, "o_check_gage", _o_check_gage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_check_method", _o_check_method, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_check_gage = _o_check_gage;
				o_check_method = _o_check_method;
				Infobar = _Infobar;
				
				return (Severity, o_check_gage, o_check_method, Infobar);
			}
		}
	}
}
