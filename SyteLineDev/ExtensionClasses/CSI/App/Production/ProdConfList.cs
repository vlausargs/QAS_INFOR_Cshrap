//PROJECT NAME: Production
//CLASS NAME: ProdConfList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ProdConfList : IProdConfList
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProdConfList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProdConfListSp(string FeatStr,
		string Item,
		string CoNum,
		int? CoLine,
		int? Level,
		string Site = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FeatStrType _FeatStr = FeatStr;
				ItemType _Item = Item;
				CoNumType _CoNum = CoNum;
				CoLineType _CoLine = CoLine;
				IntType _Level = Level;
				SiteType _Site = Site;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ProdConfListSp";
					
					appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
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
