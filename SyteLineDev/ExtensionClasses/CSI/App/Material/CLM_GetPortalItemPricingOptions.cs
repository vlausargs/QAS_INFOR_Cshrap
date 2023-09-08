//PROJECT NAME: Material
//CLASS NAME: CLM_GetPortalItemPricingOptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CLM_GetPortalItemPricingOptions : ICLM_GetPortalItemPricingOptions
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetPortalItemPricingOptions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetPortalItemPricingOptionsSp(string Item,
		string CustNum,
		int? B2BPricingOptions,
		string CurrCode,
		string PrimarySite,
		string ResellerSlsman,
		string PricingPrecalculationRule,
		int? GenericIfNoCustSpecific,
		string ShipFromSite,
		string LCID,
		string Infobar)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			ListYesNoType _B2BPricingOptions = B2BPricingOptions;
			CurrCodeType _CurrCode = CurrCode;
			SiteType _PrimarySite = PrimarySite;
			SlsmanType _ResellerSlsman = ResellerSlsman;
			PricingPrecalculationRuleType _PricingPrecalculationRule = PricingPrecalculationRule;
			ListYesNoType _GenericIfNoCustSpecific = GenericIfNoCustSpecific;
			SiteType _ShipFromSite = ShipFromSite;
			LanguageIDType _LCID = LCID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetPortalItemPricingOptionsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "B2BPricingOptions", _B2BPricingOptions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarySite", _PrimarySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerSlsman", _ResellerSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricingPrecalculationRule", _PricingPrecalculationRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenericIfNoCustSpecific", _GenericIfNoCustSpecific, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipFromSite", _ShipFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LCID", _LCID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
