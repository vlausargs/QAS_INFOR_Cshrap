//PROJECT NAME: Material
//CLASS NAME: CLM_RMAReturnSerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICLM_RMAReturnSerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_RMAReturnSerialLoadSp(string RMANum,
		short? RMALIne,
		string SerialPrefix,
		decimal? RMAReturnQty,
		decimal? SerialGenQty,
		string Whse,
		string Loc,
		string Lot,
		string UnRecvLoc,
		string UnRecvLot,
		string StartSerNum,
		byte? GenerateFlag);
	}
	
	public class CLM_RMAReturnSerialLoad : ICLM_RMAReturnSerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_RMAReturnSerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_RMAReturnSerialLoadSp(string RMANum,
		short? RMALIne,
		string SerialPrefix,
		decimal? RMAReturnQty,
		decimal? SerialGenQty,
		string Whse,
		string Loc,
		string Lot,
		string UnRecvLoc,
		string UnRecvLot,
		string StartSerNum,
		byte? GenerateFlag)
		{
			RmaNumType _RMANum = RMANum;
			RmaLineType _RMALIne = RMALIne;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			QtyUnitType _RMAReturnQty = RMAReturnQty;
			QtyUnitType _SerialGenQty = SerialGenQty;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			LocType _UnRecvLoc = UnRecvLoc;
			LotType _UnRecvLot = UnRecvLot;
			SerNumType _StartSerNum = StartSerNum;
			ListYesNoType _GenerateFlag = GenerateFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_RMAReturnSerialLoadSp";
				
				appDB.AddCommandParameter(cmd, "RMANum", _RMANum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALIne", _RMALIne, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMAReturnQty", _RMAReturnQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialGenQty", _SerialGenQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnRecvLoc", _UnRecvLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnRecvLot", _UnRecvLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateFlag", _GenerateFlag, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
