//PROJECT NAME: Data
//CLASS NAME: Taxcd2D.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Taxcd2D : ITaxcd2D
	{
		readonly IApplicationDB appDB;
		
		public Taxcd2D(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Taxcd2DSp(
			string TaxCodeType,
			int? TaxSystem,
			string TaxCode,
			string Site,
			string Infobar)
		{
			TaxCodeTypeType _TaxCodeType = TaxCodeType;
			TaxSystemType _TaxSystem = TaxSystem;
			TaxCodeType _TaxCode = TaxCode;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Taxcd2DSp";
				
				appDB.AddCommandParameter(cmd, "TaxCodeType", _TaxCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
