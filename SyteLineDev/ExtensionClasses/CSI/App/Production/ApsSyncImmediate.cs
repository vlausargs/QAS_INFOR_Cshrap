//PROJECT NAME: Production
//CLASS NAME: ApsSyncImmediate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ApsSyncImmediate : IApsSyncImmediate
	{
		readonly IApplicationDB appDB;
		
		
		public ApsSyncImmediate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ApsSyncImmediateSp(string Infobar,
		int? DropDeferred = 0,
		string Context = null)
		{
			InfobarType _Infobar = Infobar;
			IntType _DropDeferred = DropDeferred;
			StringType _Context = Context;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncImmediateSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropDeferred", _DropDeferred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Context", _Context, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
