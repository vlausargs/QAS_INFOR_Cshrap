//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrderPriceChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CustomerOrderPriceChange : IRpt_CustomerOrderPriceChange
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CustomerOrderPriceChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrderPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		string FromCurrCode,
		string ToCurrCode,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? FromDueDate,
		DateTime? ToDueDate,
		int? DisplayHeader = 0,
		string AmtType = "A",
		decimal? PriAmt = 0,
		string pSite = null)
		{
			ProductCodeType _FromProductCode = FromProductCode;
			ProductCodeType _ToProductCode = ToProductCode;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			CustNumType _FromCustNum = FromCustNum;
			CustNumType _ToCustNum = ToCustNum;
			CustTypeType _FromCustType = FromCustType;
			CustTypeType _ToCustType = ToCustType;
			EndUserTypeType _FromEndUserType = FromEndUserType;
			EndUserTypeType _ToEndUserType = ToEndUserType;
			DateType _FromDueDate = FromDueDate;
			DateType _ToDueDate = ToDueDate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListAmountPercentType _AmtType = AmtType;
			CostPrcType _PriAmt = PriAmt;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CustomerOrderPriceChangeSp";
				
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCustNum", _FromCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustNum", _ToCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCustType", _FromCustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustType", _ToCustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEndUserType", _FromEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEndUserType", _ToEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDueDate", _FromDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDueDate", _ToDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtType", _AmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriAmt", _PriAmt, ParameterDirection.Input);
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
