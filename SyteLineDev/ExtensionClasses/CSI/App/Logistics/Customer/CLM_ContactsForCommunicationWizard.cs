//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ContactsForCommunicationWizard.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ContactsForCommunicationWizard
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ContactsForCommunicationWizardSp(string SourceType,
		string SourceKey,
		string CommMethod,
		string CommType,
		string FilterString = null);
	}
	
	public class CLM_ContactsForCommunicationWizard : ICLM_ContactsForCommunicationWizard
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ContactsForCommunicationWizard(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ContactsForCommunicationWizardSp(string SourceType,
		string SourceKey,
		string CommMethod,
		string CommType,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _SourceType = SourceType;
				StringType _SourceKey = SourceKey;
				StringType _CommMethod = CommMethod;
				StringType _CommType = CommType;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ContactsForCommunicationWizardSp";
					
					appDB.AddCommandParameter(cmd, "SourceType", _SourceType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SourceKey", _SourceKey, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CommMethod", _CommMethod, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CommType", _CommType, ParameterDirection.Input);
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
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
