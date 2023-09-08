//PROJECT NAME: Finance
//CLASS NAME: FRFecGetPath.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FRFecGetPath : IFRFecGetPath
	{
		readonly IApplicationDB appDB;
		
		
		public FRFecGetPath(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PPath,
		string PFedId,
		string Infobar) FRFecGetPathSp(string PPath,
		string PFedId,
		string Infobar)
		{
			StringType _PPath = PPath;
			TaxRegNumType _PFedId = PFedId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FRFecGetPathSp";
				
				appDB.AddCommandParameter(cmd, "PPath", _PPath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFedId", _PFedId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPath = _PPath;
				PFedId = _PFedId;
				Infobar = _Infobar;
				
				return (Severity, PPath, PFedId, Infobar);
			}
		}
	}
}
