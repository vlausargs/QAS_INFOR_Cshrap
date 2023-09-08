//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_LoadJournal
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadJournalSp(string Id,
		DateTime? TransDate,
		string FilterString = null);
	}
	
	public class CHSCLM_LoadJournal : ICHSCLM_LoadJournal
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSCLM_LoadJournal(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadJournalSp(string Id,
		DateTime? TransDate,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				JournalIdType _Id = Id;
				DateType _TransDate = TransDate;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CHSCLM_LoadJournalSp";
					
					appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
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
