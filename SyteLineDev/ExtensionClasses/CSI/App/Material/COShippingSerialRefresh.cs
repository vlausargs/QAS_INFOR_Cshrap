//PROJECT NAME: Material
//CLASS NAME: COShippingSerialRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class COShippingSerialRefresh : ICOShippingSerialRefresh
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public COShippingSerialRefresh(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) COShippingSerialRefreshSp(string Item,
		decimal? QtyShipped,
		int? UbCRRt,
		string Whse,
		string Loc,
		string Lot,
		string StartSerNum,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string DoNum,
		int? DoLine,
		decimal? ShipmentID,
		int? ShipmentLine,
		int? ShipmentSeq,
		int? Gen,
		decimal? GenQty,
		string ImportDocId,
		int? TransType,
		string StartingSerial,
		string EndingSerial,
		string ContainerNum)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ItemType _Item = Item;
				QtyUnitType _QtyShipped = QtyShipped;
				ByteType _UbCRRt = UbCRRt;
				WhseType _Whse = Whse;
				LocType _Loc = Loc;
				LotType _Lot = Lot;
				SerNumType _StartSerNum = StartSerNum;
				CoNumType _CoNum = CoNum;
				CoLineType _CoLine = CoLine;
				CoReleaseType _CoRelease = CoRelease;
				DoNumType _DoNum = DoNum;
				DoLineType _DoLine = DoLine;
				ShipmentIDType _ShipmentID = ShipmentID;
				ShipmentLineType _ShipmentLine = ShipmentLine;
				ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
				ListYesNoType _Gen = Gen;
				DecimalType _GenQty = GenQty;
				ImportDocIdType _ImportDocId = ImportDocId;
				IntType _TransType = TransType;
				SerNumType _StartingSerial = StartingSerial;
				SerNumType _EndingSerial = EndingSerial;
				ContainerNumType _ContainerNum = ContainerNum;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "COShippingSerialRefreshSp";
					
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UbCRRt", _UbCRRt, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Gen", _Gen, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GenQty", _GenQty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingSerial", _StartingSerial, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingSerial", _EndingSerial, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
