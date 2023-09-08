//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_CoItemsBookingsbyTerritory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ICLM_CoItemsBookingsbyTerritory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CoItemsBookingsbyTerritorySp(string TerritoryCode = null,
		int? StartYear = null,
		int? EndYear = null,
		int? StartPeriod = null,
		int? EndPeriod = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null);
	}
	
	public class CLM_CoItemsBookingsbyTerritory : ICLM_CoItemsBookingsbyTerritory
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CoItemsBookingsbyTerritory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CoItemsBookingsbyTerritorySp(string TerritoryCode = null,
		int? StartYear = null,
		int? EndYear = null,
		int? StartPeriod = null,
		int? EndPeriod = null,
		int? PageNum = null,
		int? EntriesPerPage = null,
		string SiteRef = null)
		{
			TerritoryCodeType _TerritoryCode = TerritoryCode;
			IntType _StartYear = StartYear;
			IntType _EndYear = EndYear;
			IntType _StartPeriod = StartPeriod;
			IntType _EndPeriod = EndPeriod;
			IntType _PageNum = PageNum;
			IntType _EntriesPerPage = EntriesPerPage;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_CoItemsBookingsbyTerritorySp";
				
				appDB.AddCommandParameter(cmd, "TerritoryCode", _TerritoryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartYear", _StartYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndYear", _EndYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPeriod", _StartPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageNum", _PageNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntriesPerPage", _EntriesPerPage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
