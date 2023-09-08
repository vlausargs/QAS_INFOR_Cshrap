//PROJECT NAME: Data
//CLASS NAME: DelTermAllUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DelTermAllUsed : IDelTermAllUsed
	{
		readonly IApplicationDB appDB;
		
		public DelTermAllUsed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DelTermAllUsedSp(
			string SiteRef,
			string Delterm,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			DeltermType _Delterm = Delterm;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelTermAllUsedSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
