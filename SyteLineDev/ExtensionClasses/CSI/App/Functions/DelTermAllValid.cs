//PROJECT NAME: Data
//CLASS NAME: DelTermAllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DelTermAllValid : IDelTermAllValid
	{
		readonly IApplicationDB appDB;
		
		public DelTermAllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string Infobar) DelTermAllValidSp(
			string SiteRef,
			string Delterm,
			string Description,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			DeltermType _Delterm = Delterm;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelTermAllValidSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				Infobar = _Infobar;
				
				return (Severity, Description, Infobar);
			}
		}
	}
}
