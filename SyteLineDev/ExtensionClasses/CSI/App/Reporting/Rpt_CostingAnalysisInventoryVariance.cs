//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostingAnalysisInventoryVariance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CostingAnalysisInventoryVariance : IRpt_CostingAnalysisInventoryVariance
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CostingAnalysisInventoryVariance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CostingAnalysisInventoryVarianceSp(string CostingAlt,
		string CostingAltVersus,
		string BOMTypeVersus,
		string WhseVersus = null,
		string PMTCode = null,
		string ABCCode = null,
		string CostMethod = null,
		string MatlType = null,
		int? GroupByProdCode = null,
		int? DisplayHeader = null,
		string ProdCodeStarting = null,
		string ProdCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string pSite = null)
		{
			CostingAlternativeType _CostingAlt = CostingAlt;
			CostingAlternativeType _CostingAltVersus = CostingAltVersus;
			CostTypeType _BOMTypeVersus = BOMTypeVersus;
			WhseType _WhseVersus = WhseVersus;
			StringType _PMTCode = PMTCode;
			StringType _ABCCode = ABCCode;
			StringType _CostMethod = CostMethod;
			StringType _MatlType = MatlType;
			ListYesNoType _GroupByProdCode = GroupByProdCode;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ProductCodeType _ProdCodeStarting = ProdCodeStarting;
			ProductCodeType _ProdCodeEnding = ProdCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CostingAnalysisInventoryVarianceSp";
				
				appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostingAltVersus", _CostingAltVersus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMTypeVersus", _BOMTypeVersus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseVersus", _WhseVersus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupByProdCode", _GroupByProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCodeStarting", _ProdCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCodeEnding", _ProdCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
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
