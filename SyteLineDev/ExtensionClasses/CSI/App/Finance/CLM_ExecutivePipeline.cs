//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ExecutivePipeline.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICLM_ExecutivePipeline
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutivePipelineSp(string ViewBy,
		int? Detail,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null);
	}
	
	public class CLM_ExecutivePipeline : ICLM_ExecutivePipeline
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ExecutivePipeline(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutivePipelineSp(string ViewBy,
		int? Detail,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _ViewBy = ViewBy;
				IntType _Detail = Detail;
				DateType _DateStarting = DateStarting;
				DateType _DateEnding = DateEnding;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ExecutivePipelineSp";
					
					appDB.AddCommandParameter(cmd, "ViewBy", _ViewBy, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Detail", _Detail, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
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
