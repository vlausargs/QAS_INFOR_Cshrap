//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROReadyToInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROReadyToInvoice : ISSSFSSROReadyToInvoice
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROReadyToInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROReadyToInvoiceFn(
			string SroNum)
		{
			FSSRONumType _SroNum = SroNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSROReadyToInvoice](@SroNum)";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
