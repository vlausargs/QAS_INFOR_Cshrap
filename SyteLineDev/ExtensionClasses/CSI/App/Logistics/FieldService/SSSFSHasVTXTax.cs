//PROJECT NAME: Logistics
//CLASS NAME: SSSFSHasVTXTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSHasVTXTax : ISSSFSHasVTXTax
	{
		readonly IApplicationDB appDB;
		
		public SSSFSHasVTXTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSHasVTXTaxFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSHasVTXTax]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
