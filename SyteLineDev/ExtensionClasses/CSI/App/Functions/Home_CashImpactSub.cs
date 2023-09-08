//PROJECT NAME: Data
//CLASS NAME: Home_CashImpactSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_CashImpactSub : IHome_CashImpactSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_CashImpactSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Home_CashImpactSubSp(
			string SummaryOrDetail = null,
			string InclARTrxAPTrxOrBoth = null,
			string InclCOPOOrBoth = null,
			int? InclPORequisitions = null,
			int? InclCOBlanketReleases = null,
			int? InclPOBlanketReleases = null,
			int? InclCOProgresiveBilling = null,
			string CreditHold = null,
			int? InclEstimateOrders = null,
			int? EstimateOrderOffsetDay = null,
			int? InclAREarlyPayDiscounts = null,
			int? InclAPEarlyPayDiscounts = null,
			string CustomerPaymentsBasis = null,
			int? NumberOfDaysLookback = null,
			int? TranslateToDomesticCurrency = null,
			string StartingCurrencyCode = null,
			string EndingCurrencyCode = null,
			string PaymentHold = null,
			string EstimateStatus = null,
			int? NumberOfDaysPerColumn = null,
			int? UseHistoricalCurrencyRate = null,
			int? DisplayHeader = null,
			int? TaskId = null)
		{
			Infobar _SummaryOrDetail = SummaryOrDetail;
			Infobar _InclARTrxAPTrxOrBoth = InclARTrxAPTrxOrBoth;
			Infobar _InclCOPOOrBoth = InclCOPOOrBoth;
			FlagNyType _InclPORequisitions = InclPORequisitions;
			FlagNyType _InclCOBlanketReleases = InclCOBlanketReleases;
			FlagNyType _InclPOBlanketReleases = InclPOBlanketReleases;
			FlagNyType _InclCOProgresiveBilling = InclCOProgresiveBilling;
			Infobar _CreditHold = CreditHold;
			FlagNyType _InclEstimateOrders = InclEstimateOrders;
			IntType _EstimateOrderOffsetDay = EstimateOrderOffsetDay;
			FlagNyType _InclAREarlyPayDiscounts = InclAREarlyPayDiscounts;
			FlagNyType _InclAPEarlyPayDiscounts = InclAPEarlyPayDiscounts;
			Infobar _CustomerPaymentsBasis = CustomerPaymentsBasis;
			IntType _NumberOfDaysLookback = NumberOfDaysLookback;
			FlagNyType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			CurrCodeType _StartingCurrencyCode = StartingCurrencyCode;
			CurrCodeType _EndingCurrencyCode = EndingCurrencyCode;
			Infobar _PaymentHold = PaymentHold;
			Infobar _EstimateStatus = EstimateStatus;
			IntType _NumberOfDaysPerColumn = NumberOfDaysPerColumn;
			FlagNyType _UseHistoricalCurrencyRate = UseHistoricalCurrencyRate;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_CashImpactSubSp";
				
				appDB.AddCommandParameter(cmd, "SummaryOrDetail", _SummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclARTrxAPTrxOrBoth", _InclARTrxAPTrxOrBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclCOPOOrBoth", _InclCOPOOrBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclPORequisitions", _InclPORequisitions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclCOBlanketReleases", _InclCOBlanketReleases, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclPOBlanketReleases", _InclPOBlanketReleases, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclCOProgresiveBilling", _InclCOProgresiveBilling, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclEstimateOrders", _InclEstimateOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateOrderOffsetDay", _EstimateOrderOffsetDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclAREarlyPayDiscounts", _InclAREarlyPayDiscounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclAPEarlyPayDiscounts", _InclAPEarlyPayDiscounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerPaymentsBasis", _CustomerPaymentsBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfDaysLookback", _NumberOfDaysLookback, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCurrencyCode", _StartingCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCurrencyCode", _EndingCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentHold", _PaymentHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateStatus", _EstimateStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfDaysPerColumn", _NumberOfDaysPerColumn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseHistoricalCurrencyRate", _UseHistoricalCurrencyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
