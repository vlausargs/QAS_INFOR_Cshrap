//PROJECT NAME: Logistics
//CLASS NAME: ITax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ITax : IITax
	{
		IApplicationDB appDB;
		
		
		public ITax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PDefaultTaxCode) ITaxSp(int? PTaxSystem,
		string PTaxCode,
		string PItem,
		string PDefaultTaxCode,
		string Site = null)
		{
			TaxSystemType _PTaxSystem = PTaxSystem;
			TaxCodeType _PTaxCode = PTaxCode;
			ItemType _PItem = PItem;
			TaxCodeType _PDefaultTaxCode = PDefaultTaxCode;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ITaxSp";
				
				appDB.AddCommandParameter(cmd, "PTaxSystem", _PTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode", _PTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDefaultTaxCode", _PDefaultTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDefaultTaxCode = _PDefaultTaxCode;
				
				return (Severity, PDefaultTaxCode);
			}
		}
	}
}
