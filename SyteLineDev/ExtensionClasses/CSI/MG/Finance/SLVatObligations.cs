//PROJECT NAME: FinanceExt
//CLASS NAME: SLVatObligations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Finance.MTD;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLVatObligations")]
    public class SLVatObligations : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CalculateVATReturnSp(
            DateTime? StartDate,
            DateTime? EndDate,
            [Optional] short? DateStartingOffset,
            [Optional] short? DateEndingOffset,
            string TaxJur,
            [Optional, DefaultParameterValue((byte) 1)]
            byte? TaxSystem,
            ref decimal? Box1TotalSalesVatDue,
            ref decimal? Box2TotalAcqVatDue,
            ref decimal? Box3TotalVatDue,
            ref decimal? Box4TotalReclaimedVat,
            ref decimal? Box5NetVatDue,
            ref decimal? Box6TotalSalesExVat,
            ref decimal? Box7TotalPurchaseExVat,
            ref decimal? Box8TotalGoodsSuppliedExVat,
            ref decimal? Box9TotalAcqExVat)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCalculateVATReturnExt = new CalculateVATReturnFactory().Create(appDb);

                var result = iCalculateVATReturnExt.CalculateVATReturnSp(StartDate,
                    EndDate,
                    DateStartingOffset,
                    DateEndingOffset,
                    TaxJur,
                    TaxSystem,
                    Box1TotalSalesVatDue,
                    Box2TotalAcqVatDue,
                    Box3TotalVatDue,
                    Box4TotalReclaimedVat,
                    Box5NetVatDue,
                    Box6TotalSalesExVat,
                    Box7TotalPurchaseExVat,
                    Box8TotalGoodsSuppliedExVat,
                    Box9TotalAcqExVat);

                int Severity = result.ReturnCode.Value;
                Box1TotalSalesVatDue = result.Box1TotalSalesVatDue;
                Box2TotalAcqVatDue = result.Box2TotalAcqVatDue;
                Box3TotalVatDue = result.Box3TotalVatDue;
                Box4TotalReclaimedVat = result.Box4TotalReclaimedVat;
                Box5NetVatDue = result.Box5NetVatDue;
                Box6TotalSalesExVat = result.Box6TotalSalesExVat;
                Box7TotalPurchaseExVat = result.Box7TotalPurchaseExVat;
                Box8TotalGoodsSuppliedExVat = result.Box8TotalGoodsSuppliedExVat;
                Box9TotalAcqExVat = result.Box9TotalAcqExVat;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LogVATReturnStampSp(
            DateTime? StartDate,
            DateTime? EndDate,
            string PeriodKey,
            string TaxJur,
            [Optional, DefaultParameterValue((byte) 1)]
            byte? TaxSystem)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iLogVATReturnStampExt = new LogVATReturnStampFactory().Create(appDb);

                var result = iLogVATReturnStampExt.LogVATReturnStampSp(StartDate,
                    EndDate,
                    PeriodKey,
                    TaxJur,
                    TaxSystem);


                return result.Value;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable GetVATTrxnSp(
            string PeriodKey,
            string BoxNum,
            string TaxJur,
            [Optional, DefaultParameterValue(1)] int? TaxSystem,
            [Optional] string FilterSite)
        {
            var iGetVATTrxnExt = new GetVATTrxnFactory().Create(this, true);

            var result = iGetVATTrxnExt.GetVATTrxnSp(PeriodKey,
                BoxNum,
                TaxJur,
                TaxSystem,
                FilterSite);

            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
            return dt;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MTDTransactionsResetUtilitySp(string PeriodKey)
        {
            var iMTDTransactionsResetUtilityExt = new MTDTransactionsResetUtilityFactory().Create(this, true);

            var result = iMTDTransactionsResetUtilityExt.MTDTransactionsResetUtilitySp(PeriodKey);

            int Severity = result.Value;
            return Severity;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PerformCodeExchange(
            string doNotTrack,
            string clientConnectMethod,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string code,
            string scope,
            string formName,
            ref string infobar)
        {
            string clientVersion;
            try
            {
                var assembly = typeof(IDORuntime).Assembly;
                var fileVersionAttribute = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute)).First();
                clientVersion = ((System.Reflection.AssemblyFileVersionAttribute) fileVersionAttribute).Version;
            }
            catch
            {
                clientVersion = string.Empty;
            }

            var mtdBusinessHandler = new MTDBusinessHandlerFactory().Create(this);
            var license = IDORuntime.Context.LicenseInfo.LicenseValid
                ? IDORuntime.Context.LicenseInfo.GetLicenseOption("LicenseID")
                : "";
            var userId = IDORuntime.Context.BaseUserName ?? "";

            var (returnCode, message) = mtdBusinessHandler.PerformCodeExchange(
                doNotTrack,
                clientConnectMethod,
                deviceId,
                localIps,
                localIpsTimestamp,
                publicIp,
                publicIpTimestamp,
                publicPort,
                screens,
                timeZone,
                windowSize,
                userAgent,
                plugins,
                macAddresses,
                envOs,
                code,
                scope,
                formName,
                license,
                userId,
                clientVersion);

            infobar = message;

            return returnCode;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RetrieveObligation(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string status,
            string formName,
            ref string infobar)
        {
            string clientVersion;
            try
            {
                var assembly = typeof(IDORuntime).Assembly;
                var fileVersionAttribute = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute)).First();
                clientVersion = ((System.Reflection.AssemblyFileVersionAttribute) fileVersionAttribute).Version;
            }
            catch
            {
                clientVersion = string.Empty;
            }


            var mtdBusinessHandler = new MTDBusinessHandlerFactory().Create(this);
            var license = IDORuntime.Context.LicenseInfo.LicenseValid
                ? IDORuntime.Context.LicenseInfo.GetLicenseOption("LicenseID")
                : "";
            var userId = IDORuntime.Context.BaseUserName ?? "";

            var (returnCode, message) = mtdBusinessHandler.RetrieveObligation(
                doNotTrack,
                clientConnectMethod,
                startDate,
                endDate,
                deviceId,
                localIps,
                localIpsTimestamp,
                publicIp,
                publicIpTimestamp,
                publicPort,
                screens,
                timeZone,
                windowSize,
                userAgent,
                plugins,
                macAddresses,
                envOs,
                status,
                formName,
                license,
                userId,
                clientVersion);

            infobar = message;

            return returnCode;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetLiabilities(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string periodKey,
            string formName,
            ref string infobar)
        {
            string clientVersion;
            try
            {
                var assembly = typeof(IDORuntime).Assembly;
                var fileVersionAttribute = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute)).First();
                clientVersion = ((System.Reflection.AssemblyFileVersionAttribute) fileVersionAttribute).Version;
            }
            catch
            {
                clientVersion = string.Empty;
            }


            var mtdBusinessHandler = new MTDBusinessHandlerFactory().Create(this);
            var license = IDORuntime.Context.LicenseInfo.LicenseValid
                ? IDORuntime.Context.LicenseInfo.GetLicenseOption("LicenseID")
                : "";
            var userId = IDORuntime.Context.BaseUserName ?? "";

            var (returnCode, message) = mtdBusinessHandler.GetLiabilities(
                doNotTrack,
                clientConnectMethod,
                startDate,
                endDate,
                deviceId,
                localIps,
                localIpsTimestamp,
                publicIp,
                publicIpTimestamp,
                publicPort,
                screens,
                timeZone,
                windowSize,
                userAgent,
                plugins,
                macAddresses,
                envOs,
                formName,
                license,
                periodKey,
                userId,
                clientVersion);

            infobar = message;

            return returnCode;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetPayments(
            string doNotTrack,
            string clientConnectMethod,
            string startDate,
            string endDate,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string periodKey,
            string formName,
            ref string infobar)
        {
            string clientVersion;
            try
            {
                var assembly = typeof(IDORuntime).Assembly;
                var fileVersionAttribute = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute)).First();
                clientVersion = ((System.Reflection.AssemblyFileVersionAttribute) fileVersionAttribute).Version;
            }
            catch
            {
                clientVersion = string.Empty;
            }

            var mtdBusinessHandler = new MTDBusinessHandlerFactory().Create(this);
            var license = IDORuntime.Context.LicenseInfo.LicenseValid
                ? IDORuntime.Context.LicenseInfo.GetLicenseOption("LicenseID")
                : "";
            var userId = IDORuntime.Context.BaseUserName ?? "";

            var (returnCode, message) = mtdBusinessHandler.GetPayments(
                doNotTrack,
                clientConnectMethod,
                startDate,
                endDate,
                deviceId,
                localIps,
                localIpsTimestamp,
                publicIp,
                publicIpTimestamp,
                publicPort,
                screens,
                timeZone,
                windowSize,
                userAgent,
                plugins,
                macAddresses,
                envOs,
                formName,
                license,
                periodKey,
                userId,
                clientVersion);

            infobar = message;

            return returnCode;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SubmitVat(
            string doNotTrack,
            string clientConnectMethod,
            string deviceId,
            string localIps,
            string localIpsTimestamp,
            string publicIp,
            string publicIpTimestamp,
            string publicPort,
            string screens,
            string timeZone,
            string windowSize,
            string userAgent,
            string plugins,
            string macAddresses,
            string envOs,
            string periodKey,
            string formName,
            ref string infobar)
        {
            string clientVersion;
            try
            {
                var assembly = typeof(IDORuntime).Assembly;
                var fileVersionAttribute = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute)).First();
                clientVersion = ((System.Reflection.AssemblyFileVersionAttribute) fileVersionAttribute).Version;
            }
            catch
            {
                clientVersion = string.Empty;
            }

            var mtdBusinessHandler = new MTDBusinessHandlerFactory().Create(this);
            var license = IDORuntime.Context.LicenseInfo.LicenseValid
                ? IDORuntime.Context.LicenseInfo.GetLicenseOption("LicenseID")
                : "";
            var userId = IDORuntime.Context.BaseUserName ?? "";

            var (returnCode, message) = mtdBusinessHandler.SubmitVat(
                doNotTrack,
                clientConnectMethod,
                deviceId,
                localIps,
                localIpsTimestamp,
                publicIp,
                publicIpTimestamp,
                publicPort,
                screens,
                timeZone,
                windowSize,
                userAgent,
                plugins,
                macAddresses,
                envOs,
                periodKey,
                formName,
                license,
                userId,
                clientVersion);

            infobar = message;

            return returnCode;
        }
    }
}