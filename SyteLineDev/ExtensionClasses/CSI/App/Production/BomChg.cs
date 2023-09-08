//PROJECT NAME: Production
//CLASS NAME: BomChg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IBomChg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) BomChgSp(string PProcess,
		string PMfgType,
		DateTime? PEffDate,
		string PFromItem,
		string PToItem,
		string PFromMaterialType,
		string PToMaterialType,
		decimal? PFromQty,
		decimal? PToQty,
		string PFromUnits,
		string PToUnits,
		string PFromUM,
		string PToUM,
		decimal? PFromScrapFactor,
		decimal? PToScrapFactor,
		string PFromRefType,
		string PToRefType,
		short? EffectDateOffset = null,
		Guid? PJobmatlRowPointer = null);
	}
	
	public class BomChg : IBomChg
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public BomChg(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) BomChgSp(string PProcess,
		string PMfgType,
		DateTime? PEffDate,
		string PFromItem,
		string PToItem,
		string PFromMaterialType,
		string PToMaterialType,
		decimal? PFromQty,
		decimal? PToQty,
		string PFromUnits,
		string PToUnits,
		string PFromUM,
		string PToUM,
		decimal? PFromScrapFactor,
		decimal? PToScrapFactor,
		string PFromRefType,
		string PToRefType,
		short? EffectDateOffset = null,
		Guid? PJobmatlRowPointer = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _PProcess = PProcess;
				LongListType _PMfgType = PMfgType;
				DateType _PEffDate = PEffDate;
				ItemType _PFromItem = PFromItem;
				ItemType _PToItem = PToItem;
				MatlTypeType _PFromMaterialType = PFromMaterialType;
				MatlTypeType _PToMaterialType = PToMaterialType;
				QtyPerType _PFromQty = PFromQty;
				QtyPerType _PToQty = PToQty;
				JobmatlUnitsType _PFromUnits = PFromUnits;
				JobmatlUnitsType _PToUnits = PToUnits;
				UMType _PFromUM = PFromUM;
				UMType _PToUM = PToUM;
				ScrapFactorType _PFromScrapFactor = PFromScrapFactor;
				ScrapFactorType _PToScrapFactor = PToScrapFactor;
				RefTypeIJKPRTType _PFromRefType = PFromRefType;
				RefTypeIJKPRTType _PToRefType = PToRefType;
				DateOffsetType _EffectDateOffset = EffectDateOffset;
				RowPointerType _PJobmatlRowPointer = PJobmatlRowPointer;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "BomChgSp";
					
					appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PMfgType", _PMfgType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEffDate", _PEffDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromItem", _PFromItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToItem", _PToItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromMaterialType", _PFromMaterialType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToMaterialType", _PToMaterialType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromQty", _PFromQty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToQty", _PToQty, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromUnits", _PFromUnits, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToUnits", _PToUnits, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromUM", _PFromUM, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToUM", _PToUM, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromScrapFactor", _PFromScrapFactor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToScrapFactor", _PToScrapFactor, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PFromRefType", _PFromRefType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PToRefType", _PToRefType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EffectDateOffset", _EffectDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PJobmatlRowPointer", _PJobmatlRowPointer, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
