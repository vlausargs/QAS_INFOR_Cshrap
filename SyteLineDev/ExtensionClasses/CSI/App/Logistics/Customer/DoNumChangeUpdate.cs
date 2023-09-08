//PROJECT NAME: CSICustomer
//CLASS NAME: DoNumChangeUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDoNumChangeUpdate
	{
		int DoNumChangeUpdateSp(int? PBatchId,
		                        string DerOldDoNum,
		                        string DerNewDoNum);
	}
	
	public class DoNumChangeUpdate : IDoNumChangeUpdate
	{
		readonly IApplicationDB appDB;
		
		public DoNumChangeUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DoNumChangeUpdateSp(int? PBatchId,
		                               string DerOldDoNum,
		                               string DerNewDoNum)
		{
			BatchIdType _PBatchId = PBatchId;
			DoNumType _DerOldDoNum = DerOldDoNum;
			DoNumType _DerNewDoNum = DerNewDoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DoNumChangeUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerOldDoNum", _DerOldDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerNewDoNum", _DerNewDoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
