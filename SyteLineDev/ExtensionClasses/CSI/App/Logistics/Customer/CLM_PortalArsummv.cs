//PROJECT NAME: Logistics
//CLASS NAME: CLM_PortalArsummv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_PortalArsummv : ICLM_PortalArsummv
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PortalArsummv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string PDisplayType,
		DateTime? PFromDate,
		DateTime? PToDate)
		{
			CustNumType _PCustNum = PCustNum;
			ListYesNoType _PCurrentSite = PCurrentSite;
			ListYesNoType _PSubordinate = PSubordinate;
			ListYesNoType _PActive = PActive;
			StringType _PDisplayType = PDisplayType;
			DateType _PFromDate = PFromDate;
			DateType _PToDate = PToDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_PortalArsummvSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrentSite", _PCurrentSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PActive", _PActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayType", _PDisplayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromDate", _PFromDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToDate", _PToDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
