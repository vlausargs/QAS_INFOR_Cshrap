//PROJECT NAME: Data
//CLASS NAME: TransNatureAllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransNatureAllValid : ITransNatureAllValid
	{
		readonly IApplicationDB appDB;
		
		public TransNatureAllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string Infobar) TransNatureAllValidSp(
			string SiteRef,
			string TransNat,
			string Description,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			TransNatType _TransNat = TransNat;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransNatureAllValidSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
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
