//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetShipments.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetShipments : IFTSLGetShipments
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public FTSLGetShipments(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) FTSLGetShipmentsSp(decimal? ShipmentId,
		string ShipLoc,
		string PackLoc,
		string Order,
		string ShipTo,
		string Infobar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			LocType _ShipLoc = ShipLoc;
			LocType _PackLoc = PackLoc;
			JobType _Order = Order;
			CustNumType _ShipTo = ShipTo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetShipmentsSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipLoc", _ShipLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackLoc", _PackLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Order", _Order, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipTo", _ShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
