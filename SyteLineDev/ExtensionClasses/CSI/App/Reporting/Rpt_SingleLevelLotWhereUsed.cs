//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SingleLevelLotWhereUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SingleLevelLotWhereUsed : IRpt_SingleLevelLotWhereUsed
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SingleLevelLotWhereUsed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SingleLevelLotWhereUsedSp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingLot = null,
		string PEndingLot = null,
		int? PSortBy = 1,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			LotType _PStartingLot = PStartingLot;
			LotType _PEndingLot = PEndingLot;
			ListYesNoType _PSortBy = PSortBy;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SingleLevelLotWhereUsedSp";
				
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingLot", _PStartingLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingLot", _PEndingLot, ParameterDirection.Input);
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
