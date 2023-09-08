//PROJECT NAME: POS
//CLASS NAME: SSSPOSHasVTXTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSHasVTXTax : ISSSPOSHasVTXTax
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSHasVTXTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSPOSHasVTXTaxFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSPOSHasVTXTax]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
