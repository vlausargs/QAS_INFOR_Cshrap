//PROJECT NAME: Data
//CLASS NAME: TransNature2AllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransNature2AllValid : ITransNature2AllValid
	{
		readonly IApplicationDB appDB;
		
		public TransNature2AllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string Infobar) TransNature2AllValidSp(
			string SiteRef,
			string TransNat2,
			string Description,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			TransNat2Type _TransNat2 = TransNat2;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransNature2AllValidSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.Input);
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
