using System;
using System.Collections.Generic;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Finance
{
    public class MTDBusinessHandlerCRUD : IMTDBusinessHandlerCRUD
    {
        private readonly IApplicationDB _appDb;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;
        private readonly ICollectionUpdateRequestFactory _collectionUpdateRequestFactory;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly IExistsChecker _existsChecker;
        private readonly IVariableUtil _variableUtil;

        public MTDBusinessHandlerCRUD(
            IApplicationDB appDb,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil)
        {
            _appDb = appDb;
            _collectionInsertRequestFactory = collectionInsertRequestFactory;
            _collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            _existsChecker = existsChecker;
            _variableUtil = variableUtil;
        }

        #region Create

        public void InsertVatObligation(
            DateTime? start,
            DateTime? end,
            DateTime? due,
            string status,
            string periodKey,
            DateTime? received)
        {
            #region CRUD LoadResponseWithoutTable

            var nonTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(
                columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"period_start_date", start},
                    {"period_end_date", end},
                    {"obligation_due_date", due},
                    {"vat_obligation_status", status},
                    {"vat_period_key", periodKey},
                    {"final_payment_date", received},
                });

            var nonTableLoadResponse = this._appDb.Load(nonTableLoadRequest);

            #endregion CRUD LoadResponseWithoutTable

            #region CRUD InsertByRecords

            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(tableName: "vat_obligation",
                items: nonTableLoadResponse.Items);

            this._appDb.Insert(nonTableInsertRequest);

            #endregion InsertByRecords
        }

        public void InsertVatObligationPayment(string periodKey, string amount, string received, int seq)
        {
            #region CRUD LoadResponseWithoutTable

            var nonTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(
                columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"amount", amount},
                    {"received_date", received},
                    {"vat_period_key", periodKey},
                    {"vat_obligation_pmt_seq", seq}
                });

            var nonTableLoadResponse = this._appDb.Load(nonTableLoadRequest);

            #endregion CRUD LoadResponseWithoutTable

            #region CRUD InsertByRecords

            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(tableName: "vat_obligation_pmt",
                items: nonTableLoadResponse.Items);

            this._appDb.Insert(nonTableInsertRequest);

            #endregion InsertByRecords
        }

        #endregion

        #region Read

        public string SelectParms()
        {
            NameType company = DBNull.Value;
            var parmsLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {company, "company"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "parms",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this._appDb.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
                return company;
            return string.Empty;
        }

        public (string, string) SelectProductInfo()
        {
            ProductNameType productName = DBNull.Value;
            ProductVersionType productVersion = DBNull.Value;
            var productinfoLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {productName, "ProductName"},
                    {productVersion, "ProductVersion"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "productinfo",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var productinfoLoadResponse = this._appDb.Load(productinfoLoadRequest);
            if (productinfoLoadResponse.Items.Count > 0)
                return (productName, productVersion);
            return (string.Empty, string.Empty);
        }

        public (string RegisterNumber, string ClientId, string SecretKey, DateTime? ReadAccessExpirationDate, DateTime?
            WriteAccessExpirationDate, DateTime? ReadRefreshExpirationDate, DateTime? WriteRefreshExpirationDate, string ApiUrl, string
            WebRedirectUri, string WinRedirectUri, string ReadAccessToken, string WriteAccessToken, string ReadRefreshToken, string
            WriteRefreshToken)
            SelectTaxparms()
        {
            TaxRegNumType registerNumber = DBNull.Value;
            VATClientIdType clientId = DBNull.Value;
            VATSecretKeyType secretKey = DBNull.Value;
            DateTimeType readAccessExpirationDate = DBNull.Value;
            DateTimeType writeAccessExpirationDate = DBNull.Value;
            DateTimeType readRefreshExpirationDate = DBNull.Value;
            DateTimeType writeRefreshExpirationDate = DBNull.Value;
            URLType apiUrl = DBNull.Value;
            URLType webRedirectUri = DBNull.Value;
            URLType winRedirectUri = DBNull.Value;
            VATTokenType readAccessToken = DBNull.Value;
            VATTokenType writeAccessToken = DBNull.Value;
            VATTokenType readRefreshToken = DBNull.Value;
            VATTokenType writeRefreshToken = DBNull.Value;

            var parmsLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {registerNumber, "tax_reg_num1"},
                    {clientId, "vat_client_id"},
                    {secretKey, "vat_secret_key"},
                    {readAccessExpirationDate, "vat_read_access_expiration_date"},
                    {writeAccessExpirationDate, "vat_write_access_expiration_date"},
                    {readRefreshExpirationDate, "vat_read_refresh_expiration_date"},
                    {writeRefreshExpirationDate, "vat_write_refresh_expiration_date"},
                    {apiUrl, "vat_url"},
                    {webRedirectUri, "vat_redirect_uri_web"},
                    {winRedirectUri, "vat_redirect_uri_win"},
                    {readAccessToken, "vat_read_access_token"},
                    {writeAccessToken, "vat_write_access_token"},
                    {readRefreshToken, "vat_read_refresh_token"},
                    {writeRefreshToken, "vat_write_refresh_token"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "Taxparms",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this._appDb.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
                return (registerNumber,
                    clientId,
                    secretKey,
                    readAccessExpirationDate,
                    writeAccessExpirationDate,
                    readRefreshExpirationDate,
                    writeRefreshExpirationDate,
                    apiUrl,
                    webRedirectUri,
                    winRedirectUri,
                    readAccessToken,
                    writeAccessToken,
                    readRefreshToken,
                    writeRefreshToken);
            return (string.Empty, string.Empty, string.Empty, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, string.Empty,
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public bool SelectObligationExist(string periodKey)
        {
            return _existsChecker.Exists(tableName: "vat_obligation",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation.vat_period_key = {_variableUtil.GetQuotedValue<string>(periodKey)}"));
        }

        public bool SelectObligationExistPayment(string periodKey, string amount, DateTime? received)
        {
            return _existsChecker.Exists(tableName: "vat_obligation_pmt",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation_pmt.vat_period_key = {_variableUtil.GetQuotedValue<string>(periodKey)} and vat_obligation_pmt.received_date = {_variableUtil.GetQuotedValue<DateTime?>(received)} and vat_obligation_pmt.amount = {amount}"));
        }

        public int SelectObligationPaymentCount(string periodKey)
        {
            VATPeriodKeyType periodKeyColumn = DBNull.Value;

            var parmsLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {periodKeyColumn, "vat_period_key"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "vat_obligation_pmt",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation_pmt.vat_period_key = {_variableUtil.GetQuotedValue(periodKey)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this._appDb.Load(parmsLoadRequest);
            return parmsLoadResponse.Items.Count;
        }

        public (decimal VatDueSales, decimal VatDueAcquisitions, decimal TotalVatDue, decimal VatReclaimedCurrPeriod, decimal NetVatDue,
            decimal TotalValueSalesExVat, decimal TotalValuePurchasesExVat, decimal TotalValueGoodsSuppliedExVat, decimal
            TotalAcquisitionsExVat, bool Final)
            SelectVTAReturn(string periodKey)
        {
            VATReturnAmountType vatDueSales = DBNull.Value;
            VATReturnAmountType vatDueAcquisitions = DBNull.Value;
            VATReturnAmountType totalVatDue = DBNull.Value;
            VATReturnAmountType vatReclaimedCurrPeriod = DBNull.Value;
            VATReturnAmountType netVatDue = DBNull.Value;
            VATReturnTaxBasisType totalValueSalesExVat = DBNull.Value;
            VATReturnTaxBasisType totalValuePurchasesExVat = DBNull.Value;
            VATReturnTaxBasisType totalValueGoodsSuppliedExVat = DBNull.Value;
            VATReturnTaxBasisType totalAcquisitionsExVat = DBNull.Value;
            ListYesNoType final = DBNull.Value;

            var parmsLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {vatDueSales, "final_sales_vat_due"},
                    {vatDueAcquisitions, "final_acquisitions_vat_due"},
                    {totalVatDue, "final_total_vat_due"},
                    {vatReclaimedCurrPeriod, "final_reclaimed_vat"},
                    {netVatDue, "final_net_vat_due"},
                    {totalValueSalesExVat, "final_sales_excluding_vat"},
                    {totalValuePurchasesExVat, "final_purchases_excluding_vat"},
                    {totalValueGoodsSuppliedExVat, "final_goods_supplied_excluding_vat"},
                    {totalAcquisitionsExVat, "final_acquisitions_excluding_vat"},
                    {final, "final_confirmation"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "vat_obligation",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation.vat_period_key = {_variableUtil.GetQuotedValue(periodKey)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this._appDb.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
                return (vatDueSales,
                    vatDueAcquisitions,
                    totalVatDue,
                    vatReclaimedCurrPeriod,
                    netVatDue,
                    totalValueSalesExVat,
                    totalValuePurchasesExVat,
                    totalValueGoodsSuppliedExVat,
                    totalAcquisitionsExVat,
                    final == 1);
            return (decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero,
                decimal.Zero, false);
        }

        #endregion

        #region Update

        public void UpdateVatObligation(
            string periodKey,
            DateTime? start,
            DateTime? end,
            DateTime? due,
            string status,
            DateTime? received)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"period_start_date", "period_start_date"},
                    {"period_end_date", "period_end_date"},
                    {"obligation_due_date", "obligation_due_date"},
                    {"vat_obligation_status", "vat_obligation_status"},
                    {"final_payment_date", "final_payment_date"}
                },
                tableName: "vat_obligation",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation.vat_period_key = {_variableUtil.GetQuotedValue(periodKey)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var vatObligationResponse = this._appDb.Load(loadRequest);


            foreach (var item in vatObligationResponse.Items)
            {
                item.SetValue("period_start_date", start);
                item.SetValue("period_end_date", end);
                item.SetValue("obligation_due_date", due);
                item.SetValue("vat_obligation_status", status);
                item.SetValue("final_payment_date", received);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "vat_obligation",
                items: vatObligationResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        public void UpdateVatObligationLiabilities(
            string periodKey,
            string vatType,
            string origAmt,
            string outstandingAmt,
            DateTime? dueDate)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"liability_type", "liability_type"},
                    {"liability_original_amt", "liability_original_amt"},
                    {"liability_outstanding_amt", "liability_outstanding_amt"},
                    {"liability_due_date", "liability_due_date"}
                },
                tableName: "vat_obligation",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation.vat_period_key = {_variableUtil.GetQuotedValue(periodKey)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var vatObligationResponse = this._appDb.Load(loadRequest);


            foreach (var item in vatObligationResponse.Items)
            {
                item.SetValue("liability_type", vatType);
                item.SetValue("liability_original_amt", origAmt);
                item.SetValue("liability_outstanding_amt", outstandingAmt);
                item.SetValue("liability_due_date", dueDate);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "vat_obligation",
                items: vatObligationResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        public void UpdateVatObligationSubmitReturn(
            string periodKey,
            DateTime? processingDate,
            string formBundleNumber,
            string paymentIndicator,
            string chargeRefNumber)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"return_process_date", "return_process_date"},
                    {"return_pay_indicator", "return_pay_indicator"},
                    {"return_bundle_num", "return_bundle_num"},
                    {"return_charge_ref_num", "return_charge_ref_num"}
                },
                tableName: "vat_obligation",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"vat_obligation.vat_period_key = {_variableUtil.GetQuotedValue(periodKey)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var vatObligationResponse = this._appDb.Load(loadRequest);

            foreach (var item in vatObligationResponse.Items)
            {
                item.SetValue("return_process_date", processingDate);
                item.SetValue("return_bundle_num", formBundleNumber);
                if (string.IsNullOrWhiteSpace(paymentIndicator))
                {
                    item.SetValue("return_pay_indicator", paymentIndicator);
                }

                if (string.IsNullOrWhiteSpace(chargeRefNumber))
                {
                    item.SetValue("return_charge_ref_num", chargeRefNumber);
                }
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "vat_obligation",
                items: vatObligationResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        public void UpdateTaxparmsReadtoken(
            string accessToken,
            string refreshToken,
            DateTime? newExpiresIn,
            DateTime? refreshExpires)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"vat_read_access_token", "vat_read_access_token"},
                    {"vat_read_refresh_token", "vat_read_refresh_token"},
                    {"vat_read_access_expiration_date", "vat_read_access_expiration_date"},
                    {"vat_read_refresh_expiration_date", "vat_read_refresh_expiration_date"}
                },
                tableName: "taxparms",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taxParmsResponse = this._appDb.Load(loadRequest);


            foreach (var item in taxParmsResponse.Items)
            {
                item.SetValue("vat_read_access_token", accessToken);
                item.SetValue("vat_read_refresh_token", refreshToken);
                item.SetValue("vat_read_access_expiration_date", newExpiresIn);
                item.SetValue("vat_read_refresh_expiration_date", refreshExpires);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "taxparms",
                items: taxParmsResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        public void UpdateTaxparmsWritetoken(
            string accessToken,
            string refreshToken,
            DateTime? newExpiresIn,
            DateTime? refreshExpires)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"vat_write_access_token", "vat_write_access_token"},
                    {"vat_write_refresh_token", "vat_write_refresh_token"},
                    {"vat_write_access_expiration_date", "vat_write_access_expiration_date"},
                    {"vat_write_refresh_expiration_date", "vat_write_refresh_expiration_date"}
                },
                tableName: "taxparms",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taxParmsResponse = this._appDb.Load(loadRequest);


            foreach (var item in taxParmsResponse.Items)
            {
                item.SetValue("vat_write_access_token", accessToken);
                item.SetValue("vat_write_refresh_token", refreshToken);
                item.SetValue("vat_write_access_expiration_date", newExpiresIn);
                item.SetValue("vat_write_refresh_expiration_date", refreshExpires);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "taxparms",
                items: taxParmsResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        public void UpdateTaxparmsRefreshTokenExpirationDate(
            DateTime? readExpires,
            DateTime? writeExpires)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"vat_read_refresh_expiration_date", "vat_read_refresh_expiration_date"},
                    {"vat_write_refresh_expiration_date", "vat_write_refresh_expiration_date"}
                },
                tableName: "taxparms",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taxParmsResponse = this._appDb.Load(loadRequest);


            foreach (var item in taxParmsResponse.Items)
            {
                item.SetValue("vat_read_refresh_expiration_date", readExpires);
                item.SetValue("vat_write_refresh_expiration_date", readExpires);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(tableName: "taxparms",
                items: taxParmsResponse.Items);

            this._appDb.Update(requestUpdate);
        }

        #endregion
    }
}