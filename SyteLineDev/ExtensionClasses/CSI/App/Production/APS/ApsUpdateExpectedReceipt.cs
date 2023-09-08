//PROJECT NAME: Production
//CLASS NAME: ApsUpdateExpectedReceipt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdateExpectedReceipt : IApsUpdateExpectedReceipt
	{
		readonly IApplicationDB appDB;
		
		public ApsUpdateExpectedReceipt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdateExpectedReceiptSp(
			int? AltNo,
			string OrderId)
		{
			ShortType _AltNo = AltNo;
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdateExpectedReceiptSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
