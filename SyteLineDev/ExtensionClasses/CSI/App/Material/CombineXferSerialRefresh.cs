//PROJECT NAME: Material
//CLASS NAME: CombineXferSerialRefresh.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferSerialRefresh : ICombineXferSerialRefresh
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CombineXferSerialRefresh(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CombineXferSerialRefreshSp(string Item,
		decimal? QtyShipped,
		string FromSite,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		string StartSerNum,
		string ImportDocId,
		string TrnNum,
		int? TrnLine,
		int? PreassignSerials)
		{
			ItemType _Item = Item;
			QtyUnitType _QtyShipped = QtyShipped;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			SerNumType _StartSerNum = StartSerNum;
			ImportDocIdType _ImportDocId = ImportDocId;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			ListYesNoType _PreassignSerials = PreassignSerials;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferSerialRefreshSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
