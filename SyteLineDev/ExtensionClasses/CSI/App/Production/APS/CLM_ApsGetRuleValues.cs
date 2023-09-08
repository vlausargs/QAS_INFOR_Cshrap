//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetRuleValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRuleValues
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRuleValuesSp(short? PRuleType,
		string RuleValueFilter = null);
	}
	
	public class CLM_ApsGetRuleValues : ICLM_ApsGetRuleValues
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetRuleValues(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRuleValuesSp(short? PRuleType,
		string RuleValueFilter = null)
		{
			ApsSmallIntType _PRuleType = PRuleType;
			LongListType _RuleValueFilter = RuleValueFilter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ApsGetRuleValuesSp";
				
				appDB.AddCommandParameter(cmd, "PRuleType", _PRuleType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RuleValueFilter", _RuleValueFilter, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
