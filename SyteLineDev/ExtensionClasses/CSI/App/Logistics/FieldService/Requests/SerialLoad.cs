//PROJECT NAME: Logistics
//CLASS NAME: SerialLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SerialLoad : ISerialLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SerialLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SerialLoadSp(string SerialLike,
		string TransType,
		string WhseType,
		string Stat,
		int? RestoreLoss = 0,
		int? JmtRETURN = 0,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string DoNum = null,
		int? DoLine = 0,
		string TrnNum = null,
		int? TrnLine = 0,
		decimal? RsvdNum = 0,
		string RefNum = null,
		int? RefLine = 0,
		int? RefRelease = 0,
		string Site = null,
		string ImportDocId = null,
		int? PreassignSerials = null,
		string ContainerNum = null,
		string StartingSerial = null,
		string EndingSerial = null,
		string TrcTrans = null)
		{
			StringType _SerialLike = SerialLike;
			StringType _TransType = TransType;
			StringType _WhseType = WhseType;
			SerialStatusType _Stat = Stat;
			ListYesNoType _RestoreLoss = RestoreLoss;
			ListYesNoType _JmtRETURN = JmtRETURN;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			DoNumType _DoNum = DoNum;
			DoLineType _DoLine = DoLine;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			RsvdNumType _RsvdNum = RsvdNum;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoReleaseType _RefRelease = RefRelease;
			SiteType _Site = Site;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _PreassignSerials = PreassignSerials;
			ContainerNumType _ContainerNum = ContainerNum;
			SerNumType _StartingSerial = StartingSerial;
			SerNumType _EndingSerial = EndingSerial;
			MatlTransTypeType _TrcTrans = TrcTrans;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SerialLoadSp";
				
				appDB.AddCommandParameter(cmd, "SerialLike", _SerialLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseType", _WhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RestoreLoss", _RestoreLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JmtRETURN", _JmtRETURN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdNum", _RsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSerial", _StartingSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSerial", _EndingSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrcTrans", _TrcTrans, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
