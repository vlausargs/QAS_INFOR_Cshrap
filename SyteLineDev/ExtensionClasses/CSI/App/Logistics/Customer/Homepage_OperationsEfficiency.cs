//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_OperationsEfficiency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_OperationsEfficiency
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_OperationsEfficiencySp(DateTime? StartTrxDate = null,
		DateTime? EndtrxDate = null,
		string StartJob = null,
		string EndJob = null,
		string SiteGroup = null);
	}
	
	public class Homepage_OperationsEfficiency : IHomepage_OperationsEfficiency
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Homepage_OperationsEfficiency(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_OperationsEfficiencySp(DateTime? StartTrxDate = null,
		DateTime? EndtrxDate = null,
		string StartJob = null,
		string EndJob = null,
		string SiteGroup = null)
		{
			DateType _StartTrxDate = StartTrxDate;
			DateType _EndtrxDate = EndtrxDate;
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SiteGroupType _SiteGroup = SiteGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_OperationsEfficiencySp";
				
				appDB.AddCommandParameter(cmd, "StartTrxDate", _StartTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndtrxDate", _EndtrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
