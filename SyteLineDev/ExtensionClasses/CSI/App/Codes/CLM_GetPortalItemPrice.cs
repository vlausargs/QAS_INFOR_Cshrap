//PROJECT NAME: Codes
//CLASS NAME: CLM_GetPortalItemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CLM_GetPortalItemPrice : ICLM_GetPortalItemPrice
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetPortalItemPrice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetPortalItemPriceSp(string ItemRange,
		string ItemPricingSite,
		string CustNum,
		string ResellerCustNum,
		string CurrCode,
		int? IsB2B,
		string Infobar)
		{
			StringType _ItemRange = ItemRange;
			StringType _ItemPricingSite = ItemPricingSite;
			CustNumType _CustNum = CustNum;
			CustNumType _ResellerCustNum = ResellerCustNum;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _IsB2B = IsB2B;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetPortalItemPriceSp";
				
				appDB.AddCommandParameter(cmd, "ItemRange", _ItemRange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPricingSite", _ItemPricingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCustNum", _ResellerCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsB2B", _IsB2B, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
