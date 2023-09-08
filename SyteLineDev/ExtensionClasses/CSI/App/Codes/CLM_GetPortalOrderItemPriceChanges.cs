//PROJECT NAME: Codes
//CLASS NAME: CLM_GetPortalOrderItemPriceChanges.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CLM_GetPortalOrderItemPriceChanges : ICLM_GetPortalOrderItemPriceChanges
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetPortalOrderItemPriceChanges(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetPortalOrderItemPriceChangesSp(string CoNum,
		string CurrCode,
		string PrimarySite,
		string ResellerSlsman,
		string PricingPrecalculationRule,
		int? GenericIfNoCustSpecific,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CurrCodeType _CurrCode = CurrCode;
			SiteType _PrimarySite = PrimarySite;
			SlsmanType _ResellerSlsman = ResellerSlsman;
			PricingPrecalculationRuleType _PricingPrecalculationRule = PricingPrecalculationRule;
			ListYesNoType _GenericIfNoCustSpecific = GenericIfNoCustSpecific;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetPortalOrderItemPriceChangesSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarySite", _PrimarySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerSlsman", _ResellerSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricingPrecalculationRule", _PricingPrecalculationRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenericIfNoCustSpecific", _GenericIfNoCustSpecific, ParameterDirection.Input);
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
