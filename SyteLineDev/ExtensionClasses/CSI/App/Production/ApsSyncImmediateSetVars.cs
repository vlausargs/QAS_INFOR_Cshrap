//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSyncImmediateSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IApsSyncImmediateSetVars
	{
		(int? ReturnCode, string Infobar) ApsSyncImmediateSetVarsSp(string SET,
		string Infobar,
		int? DropDeferred = 0);
	}
	
	public class ApsSyncImmediateSetVars : IApsSyncImmediateSetVars
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncImmediateSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ApsSyncImmediateSetVarsSp(string SET,
		string Infobar,
		int? DropDeferred = 0)
		{
			ProcessIndType _SET = SET;
			InfobarType _Infobar = Infobar;
			IntType _DropDeferred = DropDeferred;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncImmediateSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropDeferred", _DropDeferred, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
