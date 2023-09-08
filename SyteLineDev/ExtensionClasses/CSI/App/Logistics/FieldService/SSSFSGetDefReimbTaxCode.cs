//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetDefReimbTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetDefReimbTaxCode : ISSSFSGetDefReimbTaxCode
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetDefReimbTaxCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ReimbTaxCode1,
			string ReimbTaxCode2,
			string Infobar) SSSFSGetDefReimbTaxCodeSp(
			string PartnerId,
			string ReimbTaxCode1,
			string ReimbTaxCode2,
			string Infobar)
		{
			FSPartnerType _PartnerId = PartnerId;
			TaxCodeType _ReimbTaxCode1 = ReimbTaxCode1;
			TaxCodeType _ReimbTaxCode2 = ReimbTaxCode2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetDefReimbTaxCodeSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode1", _ReimbTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode2", _ReimbTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReimbTaxCode1 = _ReimbTaxCode1;
				ReimbTaxCode2 = _ReimbTaxCode2;
				Infobar = _Infobar;
				
				return (Severity, ReimbTaxCode1, ReimbTaxCode2, Infobar);
			}
		}
	}
}
