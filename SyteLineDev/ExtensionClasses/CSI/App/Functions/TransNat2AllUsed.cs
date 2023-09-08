//PROJECT NAME: Data
//CLASS NAME: TransNat2AllUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransNat2AllUsed : ITransNat2AllUsed
	{
		readonly IApplicationDB appDB;
		
		public TransNat2AllUsed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TransNat2AllUsedSp(
			string SiteRef,
			string TransNat2,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			TransNat2Type _TransNat2 = TransNat2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransNat2AllUsedSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
