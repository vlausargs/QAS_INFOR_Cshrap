//PROJECT NAME: Data
//CLASS NAME: EstimateLinesGetTaxCodeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EstimateLinesGetTaxCodeDesc : IEstimateLinesGetTaxCodeDesc
	{
		readonly IApplicationDB appDB;
		
		public EstimateLinesGetTaxCodeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PTaxDesc1,
			string PTaxDesc2) EstimateLinesGetTaxCodeDescSp(
			string PTaxCode1,
			string PTaxCode2,
			string PTaxDesc1,
			string PTaxDesc2)
		{
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			LongList _PTaxDesc1 = PTaxDesc1;
			LongList _PTaxDesc2 = PTaxDesc2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesGetTaxCodeDescSp";
				
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxDesc1", _PTaxDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxDesc2", _PTaxDesc2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTaxDesc1 = _PTaxDesc1;
				PTaxDesc2 = _PTaxDesc2;
				
				return (Severity, PTaxDesc1, PTaxDesc2);
			}
		}
	}
}
