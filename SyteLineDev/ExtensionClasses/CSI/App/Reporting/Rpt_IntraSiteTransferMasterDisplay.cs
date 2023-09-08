//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IntraSiteTransferMasterDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_IntraSiteTransferMasterDisplay
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IntraSiteTransferMasterDisplaySp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		byte? MPSItemsOnly = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_IntraSiteTransferMasterDisplay : IRpt_IntraSiteTransferMasterDisplay
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_IntraSiteTransferMasterDisplay(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_IntraSiteTransferMasterDisplaySp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		byte? MPSItemsOnly = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			ListYesNoType _MPSItemsOnly = MPSItemsOnly;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_IntraSiteTransferMasterDisplaySp";
				
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MPSItemsOnly", _MPSItemsOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
