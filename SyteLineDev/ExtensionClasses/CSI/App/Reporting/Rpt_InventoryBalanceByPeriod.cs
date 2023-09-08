//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBalanceByPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_InventoryBalanceByPeriod : IRpt_InventoryBalanceByPeriod
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InventoryBalanceByPeriod(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryBalanceByPeriodSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeENDing = null,
		string PlanCodeStarting = null,
		string PlanCodeENDing = null,
		string MaterialType = null,
		string Source = null,
		string pStocked = null,
		string ABCCode = null,
		int? ExcludeZeroNetRequirements = null,
		int? IncludeTransfers = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeENDing = ProductCodeENDing;
			UserCodeType _PlanCodeStarting = PlanCodeStarting;
			UserCodeType _PlanCodeENDing = PlanCodeENDing;
			InfobarType _MaterialType = MaterialType;
			InfobarType _Source = Source;
			InfobarType _pStocked = pStocked;
			InfobarType _ABCCode = ABCCode;
			ListYesNoType _ExcludeZeroNetRequirements = ExcludeZeroNetRequirements;
			ListYesNoType _IncludeTransfers = IncludeTransfers;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InventoryBalanceByPeriodSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeENDing", _ProductCodeENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeStarting", _PlanCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeENDing", _PlanCodeENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStocked", _pStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeZeroNetRequirements", _ExcludeZeroNetRequirements, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTransfers", _IncludeTransfers, ParameterDirection.Input);
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
