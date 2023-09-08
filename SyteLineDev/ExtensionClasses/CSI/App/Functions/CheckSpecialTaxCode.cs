//PROJECT NAME: Data
//CLASS NAME: CheckSpecialTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckSpecialTaxCode : ICheckSpecialTaxCode
	{
		readonly IApplicationDB appDB;
		
		public CheckSpecialTaxCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckSpecialTaxCodeFn(
			string TaxCode)
		{
			TaxCodeType _TaxCode = TaxCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckSpecialTaxCode](@TaxCode)";
				
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
