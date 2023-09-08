//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerPriceChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CustomerPriceChange : IRpt_CustomerPriceChange
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CustomerPriceChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		DateTime? FromEffectDate,
		DateTime? ToEffectDate,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? NewEffectDate,
		int? UpdateCreate = 0,
		int? DisplayHeader = 0,
		string AmtType = "A",
		decimal? PriAmt = 0,
		string FromCurrCode = null,
		string ToCurrCode = null,
		string pSite = null)
		{
			ProductCodeType _FromProductCode = FromProductCode;
			ProductCodeType _ToProductCode = ToProductCode;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			DateType _FromEffectDate = FromEffectDate;
			DateType _ToEffectDate = ToEffectDate;
			CustNumType _FromCustNum = FromCustNum;
			CustNumType _ToCustNum = ToCustNum;
			CustTypeType _FromCustType = FromCustType;
			CustTypeType _ToCustType = ToCustType;
			EndUserTypeType _FromEndUserType = FromEndUserType;
			EndUserTypeType _ToEndUserType = ToEndUserType;
			DateType _NewEffectDate = NewEffectDate;
			ListYesNoType _UpdateCreate = UpdateCreate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListAmountPercentType _AmtType = AmtType;
			CostPrcType _PriAmt = PriAmt;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CustomerPriceChangeSp";
				
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEffectDate", _FromEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEffectDate", _ToEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCustNum", _FromCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustNum", _ToCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCustType", _FromCustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustType", _ToCustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEndUserType", _FromEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEndUserType", _ToEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewEffectDate", _NewEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateCreate", _UpdateCreate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtType", _AmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriAmt", _PriAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
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
