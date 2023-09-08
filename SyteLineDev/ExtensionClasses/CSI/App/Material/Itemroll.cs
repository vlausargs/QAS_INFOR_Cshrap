//PROJECT NAME: CSIMaterial
//CLASS NAME: Itemroll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemroll
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemrollSp(byte? ListOpts,
		DateTime? EffectDate,
		byte? ResetByProdCost,
		byte? UseStdCost,
		string Infobar,
		short? EffectDateOffset = null,
		byte? ProcessObsoleteItems = null,
		byte? ProcessSlowMovingItems = null);
	}
	
	public class Itemroll : IItemroll
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Itemroll(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ItemrollSp(byte? ListOpts,
		DateTime? EffectDate,
		byte? ResetByProdCost,
		byte? UseStdCost,
		string Infobar,
		short? EffectDateOffset = null,
		byte? ProcessObsoleteItems = null,
		byte? ProcessSlowMovingItems = null)
		{
			ListYesNoType _ListOpts = ListOpts;
			DateType _EffectDate = EffectDate;
			ListYesNoType _ResetByProdCost = ResetByProdCost;
			ListYesNoType _UseStdCost = UseStdCost;
			InfobarType _Infobar = Infobar;
			DateOffsetType _EffectDateOffset = EffectDateOffset;
			ListYesNoType _ProcessObsoleteItems = ProcessObsoleteItems;
			ListYesNoType _ProcessSlowMovingItems = ProcessSlowMovingItems;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemrollSp";
				
				appDB.AddCommandParameter(cmd, "ListOpts", _ListOpts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetByProdCost", _ResetByProdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseStdCost", _UseStdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDateOffset", _EffectDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessObsoleteItems", _ProcessObsoleteItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSlowMovingItems", _ProcessSlowMovingItems, ParameterDirection.Input);
				
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
