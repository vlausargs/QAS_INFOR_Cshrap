//PROJECT NAME: Logistics
//CLASS NAME: CLM_LoadPackListSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_LoadPackListSerial : ICLM_LoadPackListSerial
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_LoadPackListSerial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_LoadPackListSerialSp(decimal? PickListId,
		string Item,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Whse,
		string Loc,
		string Lot,
		decimal? Qty,
		string ParentContainerNum,
		int? Gen,
		decimal? GenQty,
		string Infobar)
		{
			PickListIDType _PickListId = PickListId;
			ItemType _Item = Item;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _Qty = Qty;
			ContainerNumType _ParentContainerNum = ParentContainerNum;
			ListYesNoType _Gen = Gen;
			QtyUnitType _GenQty = GenQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_LoadPackListSerialSp";
				
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentContainerNum", _ParentContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Gen", _Gen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenQty", _GenQty, ParameterDirection.Input);
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
