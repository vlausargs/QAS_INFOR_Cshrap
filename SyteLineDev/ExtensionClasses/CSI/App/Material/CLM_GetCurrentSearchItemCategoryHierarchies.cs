//PROJECT NAME: Material
//CLASS NAME: CLM_GetCurrentSearchItemCategoryHierarchies.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CLM_GetCurrentSearchItemCategoryHierarchies : ICLM_GetCurrentSearchItemCategoryHierarchies
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetCurrentSearchItemCategoryHierarchies(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCurrentSearchItemCategoryHierarchiesSp(string Criteria,
		string CriterionTypes,
		int? LocaleID,
		Guid? SessionId,
		Guid? CatalogRowPointer)
		{
			StringType _Criteria = Criteria;
			StringType _CriterionTypes = CriterionTypes;
			GenericIntType _LocaleID = LocaleID;
			RowPointerType _SessionId = SessionId;
			RowPointerType _CatalogRowPointer = CatalogRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetCurrentSearchItemCategoryHierarchiesSp";
				
				appDB.AddCommandParameter(cmd, "Criteria", _Criteria, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CriterionTypes", _CriterionTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleID", _LocaleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CatalogRowPointer", _CatalogRowPointer, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
