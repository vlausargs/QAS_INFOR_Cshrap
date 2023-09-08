//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SingleLevelCurrentBillOfMaterial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SingleLevelCurrentBillOfMaterial : IRpt_SingleLevelCurrentBillOfMaterial
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SingleLevelCurrentBillOfMaterial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SingleLevelCurrentBillOfMaterialSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string AlternateIDStarting = null,
		string AlternateIDEnding = null,
		string MaterialType = null,
		string Source = null,
		string Shocked = null,
		string ABCCode = null,
		int? ShowCost = null,
		int? DisplayReferenceFields = null,
		int? PageBetweenItems = null,
		int? PrintAlternate = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			MO_BOMAlternateType _AlternateIDStarting = AlternateIDStarting;
			MO_BOMAlternateType _AlternateIDEnding = AlternateIDEnding;
			InfobarType _MaterialType = MaterialType;
			InfobarType _Source = Source;
			InfobarType _Shocked = Shocked;
			InfobarType _ABCCode = ABCCode;
			ListYesNoType _ShowCost = ShowCost;
			ListYesNoType _DisplayReferenceFields = DisplayReferenceFields;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			ListYesNoType _PrintAlternate = PrintAlternate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SingleLevelCurrentBillOfMaterialSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateIDStarting", _AlternateIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateIDEnding", _AlternateIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shocked", _Shocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowCost", _ShowCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReferenceFields", _DisplayReferenceFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAlternate", _PrintAlternate, ParameterDirection.Input);
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
