//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SummarizedCurrentBillOfMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SummarizedCurrentBillOfMaterial : IRpt_SummarizedCurrentBillOfMaterial
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SummarizedCurrentBillOfMaterial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SummarizedCurrentBillOfMaterialSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string MaterialType = null,
		string Source = null,
		string Shocked = null,
		string ABCCode = null,
		DateTime? EffectiveDate = null,
		int? PageBetweenItems = null,
		int? PrintOnlyZeroLevelItems = null,
		int? EffectiveDateOffset = null,
		int? DisplayHeader = null,
		int? PrintCost = 0,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			InfobarType _MaterialType = MaterialType;
			InfobarType _Source = Source;
			InfobarType _Shocked = Shocked;
			InfobarType _ABCCode = ABCCode;
			DateType _EffectiveDate = EffectiveDate;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			ListYesNoType _PrintOnlyZeroLevelItems = PrintOnlyZeroLevelItems;
			DateOffsetType _EffectiveDateOffset = EffectiveDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintCost = PrintCost;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SummarizedCurrentBillOfMaterialSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shocked", _Shocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOnlyZeroLevelItems", _PrintOnlyZeroLevelItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOffset", _EffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
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
