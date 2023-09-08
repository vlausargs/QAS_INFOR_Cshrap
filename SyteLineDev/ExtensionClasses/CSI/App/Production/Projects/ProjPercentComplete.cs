//PROJECT NAME: Production
//CLASS NAME: ProjPercentComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjPercentComplete : IProjPercentComplete
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProjPercentComplete(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, decimal? CostToComplete) ProjPercentCompleteSp(string ProjNum,
		int? FromRpt = 0,
		string CostCodeType = "P",
		decimal? CostToComplete = null)
		{
			ProjNumType _ProjNum = ProjNum;
			IntType _FromRpt = FromRpt;
			CostCodeTypeType _CostCodeType = CostCodeType;
			AmountType _CostToComplete = CostToComplete;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjPercentCompleteSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRpt", _FromRpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostToComplete", _CostToComplete, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				CostToComplete = _CostToComplete;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, CostToComplete);
			}
		}
	}
}
