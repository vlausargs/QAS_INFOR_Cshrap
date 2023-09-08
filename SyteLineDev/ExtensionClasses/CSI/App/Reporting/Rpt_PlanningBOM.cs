//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PlanningBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PlanningBOM : IRpt_PlanningBOM
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PlanningBOM(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PlanningBOMSP(string ItemStarting,
		string ItemEnding,
		string ProductCodeStarting,
		string ProductCodeEnding,
		string MaterialType,
		string ABCCode,
		DateTime? EffectiveDate,
		int? EffectiveDateOffset = null,
		int? IndentedLevelView = null,
		int? PageBetweenItems = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			HighLowCharType _ProductCodeStarting = ProductCodeStarting;
			HighLowCharType _ProductCodeEnding = ProductCodeEnding;
			LongListType _MaterialType = MaterialType;
			LongListType _ABCCode = ABCCode;
			GenericDateType _EffectiveDate = EffectiveDate;
			DateOffsetType _EffectiveDateOffset = EffectiveDateOffset;
			FlagNyType _IndentedLevelView = IndentedLevelView;
			FlagNyType _PageBetweenItems = PageBetweenItems;
			FlagNyType _ShowPrice = ShowPrice;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PlanningBOMSP";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOffset", _EffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndentedLevelView", _IndentedLevelView, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPrice", _ShowPrice, ParameterDirection.Input);
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
