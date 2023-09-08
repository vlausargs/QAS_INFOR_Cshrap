//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricDSO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricDSO
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricDSOSp(byte? MultipleSites = (byte)0,
		string SiteGroup = null,
		int? NumPeriods = 6);
	}
	
	public class Home_MetricDSO : IHome_MetricDSO
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_MetricDSO(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Home_MetricDSOSp(byte? MultipleSites = (byte)0,
		string SiteGroup = null,
		int? NumPeriods = 6)
		{
			ListYesNoType _MultipleSites = MultipleSites;
			SiteGroupType _SiteGroup = SiteGroup;
			IntType _NumPeriods = NumPeriods;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_MetricDSOSp";
				
				appDB.AddCommandParameter(cmd, "MultipleSites", _MultipleSites, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumPeriods", _NumPeriods, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
