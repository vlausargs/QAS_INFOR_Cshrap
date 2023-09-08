//PROJECT NAME: Production
//CLASS NAME: AU_CLM_QAProcessRefGetValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Automotive
{
	public interface IAU_CLM_QAProcessRefGetValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_CLM_QAProcessRefGetValueSp(string RefType = null,
		string RefNum = null,
		string RefName = null);
	}
	
	public class AU_CLM_QAProcessRefGetValue : IAU_CLM_QAProcessRefGetValue
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public AU_CLM_QAProcessRefGetValue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) AU_CLM_QAProcessRefGetValueSp(string RefType = null,
		string RefNum = null,
		string RefName = null)
		{
			RefTypeIJKOPRSTWType _RefType = RefType;
			ReferenceType _RefNum = RefNum;
			NameType _RefName = RefName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CLM_QAProcessRefGetValueSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefName", _RefName, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
