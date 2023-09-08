//PROJECT NAME: Codes
//CLASS NAME: TaxDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class TaxDesc : ITaxDesc
	{
		readonly IApplicationDB appDB;
		
		
		public TaxDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PTaxCodeDesc1,
		string PTaxCodeDesc2) TaxDescSp(string PType,
		string PTaxCode1,
		string PTaxCode2,
		string PTaxCodeDesc1,
		string PTaxCodeDesc2)
		{
			StringType _PType = PType;
			TaxCodeType _PTaxCode1 = PTaxCode1;
			TaxCodeType _PTaxCode2 = PTaxCode2;
			DescriptionType _PTaxCodeDesc1 = PTaxCodeDesc1;
			DescriptionType _PTaxCodeDesc2 = PTaxCodeDesc2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDescSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode1", _PTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode2", _PTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCodeDesc1", _PTaxCodeDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTaxCodeDesc2", _PTaxCodeDesc2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTaxCodeDesc1 = _PTaxCodeDesc1;
				PTaxCodeDesc2 = _PTaxCodeDesc2;
				
				return (Severity, PTaxCodeDesc1, PTaxCodeDesc2);
			}
		}
	}
}
