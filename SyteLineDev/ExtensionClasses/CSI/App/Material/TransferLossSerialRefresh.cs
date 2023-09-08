//PROJECT NAME: Material
//CLASS NAME: TransferLossSerialRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TransferLossSerialRefresh : ITransferLossSerialRefresh
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public TransferLossSerialRefresh(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) TransferLossSerialRefreshSp(string PTrnNum,
		int? PTrnLine,
		string FROMSite,
		string ToSite,
		string Lot,
		decimal? TriQtyLoss,
		int? ItLotTracked,
		string Stat,
		string ImportDocId,
		int? ItTaxFreeMatl)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			SiteType _FROMSite = FROMSite;
			SiteType _ToSite = ToSite;
			LotType _Lot = Lot;
			QtyUnitType _TriQtyLoss = TriQtyLoss;
			ListYesNoType _ItLotTracked = ItLotTracked;
			StringType _Stat = Stat;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _ItTaxFreeMatl = ItTaxFreeMatl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferLossSerialRefreshSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMSite", _FROMSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TriQtyLoss", _TriQtyLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItLotTracked", _ItLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItTaxFreeMatl", _ItTaxFreeMatl, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
