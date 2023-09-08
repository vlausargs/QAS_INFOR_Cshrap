//PROJECT NAME: Material
//CLASS NAME: CLM_GetCurrentSearchItemCategories.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CLM_GetCurrentSearchItemCategories : ICLM_GetCurrentSearchItemCategories
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetCurrentSearchItemCategories(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCurrentSearchItemCategoriesSp(int? ChildCategoriesOnly,
		Guid? RowPointer,
		int? RecordCap,
		string FilterString)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _ChildCategoriesOnly = ChildCategoriesOnly;
				RowPointerType _RowPointer = RowPointer;
				IntType _RecordCap = RecordCap;
				StringType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GetCurrentSearchItemCategoriesSp";
					
					appDB.AddCommandParameter(cmd, "ChildCategoriesOnly", _ChildCategoriesOnly, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
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
