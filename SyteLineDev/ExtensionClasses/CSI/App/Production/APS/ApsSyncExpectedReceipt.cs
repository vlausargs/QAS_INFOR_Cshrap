//PROJECT NAME: Production
//CLASS NAME: ApsSyncExpectedReceipt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncExpectedReceipt : IApsSyncExpectedReceipt
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncExpectedReceipt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncExpectedReceiptSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncExpectedReceiptSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
