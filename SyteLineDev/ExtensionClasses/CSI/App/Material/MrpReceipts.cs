//PROJECT NAME: Material
//CLASS NAME: MrpReceipts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpReceipts : IMrpReceipts
	{
		readonly IApplicationDB appDB;
		
		public MrpReceipts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpReceiptsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpReceiptsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
