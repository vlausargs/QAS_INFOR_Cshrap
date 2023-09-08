//PROJECT NAME: Production
//CLASS NAME: PP_CLM_OperationTypeFormulas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_CLM_OperationTypeFormulas : IPP_CLM_OperationTypeFormulas
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PP_CLM_OperationTypeFormulas(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PP_CLM_OperationTypeFormulasSp(string CollectionName,
		string OperationType = null,
		int? IncludeKeySequence = 0)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _CollectionName = CollectionName;
				PP_OperationType2Type _OperationType = OperationType;
				ListYesNoType _IncludeKeySequence = IncludeKeySequence;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PP_CLM_OperationTypeFormulasSp";
					
					appDB.AddCommandParameter(cmd, "CollectionName", _CollectionName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "OperationType", _OperationType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IncludeKeySequence", _IncludeKeySequence, ParameterDirection.Input);
					
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
