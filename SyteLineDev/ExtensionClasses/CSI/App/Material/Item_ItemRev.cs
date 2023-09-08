//PROJECT NAME: Material
//CLASS NAME: Item_ItemRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Item_ItemRev : IItem_ItemRev
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Item_ItemRev(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Item_ItemRevSp(string sTreeFilter,
		string sStartingRevision,
		string sEndingRevision,
		int? sAlternateFilter = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _sTreeFilter = sTreeFilter;
				StringType _sStartingRevision = sStartingRevision;
				StringType _sEndingRevision = sEndingRevision;
				ListYesNoType _sAlternateFilter = sAlternateFilter;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "Item_ItemRevSp";
					
					appDB.AddCommandParameter(cmd, "sTreeFilter", _sTreeFilter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "sStartingRevision", _sStartingRevision, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "sEndingRevision", _sEndingRevision, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "sAlternateFilter", _sAlternateFilter, ParameterDirection.Input);
					
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
