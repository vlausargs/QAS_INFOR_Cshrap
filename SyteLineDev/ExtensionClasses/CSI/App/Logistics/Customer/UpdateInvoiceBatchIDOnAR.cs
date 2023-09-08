//PROJECT NAME: Logistics
//CLASS NAME: UpdateInvoiceBatchIDOnAR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateInvoiceBatchIDOnAR : IUpdateInvoiceBatchIDOnAR
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateInvoiceBatchIDOnAR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateInvoiceBatchIDOnARSp(string InvNum,
		decimal? InvBatchID)
		{
			InvNumType _InvNum = InvNum;
			InvBatchIDType _InvBatchID = InvBatchID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateInvoiceBatchIDOnARSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvBatchID", _InvBatchID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
