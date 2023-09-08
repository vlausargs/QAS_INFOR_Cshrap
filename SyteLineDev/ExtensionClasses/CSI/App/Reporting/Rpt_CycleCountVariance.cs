//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CycleCountVariance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CycleCountVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CycleCountVarianceSp(string ABCCode = null,
		string SortBy = null,
		byte? ShowOnlyItemWithVar = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = (byte)1,
		string ForWhse = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_CycleCountVariance : IRpt_CycleCountVariance
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CycleCountVariance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CycleCountVarianceSp(string ABCCode = null,
		string SortBy = null,
		byte? ShowOnlyItemWithVar = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = (byte)1,
		string ForWhse = null,
		string BGSessionId = null,
		string pSite = null)
		{
			InfobarType _ABCCode = ABCCode;
			InfobarType _SortBy = SortBy;
			ListYesNoType _ShowOnlyItemWithVar = ShowOnlyItemWithVar;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			UserCodeType _PlanCodeStarting = PlanCodeStarting;
			UserCodeType _PlanCodeEnding = PlanCodeEnding;
			ListYesNoType _PrintCost = PrintCost;
			FlagNyType _DisplayHeader = DisplayHeader;
			WhseType _ForWhse = ForWhse;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CycleCountVarianceSp";
				
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowOnlyItemWithVar", _ShowOnlyItemWithVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeStarting", _PlanCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeEnding", _PlanCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForWhse", _ForWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
