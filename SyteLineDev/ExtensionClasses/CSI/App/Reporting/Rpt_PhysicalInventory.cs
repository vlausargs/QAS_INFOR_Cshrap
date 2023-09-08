//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PhysicalInventory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PhysicalInventory : IRpt_PhysicalInventory
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PhysicalInventory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PhysicalInventorySp(int? PQuantityZeroOnly = 0,
		string PProductCode = null,
		string PPlannerCode = null,
		string PWhse = null,
		string PSortBy = "I",
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			ListYesNoType _PQuantityZeroOnly = PQuantityZeroOnly;
			ProductCodeType _PProductCode = PProductCode;
			UserCodeType _PPlannerCode = PPlannerCode;
			WhseType _PWhse = PWhse;
			Infobar _PSortBy = PSortBy;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PhysicalInventorySp";
				
				appDB.AddCommandParameter(cmd, "PQuantityZeroOnly", _PQuantityZeroOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProductCode", _PProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlannerCode", _PPlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortBy", _PSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
