//PROJECT NAME: Logistics
//CLASS NAME: ShipCoShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipCoShip : IShipCoShip
	{
		readonly IApplicationDB appDB;
		
		
		public ShipCoShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Posted,
		string Infobar) ShipCoShipSp(string PShipCoCoNum,
		DateTime? ShipProcGenDate,
		int? Posted,
		string Infobar,
		int? PBatchId,
		string PDoNum)
		{
			CoNumType _PShipCoCoNum = PShipCoCoNum;
			DateType _ShipProcGenDate = ShipProcGenDate;
			IntType _Posted = Posted;
			Infobar _Infobar = Infobar;
			BatchIdType _PBatchId = PBatchId;
			DoNumType _PDoNum = PDoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipCoShipSp";
				
				appDB.AddCommandParameter(cmd, "PShipCoCoNum", _PShipCoCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipProcGenDate", _ShipProcGenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Posted", _Posted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Posted = _Posted;
				Infobar = _Infobar;
				
				return (Severity, Posted, Infobar);
			}
		}
	}
}
