//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckforTestPlan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckforTestPlan : IRSQC_CheckforTestPlan
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CheckforTestPlan(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_output,
		string Infobar) RSQC_CheckforTestPlanSp(int? i_rcvr,
		string o_output,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			StringType _o_output = o_output;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckforTestPlanSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_output", _o_output, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_output = _o_output;
				Infobar = _Infobar;
				
				return (Severity, o_output, Infobar);
			}
		}
	}
}
