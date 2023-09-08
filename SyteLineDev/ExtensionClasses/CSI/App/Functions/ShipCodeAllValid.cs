//PROJECT NAME: Data
//CLASS NAME: ShipCodeAllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ShipCodeAllValid : IShipCodeAllValid
	{
		readonly IApplicationDB appDB;
		
		public ShipCodeAllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string Infobar) ShipCodeAllValidSp(
			string SiteRef,
			string ShipCode,
			string Description,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			ShipCodeType _ShipCode = ShipCode;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipCodeAllValidSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
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
