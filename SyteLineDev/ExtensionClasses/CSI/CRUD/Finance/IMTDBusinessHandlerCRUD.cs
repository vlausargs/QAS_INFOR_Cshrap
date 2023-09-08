using System;

namespace CSI.Finance
{
    public interface IMTDBusinessHandlerCRUD
    {
        #region Create

        void InsertVatObligation(
            DateTime? start,
            DateTime? end,
            DateTime? due,
            string status,
            string periodKey,
            DateTime? received);

        void InsertVatObligationPayment(
            string periodKey,
            string amount,
            string received,
            int seq);

        #endregion

        #region Read

        string SelectParms();

        (string, string) SelectProductInfo();

        (string RegisterNumber, string ClientId, string SecretKey, DateTime? ReadAccessExpirationDate, DateTime? WriteAccessExpirationDate,
            DateTime? ReadRefreshExpirationDate, DateTime? WriteRefreshExpirationDate, string ApiUrl, string WebRedirectUri, string
            WinRedirectUri, string ReadAccessToken, string WriteAccessToken, string ReadRefreshToken, string WriteRefreshToken)
            SelectTaxparms();

        bool SelectObligationExist(string periodKey);

        bool SelectObligationExistPayment(string periodKey, string amount, DateTime? received);

        int SelectObligationPaymentCount(string periodKey);

        (decimal VatDueSales, decimal VatDueAcquisitions, decimal TotalVatDue, decimal VatReclaimedCurrPeriod, decimal NetVatDue,
            decimal TotalValueSalesExVat, decimal TotalValuePurchasesExVat, decimal TotalValueGoodsSuppliedExVat, decimal
            TotalAcquisitionsExVat, bool Final)
            SelectVTAReturn(string periodkey);

        #endregion

        #region Update

        void UpdateVatObligation(
            string periodKey,
            DateTime? start,
            DateTime? end,
            DateTime? due,
            string status,
            DateTime? received);

        void UpdateVatObligationLiabilities(
            string periodKey,
            string vatType,
            string origAmt,
            string outstandingAmt,
            DateTime? dueDate);

        void UpdateVatObligationSubmitReturn(
            string periodKey,
            DateTime? processingDate,
            string formBundleNumber,
            string paymentIndicator,
            string chargeRefNumber);

        void UpdateTaxparmsReadtoken(
            string accessToken,
            string refreshToken,
            DateTime? newExpiresIn,
            DateTime? refreshExpires);

        void UpdateTaxparmsWritetoken(
            string accessToken,
            string refreshToken,
            DateTime? newExpiresIn,
            DateTime? refreshExpires);

        void UpdateTaxparmsRefreshTokenExpirationDate(
            DateTime? readExpires,
            DateTime? writeExpires);

        #endregion
    }
}