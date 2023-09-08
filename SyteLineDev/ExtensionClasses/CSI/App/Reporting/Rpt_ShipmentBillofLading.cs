//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentBillofLading.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ShipmentBillofLading : IRpt_ShipmentBillofLading
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ShipmentBillofLading(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentBillofLadingSp(decimal? ShipmentStarting = null,
		decimal? ShipmentEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? PickupDateStartingOffset = null,
		int? PickupDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ShipmentIDType _ShipmentStarting = ShipmentStarting;
			ShipmentIDType _ShipmentEnding = ShipmentEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CustSeqType _CustSeqStarting = CustSeqStarting;
			CustSeqType _CustSeqEnding = CustSeqEnding;
			DateType _PickupDateStarting = PickupDateStarting;
			DateType _PickupDateEnding = PickupDateEnding;
			DateOffsetType _PickupDateStartingOffset = PickupDateStartingOffset;
			DateOffsetType _PickupDateEndingOffset = PickupDateEndingOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ShipmentBillofLadingSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentStarting", _ShipmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentEnding", _ShipmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqStarting", _CustSeqStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqEnding", _CustSeqEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStarting", _PickupDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEnding", _PickupDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStartingOffset", _PickupDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEndingOffset", _PickupDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
