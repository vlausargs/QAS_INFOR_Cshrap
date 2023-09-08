//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_UnshipShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_UnshipShipment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_UnshipShipmentSp(decimal? ShipmentId,
		byte? Return2Stock,
		string Filter = null);
	}
	
	public class CLM_UnshipShipment : ICLM_UnshipShipment
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_UnshipShipment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_UnshipShipmentSp(decimal? ShipmentId,
		byte? Return2Stock,
		string Filter = null)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			ListYesNoType _Return2Stock = Return2Stock;
			LongListType _Filter = Filter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_UnshipShipmentSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return2Stock", _Return2Stock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
