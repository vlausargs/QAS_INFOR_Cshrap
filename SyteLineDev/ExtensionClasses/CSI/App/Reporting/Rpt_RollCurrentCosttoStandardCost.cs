//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RollCurrentCosttoStandardCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RollCurrentCosttoStandardCost : IRpt_RollCurrentCosttoStandardCost
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RollCurrentCosttoStandardCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RollCurrentCosttoStandardCostSp(string Post = null,
		string FromProductCode = null,
		string ToProductCode = null,
		string FromItem = null,
		string ToItem = null,
		string FromWarehouse = null,
		string ToWarehouse = null,
		string Source = null,
		string ABC = null,
		string CostMethod = null,
		string MatlType = null,
		int? DisplayHeader = null,
		decimal? UserID = null,
		string BGSessionId = null,
		string pSite = null,
        int? DebugLevel = null,
        int? TaskId = null,
        int? CommitSize = null)
		{
			LongListType _Post = Post;
			ProductCodeType _FromProductCode = FromProductCode;
			ProductCodeType _ToProductCode = ToProductCode;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			WhseType _FromWarehouse = FromWarehouse;
			WhseType _ToWarehouse = ToWarehouse;
			LongListType _Source = Source;
			LongListType _ABC = ABC;
			LongListType _CostMethod = CostMethod;
			LongListType _MatlType = MatlType;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TokenType _UserID = UserID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
            GenericIntType _DebugLevel = DebugLevel;
            TaskNumType _TaskId = TaskId;
            GenericIntType _CommitSize = CommitSize;

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RollCurrentCosttoStandardCostSp";
				
				appDB.AddCommandParameter(cmd, "Post", _Post, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWarehouse", _FromWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWarehouse", _ToWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABC", _ABC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DebugLevel", _DebugLevel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CommitSize", _CommitSize, ParameterDirection.Input);

                IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);

				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();

				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
