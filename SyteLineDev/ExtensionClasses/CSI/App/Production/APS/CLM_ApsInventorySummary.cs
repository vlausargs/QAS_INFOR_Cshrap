//PROJECT NAME: Production
//CLASS NAME: CLM_ApsInventorySummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsInventorySummary : ICLM_ApsInventorySummary
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsInventorySummary(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsInventorySummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string FilterString,
		int? AltNo)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateType _PStartDate = PStartDate;
				DateType _PEndDate = PEndDate;
				LongListType _FilterString = FilterString;
				ApsAltNoType _AltNo = AltNo;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsInventorySummarySp";
					
					appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					
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
