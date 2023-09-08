using CSI.Adapters;
using CSI.Admin;
using CSI.Admin.SiteOnBoarding;
using CSI.App.Logistics.Customer;
using CSI.App.Reporting.Rpt_ShipmentProFormaInvoice;
using CSI.BusInterface;
using CSI.BusInterface.ESBExtWhse;
using CSI.Codes;
using CSI.CRUD.Codes;
using CSI.CRUD.Reporting;
using CSI.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.Functions;
using CSI.Data.Metric;
using CSI.Data.Net;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.DataCollection;
using CSI.Employee;
using CSI.Finance;
using CSI.Finance.AR;
using CSI.Finance.Chinese;
using CSI.Logistics.Customer;
using CSI.Logistics.FieldService;
using CSI.Logistics.FieldService.Requests;
using CSI.Logistics.Vendor;
using CSI.Material;
using CSI.MG;
using CSI.MG.MGCore;
using CSI.PLLOC;
using CSI.Production;
using CSI.Production.APS;
using CSI.Production.Quality;
using CSI.Reporting;
using CSI.Reporting.Germany;
using CSI.Serializer;
using Microsoft.Extensions.DependencyInjection;
using PLLOC.Interfaces;
using PLLOC.Objects;
using System;
using CSI.Interfaces.Data;

namespace CSI
{
    public static class CompositionRootExtension
    {
        static ServiceCollection AddRuntimeIntercepts(ServiceCollection sc)
        {
            return sc;
        }
        public static ServiceProvider BuildSyteLineServiceProvider(this ServiceCollection services)
        {
            //It makes sure the AddRuntimeIntercepts is the last one to be called before provider is built.
            return AddRuntimeIntercepts(services).BuildServiceProvider();
        }
    }

    public class CompositionRoot
    {
        private ServiceCollection GetServiceCollection()
        {
            var sc = new ServiceCollection();
            return sc;
        }

        /// <summary>
        /// When running without mongoose, there are a few inputs that we need.  We get these from ISQLDependencies which is passed in here.
        /// </summary>
        private ServiceCollection AddSQLDependencies(ServiceCollection sc, ISQLDependencies sqlDependencies)
        {
            if (sc == null) throw new Exception("Internal Error: ServiceCollection is required");
            if (sqlDependencies == null) throw new Exception("Internal Error: ISQLDependencies is required");

            //keep them in alphabetical order so we don't accidentally double register
            sc.AddScoped<ICommandProvider>(s => sqlDependencies.SQLCommandProvider);
            sc.AddScoped<IMessageProvider>(s => sqlDependencies.SQLMessageProvider);
            sc.AddScoped<ISetSite>(s => sqlDependencies.SetSite);
            sc.AddScoped<ISQLBunchingContext>(s => sqlDependencies.SQLBunchingContext);
            sc.AddScoped<IUserPrincipal>(s => sqlDependencies.UserPrincipal);
            sc.AddScoped<IFileServer>(s => sqlDependencies.FileServer);
            sc.AddScoped<IApplicationEvent>(s => sqlDependencies.ApplicationEvent);
            sc.AddScoped<IEmail>(s => sqlDependencies.Email);
            return sc;
        }

        /// <summary>
        /// Since we don't have access to the mongoose libraries in this project, any mongoose dependencies are passed in here.
        /// There are a few additional items classes that, while they don't rely directly on the mongoose libraries, rely on mongoose delivered
        /// stored procedures.  For visibility, we attempt to call those out here as well if we know about them.  However, many of these are just
        /// lumped in with the rest of the application classes.
        /// </summary>
        private ServiceCollection AddMGDependencies(ServiceCollection sc, IMongooseDependencies mgDependencies)
        {
            if (sc == null) throw new Exception("Internal Error: ServiceCollection is required");
            if (mgDependencies == null) throw new Exception("Internal Error: IMongooseDependencies is required");

            //keep them in alphabetical order so we don't accidentally double register
            sc.AddScoped<IAssemblyLoader>(s => mgDependencies.AssemblyLoader);
            sc.AddScoped<IBunchedLoadCollection>(s => mgDependencies.BunchedLoadCollection);
            sc.AddScoped<ICommandExecutor>(s => mgDependencies.MGCommandExecutor);
            sc.AddScoped<ICommandParameters>(s => mgDependencies.MGCommandParameters);
            sc.AddScoped<ICommandProvider>(s => mgDependencies.MGCommandProvider);
            sc.AddScoped<ILiteralProvider>(s => mgDependencies.MGLiteralProvider);
            sc.AddScoped<ILogger>(s => mgDependencies.MGLogger);
            sc.AddScoped<IMessageProvider>(s => mgDependencies.MGMessageProvider);
            sc.AddScoped<IMGBunchedRequest>(s => mgDependencies.MGBunchedRequest);
            sc.AddScoped<IProcessVariableProvider>(s => mgDependencies.ProcessVariableProvider);
            sc.AddScoped<IUserPrincipal>(s => mgDependencies.UserPrincipal);
            sc.AddScoped<IFileServer>(s => mgDependencies.FileServer);
            sc.AddScoped<IApplicationEvent>(s => mgDependencies.MGApplicationEvent);
            sc.AddScoped<IEmail>(s => mgDependencies.MGEmail);
            return sc;
        }

        /// <summary>
        /// Adds all the top level and supporting application logic classes
        /// </summary>
        private ServiceCollection AddApplicationClasses(ServiceCollection sc)
        {
            if (sc == null) throw new Exception("Internal Error: ServiceCollection is required");

            //register the ecb into IOC. After that, the instance could be passed into other constructor as needed.
            ITimerFactory timerFactory = new TimerFactory();

            // keep them in alphabetical order so we don't accidentally double register
            // There should be a matching test case added to the CompositionRootTests.WhenType_ThenServe for each one of these

            #region classes

            sc.AddScoped<ApsClearPlannerStatus>();
            sc.AddScoped<ApsUpdateActiveBGTasks>();
            sc.AddScoped<AptrxVerifyInvNum>();
            sc.AddScoped<BuyerAlerts>();
            sc.AddScoped<BuyerValid>();
            sc.AddScoped<CalcFreightAmounts>();
            sc.AddScoped<ChangeVendorContractPriceStatus>();
            sc.AddScoped<CheckAndGetInvLeng>();
            sc.AddScoped<CheckAssignedLocations>();
            sc.AddScoped<CheckConsgnWhseForItem>();
            sc.AddScoped<CheckDelJobMatl>();
            sc.AddScoped<CheckItemAllsForSite>();
            sc.AddScoped<CheckJourlockStat>();
            sc.AddScoped<CheckMrpWbExists>();
            sc.AddScoped<CheckWhseExternalControlledFlag>();
            sc.AddScoped<CHSCLM_ListVouchers>();
            sc.AddScoped<CHSCLM_VoucherTypeCodeList>();
            sc.AddScoped<CHSGetDigitsOfMainAcct>();
            sc.AddScoped<CLM_APBalance>();
            sc.AddScoped<CLM_ApsGetMATLPlus>();
            sc.AddScoped<CLM_ApsGetRGRP>();
            sc.AddScoped<CLM_APSItemList>();
            sc.AddScoped<CLM_APSMsgNumList>();
            sc.AddScoped<CLM_APSOrderList>();
            sc.AddScoped<CLM_ApsWhatIfEXRCPTDemand>();
            sc.AddScoped<CLM_ApsWhatIfEXRCPTItem>();
            sc.AddScoped<CLM_ApsWhatIfEXRCPTPO>();
            sc.AddScoped<CLM_BankStmTypeCode>();
            sc.AddScoped<CLM_DeprMethod>();
            sc.AddScoped<CLM_ESBJobResource>();
            sc.AddScoped<CLM_ESBQuoteLine>();
            sc.AddScoped<CLM_ESBShipUnit>();
            sc.AddScoped<CLM_ESBShipUnitItem>();
            sc.AddScoped<CLM_ExecutiveShipmentRevenue>();
            sc.AddScoped<CLM_GetARAgingInfo>();
            sc.AddScoped<CLM_GetCoNum>();
            sc.AddScoped<CLM_GetEmpManagerInfo>();
            sc.AddScoped<CLM_GetInvoiceNo>();
            sc.AddScoped<CLM_GetPPBatchedOperationType>();
            sc.AddScoped<CLM_LoadDimAttributeOverride>();
            sc.AddScoped<CLM_PayCheckEarnings>();
            sc.AddScoped<CLM_PayrollCheckDateChart>();
            sc.AddScoped<CLM_PayrollCheckDateListing>();
            sc.AddScoped<CLM_POBuilderPLNData>();
            sc.AddScoped<CLM_PopulateDoLine>();
            sc.AddScoped<CLM_ProcessMgrUser>();
            sc.AddScoped<CLM_ResGanttDemands>();
            sc.AddScoped<CLM_ShipmentASN>();
            sc.AddScoped<CLM_SlsmanReports>();
            sc.AddScoped<CLM_ToSiteForManualVoucherBuilder>();
            sc.AddScoped<CLM_VatProceduralMarkingsSp>();
            sc.AddScoped<CurrCnvt>();
            sc.AddScoped<CurrentMaterialsDelete>();
            sc.AddScoped<CurrentMaterialsJobItemData>();
            sc.AddScoped<CurrentMaterialsOperChg>();
            sc.AddScoped<CustGlobal>();
            sc.AddScoped<CustomerOrderCount>();
            sc.AddScoped<CustomerQuoteExistsWarning>();
            sc.AddScoped<CustSpecificUnitPriceExists>();
            sc.AddScoped<ESBInventoryHoldLoadViewsItemLocationMove>();
            sc.AddScoped<ESBInventoryHoldLoadViewsLots>();
            sc.AddScoped<ESBInventoryHoldLoadViewsNewHoldCodes>();
            sc.AddScoped<ESBInventoryHoldLoadViewsOldHoldCodes>();
            sc.AddScoped<ESBReceiveShipLineViewsReceiveLocation>();
            sc.AddScoped<ExpectedReceiptsAPSItemChg>();
            sc.AddScoped<IExportHeaderInfoCRUD, ExportHeaderInfoCRUD>();
            sc.AddScoped<IExportHeaderInfo, ExportHeaderInfo>();
            sc.AddScoped<ExportSiteTaskProcessor>();
            sc.AddScoped<ExtPrIfErrorSave>();
            sc.AddScoped<GeneratePLJPKV7MXML>();
            sc.AddScoped<GetFreightRateShop>();
            sc.AddScoped<GetLabel>();
            sc.AddScoped<Getumcf>();
            sc.AddScoped<ICLM_ESBShipUnit>(s => timerFactory.Create<ICLM_ESBShipUnit>(s.GetService<CLM_ESBShipUnit>()));
            sc.AddScoped<ICLM_ESBShipUnitItem>(s => timerFactory.Create<ICLM_ESBShipUnitItem>(s.GetService<CLM_ESBShipUnitItem>()));
            sc.AddScoped<Func<GOBDUMediaServiceEnum, IRpt_GOBDUMediaService>>(s => (algorithm) =>
            {
                switch (algorithm)
                {
                    case GOBDUMediaServiceEnum.Rpt_SLAptrxps:
                        return s.GetService<IRpt_SLAptrxps>();

                    case GOBDUMediaServiceEnum.Rpt_SLArtrans:
                        return s.GetService<IRpt_SLArtrans>();

                    case GOBDUMediaServiceEnum.Rpt_SLBankAddrs:
                        return s.GetService<IRpt_SLBankAddrs>();

                    case GOBDUMediaServiceEnum.Rpt_SLBankHdrs:
                        return s.GetService<IRpt_SLBankHdrs>();

                    case GOBDUMediaServiceEnum.Rpt_SLCharts:
                        return s.GetService<IRpt_SLCharts>();

                    case GOBDUMediaServiceEnum.Rpt_SLCoitems:
                        return s.GetService<IRpt_SLCoitems>();

                    case GOBDUMediaServiceEnum.Rpt_SLCos:
                        return s.GetService<IRpt_SLCos>();

                    case GOBDUMediaServiceEnum.Rpt_SLCurrates:
                        return s.GetService<IRpt_SLCurrates>();

                    case GOBDUMediaServiceEnum.Rpt_SLCurrencyCodes:
                        return s.GetService<IRpt_SLCurrencyCodes>();

                    case GOBDUMediaServiceEnum.Rpt_SLCustomers:
                        return s.GetService<IRpt_SLCustomers>();

                    case GOBDUMediaServiceEnum.Rpt_SLDepts:
                        return s.GetService<IRpt_SLDepts>();

                    case GOBDUMediaServiceEnum.Rpt_SLEmployees:
                        return s.GetService<IRpt_SLEmployees>();

                    case GOBDUMediaServiceEnum.Rpt_SLEmpPrBanks:
                        return s.GetService<IRpt_SLEmpPrBanks>();

                    case GOBDUMediaServiceEnum.Rpt_SLFaclasses:
                        return s.GetService<IRpt_SLFaclasses>();

                    case GOBDUMediaServiceEnum.Rpt_SLFaCosts:
                        return s.GetService<IRpt_SLFaCosts>();

                    case GOBDUMediaServiceEnum.Rpt_SLFaDeprs:
                        return s.GetService<IRpt_SLFaDeprs>();

                    case GOBDUMediaServiceEnum.Rpt_SLFaDisps:
                        return s.GetService<IRpt_SLFaDisps>();

                    case GOBDUMediaServiceEnum.Rpt_SLFamasters:
                        return s.GetService<IRpt_SLFamasters>();

                    case GOBDUMediaServiceEnum.Rpt_SLFaTrans:
                        return s.GetService<IRpt_SLFaTrans>();

                    case GOBDUMediaServiceEnum.Rpt_SLInvHdrs:
                        return s.GetService<IRpt_SLInvHdrs>();

                    case GOBDUMediaServiceEnum.Rpt_SLInvItemAlls:
                        return s.GetService<IRpt_SLInvItemAlls>();

                    case GOBDUMediaServiceEnum.Rpt_SLInvItemSurcharges:
                        return s.GetService<IRpt_SLInvItemSurcharges>();

                    case GOBDUMediaServiceEnum.Rpt_SLInvStaxs:
                        return s.GetService<IRpt_SLInvStaxs>();

                    case GOBDUMediaServiceEnum.Rpt_SLItemContentRefs:
                        return s.GetService<IRpt_SLItemContentRefs>();

                    case GOBDUMediaServiceEnum.Rpt_SLItems:
                        return s.GetService<IRpt_SLItems>();

                    case GOBDUMediaServiceEnum.Rpt_SLJourHdrs:
                        return s.GetService<IRpt_SLJourHdrs>();

                    case GOBDUMediaServiceEnum.Rpt_SLLedgers:
                        return s.GetService<IRpt_SLLedgers>();

                    case GOBDUMediaServiceEnum.Rpt_SLNonInventoryItems:
                        return s.GetService<IRpt_SLNonInventoryItems>();

                    case GOBDUMediaServiceEnum.Rpt_SLPoItems:
                        return s.GetService<IRpt_SLPoItems>();

                    case GOBDUMediaServiceEnum.Rpt_SLPos:
                        return s.GetService<IRpt_SLPos>();

                    case GOBDUMediaServiceEnum.Rpt_SLPrbanks:
                        return s.GetService<IRpt_SLPrbanks>();

                    case GOBDUMediaServiceEnum.Rpt_SLPrdecds:
                        return s.GetService<IRpt_SLPrdecds>();

                    case GOBDUMediaServiceEnum.Rpt_SLProjMatls:
                        return s.GetService<IRpt_SLProjMatls>();

                    case GOBDUMediaServiceEnum.Rpt_SLProjs:
                        return s.GetService<IRpt_SLProjs>();

                    case GOBDUMediaServiceEnum.Rpt_SLProjTasks:
                        return s.GetService<IRpt_SLProjTasks>();

                    case GOBDUMediaServiceEnum.Rpt_SLProjTrans:
                        return s.GetService<IRpt_SLProjTrans>();

                    case GOBDUMediaServiceEnum.Rpt_SLPrtaxts:
                        return s.GetService<IRpt_SLPrtaxts>();

                    case GOBDUMediaServiceEnum.Rpt_SLPrtrxps:
                        return s.GetService<IRpt_SLPrtrxps>();

                    case GOBDUMediaServiceEnum.Rpt_SLTaxcodes:
                        return s.GetService<IRpt_SLTaxcodes>();

                    case GOBDUMediaServiceEnum.Rpt_SLTaxJurs:
                        return s.GetService<IRpt_SLTaxJurs>();

                    case GOBDUMediaServiceEnum.Rpt_SLUMs:
                        return s.GetService<IRpt_SLUMs>();

                    case GOBDUMediaServiceEnum.Rpt_SLUnitcd1s:
                        return s.GetService<IRpt_SLUnitcd1s>();

                    case GOBDUMediaServiceEnum.Rpt_SLUnitcd2s:
                        return s.GetService<IRpt_SLUnitcd2s>();

                    case GOBDUMediaServiceEnum.Rpt_SLUnitcd3s:
                        return s.GetService<IRpt_SLUnitcd3s>();

                    case GOBDUMediaServiceEnum.Rpt_SLUnitcd4s:
                        return s.GetService<IRpt_SLUnitcd4s>();

                    case GOBDUMediaServiceEnum.Rpt_SLVchHdrs:
                        return s.GetService<IRpt_SLVchHdrs>();

                    case GOBDUMediaServiceEnum.Rpt_SLVchItemAlls:
                        return s.GetService<IRpt_SLVchItemAlls>();

                    case GOBDUMediaServiceEnum.Rpt_SLVchStaxs:
                        return s.GetService<IRpt_SLVchStaxs>();

                    case GOBDUMediaServiceEnum.Rpt_SLVendors:
                        return s.GetService<IRpt_SLVendors>();

                    default:
                        throw new ArgumentNullException("Invalid Stored Procedure input!");
                }
            });
            sc.AddScoped<HighAnyInt>();
            sc.AddScoped<HighCharacter>();
            sc.AddScoped<HighDate>();
            sc.AddScoped<HighDecimal>();
            sc.AddScoped<HighInt>();
            sc.AddScoped<HighString>();
            sc.AddScoped<Home_BGTaskAnalysis>();
            sc.AddScoped<Home_MetricJobWIP>();
            sc.AddScoped<Home_VchPay>();
            sc.AddScoped<Homepage_TotalSales>();
            sc.AddScoped<JPKV7MDeclarationsManager>();
            sc.AddScoped<ImportSiteTaskProcessor>();
            sc.AddScoped<LowAnyInt>();
            sc.AddScoped<LowCharacter>();
            sc.AddScoped<LowDate>();
            sc.AddScoped<LowDecimal>();
            sc.AddScoped<LowInt>();
            sc.AddScoped<LowString>();
            sc.AddScoped<ProcessFreightRateShopRequest>();
            sc.AddScoped<Rpt_AccountsReceivableAging>();
            sc.AddScoped<Rpt_EmpChildPrivacy>();
            sc.AddScoped<Rpt_GetGoBDMediaData>();
            sc.AddScoped<Rpt_GOBDUMediaDecider>();
            sc.AddScoped<Rpt_InventoryCost>();
            sc.AddScoped<Rpt_MXVATARPost>();
            sc.AddScoped<Rpt_ServiceContractPrivacy>();
            sc.AddScoped<Rpt_VouchersPayable>();
            sc.AddScoped<RSQC_CalcInterval>();
            sc.AddScoped<RSQC_GetHoldLoc>();
            sc.AddScoped<RSQC_GetItemUM>();
            sc.AddScoped<RSQC_GetRmaparmsLoc>();
            sc.AddScoped<RSQC_GetXrefItemData>();
            sc.AddScoped<RSQC_Parmcu>();
            sc.AddScoped<SaveVchProceduralMarkings>();
            sc.AddScoped<ShipmentPackageFreightClass>();
            sc.AddScoped<SQLCollectionDelete>();
            sc.AddScoped<SQLCollectionInsert>();
            sc.AddScoped<SQLCollectionLoadNonArbitrary>();
            sc.AddScoped<SQLCollectionNonTriggerDelete>();
            sc.AddScoped<SQLCollectionNonTriggerInsert>();
            sc.AddScoped<SQLCollectionNonTriggerUpdate>();
            sc.AddScoped<SQLCollectionUpdate>();
            sc.AddScoped<SQLQueryLanguage>();
            sc.AddScoped<SSSFSExpenseReconSave>();
            sc.AddScoped<SSSTraceStartWrap>();
            sc.AddScoped<StringUtil>();
            sc.AddScoped<UpdateShipmentWithTMInfo>();
            sc.AddScoped<UpdateCurrentPeriodDepreciationToZero>();

            #endregion classes

            #region interfaces

            sc.AddScoped<IAddCommandParameterWithValue, SQLAddCommandParameterWithValue>();
            sc.AddScoped<IAging, Aging>();
            sc.AddScoped<IAndSqlWhere, AndSqlWhere>();
            sc.AddScoped<IAPBalanceByPeriod, APBalanceByPeriod>();
            sc.AddScoped<IAppDbSchema, SQLDbSchema>();
            sc.AddScoped<IApplicationDB, CSIAppDB>();
            sc.AddScoped<IApplyDateOffset, ApplyDateOffset>();
            sc.AddScoped<IAppTableAndTableReferenceInfo, AppTableAndTableReferenceInfo>();
            sc.AddScoped<IApsClearPlannerStatus>(s => timerFactory.Create<IApsClearPlannerStatus>(s.GetService<ApsClearPlannerStatus>()));
            sc.AddScoped<IApsClearPlannerStatusCRUD, ApsClearPlannerStatusCRUD>();
            sc.AddScoped<IApsUpdateActiveBGTasks>(s => timerFactory.Create<IApsUpdateActiveBGTasks>(s.GetService<ApsUpdateActiveBGTasks>()));
            sc.AddScoped<IApsUpdateActiveBGTasksCRUD, ApsUpdateActiveBGTasksCRUD>();
            sc.AddScoped<IAptrxVerifyInvNum>(s => timerFactory.Create<IAptrxVerifyInvNum>(s.GetService<AptrxVerifyInvNum>()));
            sc.AddScoped<IAptrxVerifyInvNumCRUD, AptrxVerifyInvNumCRUD>();
            sc.AddScoped<IArTermDue, ArTermDue>();
            sc.AddScoped<IAsRulesCmpCstI, AsRulesCmpCstI>();
            sc.AddScoped<IAssemblyLoader, CSI.Data.AssemblyLoader>();
            sc.AddScoped<IAssemblyInvoker, AssemblyInvoker>();
            sc.AddScoped<IBookmarkFactory, BookmarkFactory>();
            sc.AddScoped<IBunchedLoadCollection, SQLBunchedLoadCollection>();
            sc.AddScoped<IBuyerAlerts>(s => timerFactory.Create<IBuyerAlerts>(s.GetService<BuyerAlerts>()));
            sc.AddScoped<IBuyerAlertsCRUD, BuyerAlertsCRUD>();
            sc.AddScoped<IBuyerValid>(s => timerFactory.Create<IBuyerValid>(s.GetService<BuyerValid>()));
            sc.AddScoped<IBuyerValidCRUD, BuyerValidCRUD>();
            sc.AddScoped<IByteArrayToListConvertor, ByteArrayToListConvertor>();
            sc.AddScoped<ICache, IDOMethodCallBoundedMemoryCache>();
            sc.AddScoped<ICacheEntrySerializer, BookmarkSerializer>();
            sc.AddScoped<ICalcFreightAmounts>(s => timerFactory.Create<ICalcFreightAmounts>(s.GetService<CalcFreightAmounts>()));
            sc.AddScoped<ICalcFreightAmountsCRUD, CalcFreightAmountsCRUD>();
            sc.AddScoped<IChangeVendorContractPriceStatus>(s => timerFactory.Create<IChangeVendorContractPriceStatus>(s.GetService<ChangeVendorContractPriceStatus>()));
            sc.AddScoped<IChangeVendorContractPriceStatusCRUD, ChangeVendorContractPriceStatusCRUD>();
            sc.AddScoped<ICheckAndGetInvLength>(s => timerFactory.Create<ICheckAndGetInvLength>(s.GetService<CheckAndGetInvLeng>()));
            sc.AddScoped<ICheckAndGetInvLengthCRUD, CheckAndGetInvLengthCRUD>();
            sc.AddScoped<ICheckAssignedLocations>(s => timerFactory.Create<ICheckAssignedLocations>(s.GetService<CheckAssignedLocations>()));
            sc.AddScoped<ICheckAssignedLocationsCRUD, CheckAssignedLocationsCRUD>();
            sc.AddScoped<ICheckConsgnWhseForItem>(s => timerFactory.Create<ICheckConsgnWhseForItem>(s.GetService<CheckConsgnWhseForItem>()));
            sc.AddScoped<ICheckConsgnWhseForItemCRUD, CheckConsgnWhseForItemCRUD>();
            sc.AddScoped<ICheckDelJobMatl>(s => timerFactory.Create<ICheckDelJobMatl>(s.GetService<CheckDelJobMatl>()));
            sc.AddScoped<ICheckDelJobMatlCRUD, CheckDelJobMatlCRUD>();
            sc.AddScoped<ICheckInvLength, CheckInvLength>();
            sc.AddScoped<ICheckItemAllsForSite>(s => timerFactory.Create<ICheckItemAllsForSite>(s.GetService<CheckItemAllsForSite>()));
            sc.AddScoped<ICheckItemAllsForSiteCRUD, CheckItemAllsForSiteCRUD>();
            sc.AddScoped<ICheckJourlockStat>(s => timerFactory.Create<ICheckJourlockStat>(s.GetService<CheckJourlockStat>()));
            sc.AddScoped<ICheckJourlockStatCRUD, CheckJourlockStatCRUD>();
            sc.AddScoped<ICheckMrpWbExists>(s => timerFactory.Create<ICheckMrpWbExists>(s.GetService<CheckMrpWbExists>()));
            sc.AddScoped<ICheckMrpWbExistsCRUD, CheckMrpWbExistsCRUD>();
            sc.AddScoped<ICheckWhseExternalControlledFlag>(s => timerFactory.Create<ICheckWhseExternalControlledFlag>(s.GetService<CheckWhseExternalControlledFlag>()));
            sc.AddScoped<IChkcred, Chkcred>();
            sc.AddScoped<ICHSCLM_ListVouchers>(s => timerFactory.Create<ICHSCLM_ListVouchers>(s.GetService<CHSCLM_ListVouchers>()));
            sc.AddScoped<ICHSCLM_ListVouchersCRUD, CHSCLM_ListVouchersCRUD>();
            sc.AddScoped<ICHSCLM_VoucherTypeCodeList>(s => timerFactory.Create<ICHSCLM_VoucherTypeCodeList>(s.GetService<CHSCLM_VoucherTypeCodeList>()));
            sc.AddScoped<ICHSCLM_VoucherTypeCodeListCRUD, CHSCLM_VoucherTypeCodeListCRUD>();
            sc.AddScoped<ICHSGetDigitsOfMainAcct>(s => timerFactory.Create<ICHSGetDigitsOfMainAcct>(s.GetService<CHSGetDigitsOfMainAcct>()));
            sc.AddScoped<ICHSGetDigitsOfMainAcctCRUD, CHSGetDigitsOfMainAcctCRUD>();
            sc.AddScoped<ICLM_APBalance>(s => timerFactory.Create<ICLM_APBalance>(s.GetService<CLM_APBalance>()));
            sc.AddScoped<ICLM_ApsGetMATLPlus>(s => timerFactory.Create<ICLM_ApsGetMATLPlus>(s.GetService<CLM_ApsGetMATLPlus>()));
            sc.AddScoped<ICLM_ApsGetMATLPlusCRUD, CLM_ApsGetMATLPlusCRUD>();
            sc.AddScoped<ICLM_ApsGetRGRP>(s => timerFactory.Create<ICLM_ApsGetRGRP>(s.GetService<CLM_ApsGetRGRP>()));
            sc.AddScoped<ICLM_ApsGetRGRPCRUD, CLM_ApsGetRGRPCRUD>();
            sc.AddScoped<ICLM_APSItemList>(s => timerFactory.Create<ICLM_APSItemList>(s.GetService<CLM_APSItemList>()));
            sc.AddScoped<ICLM_APSItemListCRUD, CLM_APSItemListCRUD>();
            sc.AddScoped<ICLM_APSMsgNumList>(s => timerFactory.Create<ICLM_APSMsgNumList>(s.GetService<CLM_APSMsgNumList>()));
            sc.AddScoped<ICLM_APSMsgNumListCRUD, CLM_APSMsgNumListCRUD>();
            sc.AddScoped<ICLM_APSOrderList>(s => timerFactory.Create<ICLM_APSOrderList>(s.GetService<CLM_APSOrderList>()));
            sc.AddScoped<ICLM_APSOrderListCRUD, CLM_APSOrderListCRUD>();
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTDemand>(s => timerFactory.Create<ICLM_ApsWhatIfEXRCPTDemand>(s.GetService<CLM_ApsWhatIfEXRCPTDemand>()));
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTDemandCRUD, CLM_ApsWhatIfEXRCPTDemandCRUD>();
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTItem>(s => timerFactory.Create<ICLM_ApsWhatIfEXRCPTItem>(s.GetService<CLM_ApsWhatIfEXRCPTItem>()));
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTItemCRUD, CLM_ApsWhatIfEXRCPTItemCRUD>();
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTPO>(s => timerFactory.Create<ICLM_ApsWhatIfEXRCPTPO>(s.GetService<CLM_ApsWhatIfEXRCPTPO>()));
            sc.AddScoped<ICLM_ApsWhatIfEXRCPTPOCRUD, CLM_ApsWhatIfEXRCPTPOCRUD>();
            sc.AddScoped<ICLM_BankStmTypeCode>(s => timerFactory.Create<ICLM_BankStmTypeCode>(s.GetService<CLM_BankStmTypeCode>()));
            sc.AddScoped<ICLM_BankStmTypeCodeCRUD, CLM_BankStmTypeCodeCRUD>();
            sc.AddScoped<ICLM_ChangeVendorContractPriceStatus, CLM_ChangeVendorContractPriceStatus>();
            sc.AddScoped<ICLM_DeprMethod>(s => timerFactory.Create<ICLM_DeprMethod>(s.GetService<CLM_DeprMethod>()));
            sc.AddScoped<ICLM_DeprMethodCRUD, CLM_DeprMethodCRUD>();
            sc.AddScoped<ICLM_ESBJobResource>(s => timerFactory.Create<ICLM_ESBJobResource>(s.GetService<CLM_ESBJobResource>()));
            sc.AddScoped<ICLM_ESBJobResourceCRUD, CLM_ESBJobResourceCRUD>();
            sc.AddScoped<ICLM_ESBQuoteLine>(s => timerFactory.Create<ICLM_ESBQuoteLine>(s.GetService<CLM_ESBQuoteLine>()));
            sc.AddScoped<ICLM_ESBShipUnitCRUD, CLM_ESBShipUnitCRUD>();
            sc.AddScoped<ICLM_ESBShipUnitItemCRUD, CLM_ESBShipUnitItemCRUD>();
            sc.AddScoped<ICLM_ExecutiveShipmentRevenue>(s => timerFactory.Create<ICLM_ExecutiveShipmentRevenue>(s.GetService<CLM_ExecutiveShipmentRevenue>()));
            sc.AddScoped<ICLM_ExecutiveShipmentRevenueCRUD, CLM_ExecutiveShipmentRevenueCRUD>();
            sc.AddScoped<ICLM_GetARAgingInfo>(s => timerFactory.Create<ICLM_GetARAgingInfo>(s.GetService<CLM_GetARAgingInfo>()));
            sc.AddScoped<ICLM_GetCoNum>(s => timerFactory.Create<ICLM_GetCoNum>(s.GetService<CLM_GetCoNum>()));
            sc.AddScoped<ICLM_GetCoNumCRUD, CLM_GetCoNumCRUD>();
            sc.AddScoped<ICLM_GetEmpManagerInfo>(s => timerFactory.Create<ICLM_GetEmpManagerInfo>(s.GetService<CLM_GetEmpManagerInfo>()));
            sc.AddScoped<ICLM_GetEmpManagerInfoCRUD, CLM_GetEmpManagerInfoCRUD>();
            sc.AddScoped<ICLM_GetInvoiceNo>(s => timerFactory.Create<ICLM_GetInvoiceNo>(s.GetService<CLM_GetInvoiceNo>()));
            sc.AddScoped<ICLM_GetInvoiceNoCRUD, CLM_GetInvoiceNoCRUD>();
            sc.AddScoped<ICLM_GetPPBatchedOperationType>(s => timerFactory.Create<ICLM_GetPPBatchedOperationType>(s.GetService<CLM_GetPPBatchedOperationType>()));
            sc.AddScoped<ICLM_GetPPBatchedOperationTypeCRUD, CLM_GetPPBatchedOperationTypeCRUD>();
            sc.AddScoped<ICLM_LoadDimAttributeOverride>(s => timerFactory.Create<ICLM_LoadDimAttributeOverride>(s.GetService<CLM_LoadDimAttributeOverride>()));
            sc.AddScoped<ICLM_LoadDimAttributeOverrideCRUD, CLM_LoadDimAttributeOverrideCRUD>();
            sc.AddScoped<ICLM_PayCheckEarnings>(s => timerFactory.Create<ICLM_PayCheckEarnings>(s.GetService<CLM_PayCheckEarnings>()));
            sc.AddScoped<ICLM_PayCheckEarningsCRUD, CLM_PayCheckEarningsCRUD>();
            sc.AddScoped<ICLM_PayrollCheckDateChart>(s => timerFactory.Create<ICLM_PayrollCheckDateChart>(s.GetService<CLM_PayrollCheckDateChart>()));
            sc.AddScoped<ICLM_PayrollCheckDateChartCRUD, CLM_PayrollCheckDateChartCRUD>();
            sc.AddScoped<ICLM_PayrollCheckDateListing>(s => timerFactory.Create<ICLM_PayrollCheckDateListing>(s.GetService<CLM_PayrollCheckDateListing>()));
            sc.AddScoped<ICLM_PayrollCheckDateListingCRUD, CLM_PayrollCheckDateListingCRUD>();
            sc.AddScoped<ICLM_POBuilderPLNData>(s => timerFactory.Create<ICLM_POBuilderPLNData>(s.GetService<CLM_POBuilderPLNData>()));
            sc.AddScoped<ICLM_POBuilderPLNDataCRUD, CLM_POBuilderPLNDataCRUD>();
            sc.AddScoped<ICLM_PopulateDoLine>(s => timerFactory.Create<ICLM_PopulateDoLine>(s.GetService<CLM_PopulateDoLine>()));
            sc.AddScoped<ICLM_PopulateDoLineCRUD, CLM_PopulateDoLineCRUD>();
            sc.AddScoped<ICLM_ProcessMgrUser>(s => timerFactory.Create<ICLM_ProcessMgrUser>(s.GetService<CLM_ProcessMgrUser>()));
            sc.AddScoped<ICLM_ProcessMgrUserCRUD, CLM_ProcessMgrUserCRUD>();
            sc.AddScoped<ICLM_ResGanttDemands>(s => timerFactory.Create<ICLM_ResGanttDemands>(s.GetService<CLM_ResGanttDemands>()));
            sc.AddScoped<ICLM_ResGanttDemandsCRUD, CLM_ResGanttDemandsCRUD>();
            sc.AddScoped<ICLM_ShipmentASN>(s => timerFactory.Create<ICLM_ShipmentASN>(s.GetService<CLM_ShipmentASN>()));
            sc.AddScoped<ICLM_ShipmentASNCRUD, CLM_ShipmentASNCRUD>();
            sc.AddScoped<ICLM_SlsmanReports>(s => timerFactory.Create<ICLM_SlsmanReports>(s.GetService<CLM_SlsmanReports>()));
            sc.AddScoped<ICLM_SlsmanReportsCRUD, CLM_SlsmanReportsCRUD>();
            sc.AddScoped<ICLM_ToSiteForManualVoucherBuilder>(s => timerFactory.Create<ICLM_ToSiteForManualVoucherBuilder>(s.GetService<CLM_ToSiteForManualVoucherBuilder>()));
            sc.AddScoped<ICLM_ToSiteForManualVoucherBuilderCRUD, CLM_ToSiteForManualVoucherBuilderCRUD>();
            sc.AddScoped<ICLM_UnshipShipment, CLM_UnshipShipment>();
            sc.AddScoped<ICLM_VatProceduralMarkingsCRUD, CLM_VatProceduralMarkingsCRUD>();
            sc.AddScoped<ICLM_VatProceduralMarkingsSp>(s => timerFactory.Create<ICLM_VatProceduralMarkingsSp>(s.GetService<CLM_VatProceduralMarkingsSp>()));
            sc.AddScoped<ICloseSessionContext, CloseSessionContext>();
            sc.AddScoped<ICommonTaskTableData, CommonTaskTableData>();
            sc.AddScoped<ICollectionDelete>(s => timerFactory.Create<ICollectionDelete>(s.GetService<SQLCollectionDelete>()));
            sc.AddScoped<ICollectionDeleteRequestFactory, CollectionDeleteRequestFactory>();
            sc.AddScoped<ICollectionInsert>(s => timerFactory.Create<ICollectionInsert>(s.GetService<SQLCollectionInsert>()));
            sc.AddScoped<ICollectionInsertRequestFactory, CollectionInsertRequestFactory>();
            sc.AddScoped<ICollectionLoad>(s => timerFactory.Create<ICollectionLoad>(s.GetService<SQLCollectionLoadNonArbitrary>()));
            sc.AddScoped<ICollectionLoadBuilder, SQLCollectionLoadBuilder>();
            sc.AddScoped<ICollectionLoadBuilderRequestFactory, CollectionLoadBuilderRequestFactory>();
            sc.AddScoped<ICollectionLoadRequestFactory, CollectionLoadRequestFactory>();
            sc.AddScoped<ICollectionLoadResponseUtil, CollectionLoadResponseUtil>();
            sc.AddScoped<ICollectionLoadStatement, SQLCollectionLoadArbitrary>();
            sc.AddScoped<ICollectionLoadStatementRequestFactory, CollectionLoadStatementRequestFactory>();
            sc.AddScoped<ICollectionNonTriggerDeleteRequestFactory, CollectionNonTriggerDeleteRequestFactory>();
            sc.AddScoped<ICollectionNonTriggerInsertRequestFactory, CollectionNonTriggerInsertRequestFactory>();
            sc.AddScoped<ICollectionNonTriggerUpdateRequestFactory, CollectionNonTriggerUpdateRequestFactory>();
            sc.AddScoped<ICollectionToListConvertor, CollectionToListConvertor>();
            sc.AddScoped<ICollectionUpdate>(s => timerFactory.Create<ICollectionUpdate>(s.GetService<SQLCollectionUpdate>()));
            sc.AddScoped<ICollectionUpdateRequestFactory, CollectionUpdateRequestFactory>();
            sc.AddScoped<ICommandExecutor, SQLCommandExecutor>();
            sc.AddScoped<ICommandParameters, SQLCommandParameters>();
            sc.AddScoped<IConvertToUtil, ConvertToUtil>();
            sc.AddScoped<ICOShippingPopulateTmpShp, COShippingPopulateTmpShp>();
            sc.AddScoped<ICountTasksAndMessages, CountTasksAndMessages>();
            sc.AddScoped<ICSIRemoteMethodCall, CSIRemoteMethodCall>();
            sc.AddScoped<ICSIRequesterFactory, CSIRequesterFactory>();
            sc.AddScoped<ICurrCnvt>(s => new CurrCnvtCache(s.GetService<CurrCnvt>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<ICurrentMaterialsDelete>(s => timerFactory.Create<ICurrentMaterialsDelete>(s.GetService<CurrentMaterialsDelete>()));
            sc.AddScoped<ICurrentMaterialsDeleteCRUD, CurrentMaterialsDeleteCRUD>();
            sc.AddScoped<ICurrentMaterialsJobItemData>(s => timerFactory.Create<ICurrentMaterialsJobItemData>(s.GetService<CurrentMaterialsJobItemData>()));
            sc.AddScoped<ICurrentMaterialsJobItemDataCRUD, CurrentMaterialsJobItemDataCRUD>();
            sc.AddScoped<ICurrentMaterialsOperChg>(s => timerFactory.Create<ICurrentMaterialsOperChg>(s.GetService<CurrentMaterialsOperChg>()));
            sc.AddScoped<ICurrentMaterialsOperChgCRUD, CurrentMaterialsOperChgCRUD>();
            sc.AddScoped<ICustGlobal>(s => timerFactory.Create<ICustGlobal>(s.GetService<CustGlobal>()));
            sc.AddScoped<ICustGlobalCRUD, CustGlobalCRUD>();
            sc.AddScoped<ICustomerOrderCount>(s => timerFactory.Create<ICustomerOrderCount>(s.GetService<CustomerOrderCount>()));
            sc.AddScoped<ICustomerOrderCountCRUD, CustomerOrderCountCRUD>();
            sc.AddScoped<ICustomerQuoteExistsWarning>(s => timerFactory.Create<ICustomerQuoteExistsWarning>(s.GetService<CustomerQuoteExistsWarning>()));
            sc.AddScoped<ICustomerQuoteExistsWarningCRUD, CustomerQuoteExistsWarningCRUD>();
            sc.AddScoped<ICustomerSpecificUnitPriceExists, CustomerSpecificUnitPriceExists>();
            sc.AddScoped<ICustSpecificUnitPriceExists>(s => timerFactory.Create<ICustSpecificUnitPriceExists>(s.GetService<CustSpecificUnitPriceExists>()));
            sc.AddScoped<ICustSpecificUnitPriceExistsCRUD, CustSpecificUnitPriceExistsCRUD>();
            sc.AddScoped<IDataCollector, DataCollector>();
            sc.AddScoped<IExportProcessor, ExportProcessor>();
            sc.AddScoped<IDataTableToCollectionLoadResponse, DataTableToCollectionLoadResponse>();
            sc.AddScoped<IDataTableUtil, DataTableUtil>();
            sc.AddScoped<IDataTypeUtil, DataTypeUtil>();
            sc.AddScoped<IDateTimeUtil, DateTimeUtil>();
            sc.AddScoped<IDayEndOf, DayEndOf>();
            sc.AddScoped<IDefineProcessVariable, DefineProcessVariable>();
            sc.AddScoped<IDefineVariable, DefineVariable>();
            sc.AddScoped<IDerSlsmanName, DerSlsmanName>();
            sc.AddScoped<IDictionaryToXmlConvertor, DictionaryToXmlConvertor>();
            sc.AddScoped<IDocumentIDName, DocumentIDName>();
            sc.AddScoped<IDocumentObjectReference, DocumentObjectReference>();
            sc.AddScoped<IDocumentObjectReferenceBookmarkRowData, DocumentObjectReferenceBookmarkRowData>();
            sc.AddScoped<IDocumentObjectReferenceCreateTaskWithWhereClause, DocumentObjectReferenceCreateTaskWithWhereClause>();
            sc.AddScoped<IDocumentObjectReferenceCRUD, DocumentObjectReferenceCRUD>();
            sc.AddScoped<IDocumentObjectReferenceTask, DocumentObjectReferenceTask>();
            sc.AddScoped<IDocumentObjectReferenceWhereClause, DocumentObjectReferenceWhereClause>();
            sc.AddScoped<IESBInventoryHoldLoadViewsItemLocationMove>(s => timerFactory.Create<IESBInventoryHoldLoadViewsItemLocationMove>(s.GetService<ESBInventoryHoldLoadViewsItemLocationMove>()));
            sc.AddScoped<IESBInventoryHoldLoadViewsItemLocationMoveCRUD, ESBInventoryHoldLoadViewsItemLocationMoveCRUD>();
            sc.AddScoped<IESBInventoryHoldLoadViewsLots>(s => timerFactory.Create<IESBInventoryHoldLoadViewsLots>(s.GetService<ESBInventoryHoldLoadViewsLots>()));
            sc.AddScoped<IESBInventoryHoldLoadViewsNewHoldCodes>(s => timerFactory.Create<IESBInventoryHoldLoadViewsNewHoldCodes>(s.GetService<ESBInventoryHoldLoadViewsNewHoldCodes>()));
            sc.AddScoped<IESBInventoryHoldLoadViewsOldHoldCodes>(s => timerFactory.Create<IESBInventoryHoldLoadViewsOldHoldCodes>(s.GetService<ESBInventoryHoldLoadViewsOldHoldCodes>()));
            sc.AddScoped<IESBReceiveShipLineViewsReceiveLocation>(s => timerFactory.Create<IESBReceiveShipLineViewsReceiveLocation>(s.GetService<ESBReceiveShipLineViewsReceiveLocation>()));
            sc.AddScoped<IEvaluateDatatypesUtil, EvaluateDatatypesUtil>();
            sc.AddScoped<IExecuteDynamicSQL, ExecuteDynamicSQL>();
            sc.AddScoped<IExistsChecker, ExistsChecker>();
            sc.AddScoped<IExpandKyByType, ExpandKyByType>();
            sc.AddScoped<IExpectedReceiptsAPSItemChg>(s => timerFactory.Create<IExpectedReceiptsAPSItemChg>(s.GetService<ExpectedReceiptsAPSItemChg>()));
            sc.AddScoped<IExpectedReceiptsAPSItemChgCRUD, ExpectedReceiptsAPSItemChgCRUD>();
            sc.AddScoped<IExportTask, ExportTask>();
            sc.AddScoped<IExportTaskHandler, ExportTaskHandler>();
            sc.AddScoped<IExportDataHandler, ExportDataHandler>();
            sc.AddScoped<IExportSiteTaskListener, ExportSiteTaskListener>();
            sc.AddScoped<IExportSiteTaskProcessor>(s => timerFactory.Create<IExportSiteTaskProcessor>(s.GetService<ExportSiteTaskProcessor>()));
            sc.AddScoped<IExternalHoldCodeCRUD, ExternalHoldCodeCRUD>();
            sc.AddScoped<IExternalLot, ExternalLot>();
            sc.AddScoped<IExternalWarehouse, ExternalWarehouse>();
            sc.AddScoped<IExternalWorkkey, ExternalWorkkey>();
            sc.AddScoped<IExtPrIfErrorSave>(s => timerFactory.Create<IExtPrIfErrorSave>(s.GetService<ExtPrIfErrorSave>()));
            sc.AddScoped<IExtPrIfErrorSaveCRUD, ExtPrIfErrorSaveCRUD>();
            sc.AddScoped<IFileNameUtil, FileNameUtil>();
            sc.AddScoped<IFileInfoHandler, FileInfoHandler>();
            sc.AddScoped<IFileContent, FileContent>();
            sc.AddScoped<IFileHandler, FileHandler>();
            sc.AddScoped<IFileServerLogicalFolder, FileServerLogicalFolder>();
            sc.AddScoped<IFileServerLogicalFolderCRUD, FileServerLogicalFolderCRUD>();
            sc.AddScoped<IFixMaskForCrystal, FixMaskForCrystal>();
            sc.AddScoped<IFmtJob, FmtJob>();
            sc.AddScoped<IFreightRateShopRequestManager, FreightRateShopRequestManager>();
            sc.AddScoped<IFreightRateShopResponseHandler, FreightRateShopResponseHandler>();
            sc.AddScoped<IFreightRateShopShipmentCommodityManager, FreightRateShopShipmentCommodityManager>();
            sc.AddScoped<IFreightRateShopShipmentManager, FreightRateShopShipmentManager>();
            sc.AddScoped<IFreightRateShopShipmentPackageManager, FreightRateShopShipmentPackageManager>();
            sc.AddScoped<IGainLossAr, GainLossAr>();
            sc.AddScoped<IGeneratePLJPKV7MXML>(s => timerFactory.Create<IGeneratePLJPKV7MXML>(s.GetService<GeneratePLJPKV7MXML>()));
            sc.AddScoped<IGetCode, GetCode>();
            sc.AddScoped<IGetCodeDesc, GetCodeDesc>();
            sc.AddScoped<IGetFreightRateShop>(s => timerFactory.Create<IGetFreightRateShop>(s.GetService<GetFreightRateShop>()));
            sc.AddScoped<IGetFreightRateShopRequest, GetFreightRateShopRequest>();
            sc.AddScoped<IGetFreightRateShopRequestCRUD, GetFreightRateShopRequestCRUD>();
            sc.AddScoped<IGetIsolationLevel, GetIsolationLevel>();
            sc.AddScoped<IGetKeyLength, GetKeyLength>();
            sc.AddScoped<IGetLabel>(s => new GetLabelCache(s.GetService<GetLabel>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IGetSiteDate, GetSiteDate>();
            sc.AddScoped<IGetSQLDateTime, GetSQLDateTime>();
            sc.AddScoped<IGetumcf, Getumcf>();
            sc.AddScoped<IGetumcf>(s => new GetumcfCache(s.GetService<Getumcf>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IGetUMConvFactor, GetUMConvFactor>();
            sc.AddScoped<IGetVariable, GetVariable>();
            sc.AddScoped<IGetWinRegDecGroup, GetWinRegDecGroup>();
            sc.AddScoped<IHighAnyInt>(s => new HighAnyIntCache(s.GetService<HighAnyInt>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IHighCharacter>(s => new HighCharacterCache(s.GetService<HighCharacter>()));
            sc.AddScoped<IHighDate>(s => new HighDateCache(s.GetService<HighDate>()));
            sc.AddScoped<IHighDecimal>(s => new HighDecimalCache(s.GetService<HighDecimal>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IHighInt>(s => new HighIntCache(s.GetService<HighInt>()));
            sc.AddScoped<IHighString>(s => new HighStringCache(s.GetService<HighString>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IHoldCode, HoldCode>();
            sc.AddScoped<IHoldCodeAndItemNonNettableLocation, HoldCodeAndItemNonNettableLocation>();
            sc.AddScoped<IHome_BGTaskAnalysis>(s => timerFactory.Create<IHome_BGTaskAnalysis>(s.GetService<Home_BGTaskAnalysis>()));
            sc.AddScoped<IHome_MetricJobWIP>(s => timerFactory.Create<IHome_MetricJobWIP>(s.GetService<Home_MetricJobWIP>()));
            sc.AddScoped<IHome_MetricJobWIPCRUD, Home_MetricJobWIPCRUD>();
            sc.AddScoped<IHome_VchPay>(s => timerFactory.Create<IHome_VchPay>(s.GetService<Home_VchPay>()));
            sc.AddScoped<IHome_VchPayBuildPoFilterCondition, Home_VchPayBuildPoFilterCondition>();
            sc.AddScoped<IHomepage_TotalSales>(s => timerFactory.Create<IHomepage_TotalSales>(s.GetService<Homepage_TotalSales>()));
            sc.AddScoped<IImportDataCRUD, ImportDataCRUD>();
            sc.AddScoped<IImportDataHandler, ImportDataHandler>();
            sc.AddScoped<IImportHeaderInfoCRUD, ImportHeaderInfoCRUD>();
            sc.AddScoped<IImportHeaderInfo, ImportHeaderInfo>();
            sc.AddScoped<IImportProcessor, ImportProcessor>();
            sc.AddScoped<IImportSiteTaskListener, ImportSiteTaskListener>();
            sc.AddScoped<ITaskNavigator, TaskNavigator>();
            sc.AddScoped<IImportSiteTaskNavigatorCRUD, ImportSiteTaskNavigatorCRUD>();
            sc.AddScoped<IImportSiteTaskProcessor>(s => timerFactory.Create<IImportSiteTaskProcessor>(s.GetService<ImportSiteTaskProcessor>()));
            sc.AddScoped<IImportTaskCreator, ImportTaskCreator>();
            sc.AddScoped<IImportTaskHandler, ImportTaskHandler>();
            sc.AddScoped<IImportSiteTaskNavigatorCRUD, ImportSiteTaskNavigatorCRUD>();
            sc.AddScoped<IInitSessionContext, InitSessionContext>();
            sc.AddScoped<IInventoryHoldLoadPreOperation, InventoryHoldLoadPreOperation>();
            sc.AddScoped<IIsAddonAvailable, IsAddonAvailable>();
            sc.AddScoped<IIsFeatureActive, IsFeatureActive>();
            sc.AddScoped<IIsInteger, IsInteger>();
            sc.AddScoped<IItemLocAdd, ItemLocAdd>();
            sc.AddScoped<IItemLocationCRUD, ItemLocationCRUD>();
            sc.AddScoped<IItemLocationProcessor, ItemLocationProcessor>();
            sc.AddScoped<IItemLotCRUD, ItemLotCRUD>();
            sc.AddScoped<IItemLotLocCRUD, ItemLotLocCRUD>();
            sc.AddScoped<IItemNonNettableLocation, ItemNonNettableLocation>();
            sc.AddScoped<IItemNonNettableLocationForWarehouse, ItemNonNettableLocationForWarehouse>();
            sc.AddScoped<IItemWarehouseCRUD, ItemWarehouseCRUD>();
            sc.AddScoped<IJPKV7MDeclarationsFactory, JPKV7MDeclarationsFactory>();
            sc.AddScoped<IJPKV7MDeclarationsManager>(s => timerFactory.Create<IJPKV7MDeclarationsManager>(s.GetService<JPKV7MDeclarationsManager>()));
            sc.AddScoped<IJPKV7MPurchaseControlFactory, JPKV7MPurchaseControlFactory>();
            sc.AddScoped<IJPKV7MPurchaseRegisterFactory, JPKV7MPurchaseRegisterFactory>();
            sc.AddScoped<IJPKV7MSalesControlFactory, JPKV7MSalesControlFactory>();
            sc.AddScoped<IJPK7MSalesRegisterFactory, JPK7MSalesRegisterFactory>();
            sc.AddScoped<ILoadRequestVariablesUpdate, LoadRequestVariablesUpdate>();
            sc.AddScoped<ILogicalFolderCRUD, LogicalFolderCRUD>();
            sc.AddScoped<ILogger, SQLLogger>();
            sc.AddScoped<ILotAdd, LotAdd>();
            sc.AddScoped<ILotAndSNTrackedFlag, LotAndSNTrackedFlag>();
            sc.AddScoped<ILotAndSNTrackedFlagCRUD, LotAndSNTrackedFlagCRUD>();
            sc.AddScoped<ILotAndSNTrackedItem, LotAndSNTrackedItem>();
            sc.AddScoped<ILowAnyInt>(s => new LowAnyIntCache(s.GetService<LowAnyInt>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<ILowCharacter>(s => new LowCharacterCache(s.GetService<LowCharacter>()));
            sc.AddScoped<ILowDate>(s => new LowDateCache(s.GetService<LowDate>()));
            sc.AddScoped<ILowDecimal>(s => new LowDecimalCache(s.GetService<LowDecimal>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<ILowInt>(s => new LowIntCache(s.GetService<LowInt>()));
            sc.AddScoped<ILowString>(s => new LowStringCache(s.GetService<LowString>(), new IDOMethodCallBoundedMemoryCache()));
            sc.AddScoped<IMathUtil, MathUtil>();
            sc.AddScoped<IMemoryBasedCache, IDOMethodCallBoundedMemoryCache>();
            sc.AddScoped<IMGBunchedRequest, SQLBunchedRequest>();
            sc.AddScoped<IMGInvoker, SQLInvoker>();
            sc.AddScoped<IMidnightOf, MidnightOf>();
            sc.AddScoped<IMisReceiptItemWhseGetCostValues, MisReceiptItemWhseGetCostValues>();
            sc.AddScoped<IMsgApp, MsgApp>();
            sc.AddScoped<IMvPost, MvPost>();
            sc.AddScoped<INullableForeignKeyColumnAcquisition, NullableForeignKeyColumnAcquisition>();
            sc.AddScoped<INullableForeignKeyHandler, NullableForeignKeyHandler>();
            sc.AddScoped<IObjectNote, ObjectNote>();
            sc.AddScoped<IObjectNoteBookmarkRowData, ObjectNoteBookmarkRowData>();
            sc.AddScoped<IObjectNoteCreateTaskWithWhereClause, ObjectNoteCreateTaskWithWhereClause>();
            sc.AddScoped<IObjectNoteCRUD, ObjectNoteCRUD>();
            sc.AddScoped<IObjectNoteTask, ObjectNoteTask>();
            sc.AddScoped<IObjectNoteTaskSpecificNotes, ObjectNoteTaskSpecificNotes>();
            sc.AddScoped<IObjectNoteTaskSystemNotes, ObjectNoteTaskSystemNotes>();
            sc.AddScoped<IObjectNoteTaskUserNotes, ObjectNoteTaskUserNotes>();
            sc.AddScoped<IObjectNoteWhereClause, ObjectNoteWhereClause>();
            sc.AddScoped<IParameterProvider, SQLParameterProvider>();
            sc.AddScoped<IPLJPKVATHeaderViewsFactory, PLJPKVATHeaderViewsFactory>();
            sc.AddScoped<IPendingTable, PendingTable>();
            sc.AddScoped<IProcessFreightRateShopRequest>(s => timerFactory.Create<IProcessFreightRateShopRequest>(s.GetService<ProcessFreightRateShopRequest>()));
            sc.AddScoped<IProcessFreightRateShopRequestCRUD, ProcessFreightRateShopRequestCRUD>();
            sc.AddScoped<IProcessVariableProvider, SQLProcessVariableProvider>();
            sc.AddScoped<IProfileShipmentProFormaInvoiceCRUD, ProfileShipmentProFormaInvoiceCRUD>();
            sc.AddScoped<IProfileShipmentProFormaInvoice, ProfileShipmentProFormaInvoice>();
            sc.AddScoped<IPurchaseOrderLocation, PurchaseOrderLocation>();
            sc.AddScoped<IPurchaseOrderLocationCRUD, PurchaseOrderLocationCRUD>();
            sc.AddScoped<IPurchaseOrderNonNettableLocation, PurchaseOrderNonNettableLocation>();
            sc.AddScoped<IQueryLanguage>(s => timerFactory.Create<IQueryLanguage>(s.GetService<SQLQueryLanguage>()));
            sc.AddScoped<IRaiseError, RaiseError>();
            sc.AddScoped<IRecordBunchFactory, RecordBunchFactory>();
            sc.AddScoped<IRecordCollectionToDataTable, RecordCollectionToDataTable>();
            sc.AddScoped<IRecordStreamFactory, RecordStreamFactory>();
            sc.AddScoped<IRptVAT, RptVAT>();
            sc.AddScoped<IRptVATManager, RptVATManager>();
            sc.AddScoped<IRptVATValuesFromSp, RptVATValuesFromSp>();
            sc.AddScoped<IRptVATValuesFromSpCRUD, RptVATValuesFromSpCRUD>();
            sc.AddScoped<IRelevantDataExporter, RelevantDataExporter>();
            sc.AddScoped<IRelevantDocObject, RelevantDocObject>();
            sc.AddScoped<IRelevantDocObjectReference, RelevantDocObjectReference>();
            sc.AddScoped<IRelevantNoteHeader, RelevantNoteHeader>();
            sc.AddScoped<IRelevantObjectNotes, RelevantObjectNotes>();
            sc.AddScoped<IRelevantSpecificNotes, RelevantSpecificNotes>();
            sc.AddScoped<IRelevantSystemNotes, RelevantSystemNotes>();
            sc.AddScoped<IRelevantUDF, RelevantUDF>();
            sc.AddScoped<IRelevantUserNotes, RelevantUserNotes>();
            sc.AddScoped<IRestoreTriggerState, RestoreTriggerState>();
            sc.AddScoped<IRpt_AccountsReceivableAging>(s => timerFactory.Create<IRpt_AccountsReceivableAging>(s.GetService<Rpt_AccountsReceivableAging>()));
            sc.AddScoped<IRpt_EmpChildPrivacy>(s => timerFactory.Create<IRpt_EmpChildPrivacy>(s.GetService<Rpt_EmpChildPrivacy>()));
            sc.AddScoped<IRpt_EmpChildPrivacyCRUD, Rpt_EmpChildPrivacyCRUD>();
            sc.AddScoped<IRpt_GetGoBDMediaData>(s => timerFactory.Create<IRpt_GetGoBDMediaData>(s.GetService<Rpt_GetGoBDMediaData>()));
            sc.AddScoped<IRpt_GOBDUMediaService, Rpt_GOBDUMediaPicker>();
            sc.AddScoped<IRpt_InventoryCost>(s => timerFactory.Create<IRpt_InventoryCost>(s.GetService<Rpt_InventoryCost>()));
            sc.AddScoped<IRpt_InventoryCostCRUD, Rpt_InventoryCostCRUD>();
            sc.AddScoped<IRpt_MXVATARPost>(s => timerFactory.Create<IRpt_MXVATARPost>(s.GetService<Rpt_MXVATARPost>()));
            sc.AddScoped<IRpt_MXVATARPostCRUD, Rpt_MXVATARPostCRUD>();
            sc.AddScoped<IRpt_ServiceContractPrivacy>(s => timerFactory.Create<IRpt_ServiceContractPrivacy>(s.GetService<Rpt_ServiceContractPrivacy>()));
            sc.AddScoped<IRpt_ServiceContractPrivacyCRUD, Rpt_ServiceContractPrivacyCRUD>();
            sc.AddScoped<IRpt_VAT, Rpt_VAT>();
            sc.AddScoped<IRpt_SLAptrxps, Rpt_SLAptrxps>();
            sc.AddScoped<IRpt_SLArtrans, Rpt_SLArtrans>();
            sc.AddScoped<IRpt_SLBankAddrs, Rpt_SLBankAddrs>();
            sc.AddScoped<IRpt_SLBankHdrs, Rpt_SLBankHdrs>();
            sc.AddScoped<IRpt_SLCharts, Rpt_SLCharts>();
            sc.AddScoped<IRpt_SLCoitems, Rpt_SLCoitems>();
            sc.AddScoped<IRpt_SLCos, Rpt_SLCos>();
            sc.AddScoped<IRpt_SLCurrates, Rpt_SLCurrates>();
            sc.AddScoped<IRpt_SLCurrencyCodes, Rpt_SLCurrencyCodes>();
            sc.AddScoped<IRpt_SLCustomers, Rpt_SLCustomers>();
            sc.AddScoped<IRpt_SLDepts, Rpt_SLDepts>();
            sc.AddScoped<IRpt_SLEmployees, Rpt_SLEmployees>();
            sc.AddScoped<IRpt_SLEmpPrBanks, Rpt_SLEmpPrBanks>();
            sc.AddScoped<IRpt_SLFaclasses, Rpt_SLFaclasses>();
            sc.AddScoped<IRpt_SLFaCosts, Rpt_SLFaCosts>();
            sc.AddScoped<IRpt_SLFaDeprs, Rpt_SLFaDeprs>();
            sc.AddScoped<IRpt_SLFaDisps, Rpt_SLFaDisps>();
            sc.AddScoped<IRpt_SLFamasters, Rpt_SLFamasters>();
            sc.AddScoped<IRpt_SLFaTrans, Rpt_SLFaTrans>();
            sc.AddScoped<IRpt_SLInvHdrs, Rpt_SLInvHdrs>();
            sc.AddScoped<IRpt_SLInvItemAlls, Rpt_SLInvItemAlls>();
            sc.AddScoped<IRpt_SLInvItemSurcharges, Rpt_SLInvItemSurcharges>();
            sc.AddScoped<IRpt_SLInvStaxs, Rpt_SLInvStaxs>();
            sc.AddScoped<IRpt_SLItemContentRefs, Rpt_SLItemContentRefs>();
            sc.AddScoped<IRpt_SLItems, Rpt_SLItems>();
            sc.AddScoped<IRpt_SLJourHdrs, Rpt_SLJourHdrs>();
            sc.AddScoped<IRpt_SLLedgers, Rpt_SLLedgers>();
            sc.AddScoped<IRpt_SLNonInventoryItems, Rpt_SLNonInventoryItems>();
            sc.AddScoped<IRpt_SLPoItems, Rpt_SLPoItems>();
            sc.AddScoped<IRpt_SLPos, Rpt_SLPos>();
            sc.AddScoped<IRpt_SLPrbanks, Rpt_SLPrbanks>();
            sc.AddScoped<IRpt_SLPrdecds, Rpt_SLPrdecds>();
            sc.AddScoped<IRpt_SLProjMatls, Rpt_SLProjMatls>();
            sc.AddScoped<IRpt_SLProjs, Rpt_SLProjs>();
            sc.AddScoped<IRpt_SLProjTasks, Rpt_SLProjTasks>();
            sc.AddScoped<IRpt_SLProjTrans, Rpt_SLProjTrans>();
            sc.AddScoped<IRpt_SLPrtaxts, Rpt_SLPrtaxts>();
            sc.AddScoped<IRpt_SLPrtrxps, Rpt_SLPrtrxps>();
            sc.AddScoped<IRpt_SLTaxcodes, Rpt_SLTaxcodes>();
            sc.AddScoped<IRpt_SLTaxJurs, Rpt_SLTaxJurs>();
            sc.AddScoped<IRpt_SLUMs, Rpt_SLUMs>();
            sc.AddScoped<IRpt_SLUnitcd1s, Rpt_SLUnitcd1s>();
            sc.AddScoped<IRpt_SLUnitcd2s, Rpt_SLUnitcd2s>();
            sc.AddScoped<IRpt_SLUnitcd3s, Rpt_SLUnitcd3s>();
            sc.AddScoped<IRpt_SLUnitcd4s, Rpt_SLUnitcd4s>();
            sc.AddScoped<IRpt_SLVchHdrs, Rpt_SLVchHdrs>();
            sc.AddScoped<IRpt_SLVchItemAlls, Rpt_SLVchItemAlls>();
            sc.AddScoped<IRpt_SLVchStaxs, Rpt_SLVchStaxs>();
            sc.AddScoped<IRpt_SLVendors, Rpt_SLVendors>();
            sc.AddScoped<IRpt_VouchersPayable>(s => timerFactory.Create<IRpt_VouchersPayable>(s.GetService<Rpt_VouchersPayable>()));
            sc.AddScoped<IRpt_VouchersPayableCRUD, Rpt_VouchersPayableCRUD>();
            sc.AddScoped<IRpt_VouchersPayableSub, Rpt_VouchersPayableSub>();
            sc.AddScoped<IRpt_VouchersPayableSubCRUD, Rpt_VouchersPayableSubCRUD>();
            sc.AddScoped<IRSQC_CalcInterval>(s => timerFactory.Create<IRSQC_CalcInterval>(s.GetService<RSQC_CalcInterval>()));
            sc.AddScoped<IRSQC_CalcIntervalCRUD, RSQC_CalcIntervalCRUD>();
            sc.AddScoped<IRSQC_GetHoldLoc>(s => timerFactory.Create<IRSQC_GetHoldLoc>(s.GetService<RSQC_GetHoldLoc>()));
            sc.AddScoped<IRSQC_GetHoldLocCRUD, RSQC_GetHoldLocCRUD>();
            sc.AddScoped<IRSQC_GetItemUM>(s => timerFactory.Create<IRSQC_GetItemUM>(s.GetService<RSQC_GetItemUM>()));
            sc.AddScoped<IRSQC_GetItemUMCRUD, RSQC_GetItemUMCRUD>();
            sc.AddScoped<IRSQC_GetRmaparmsLoc>(s => timerFactory.Create<IRSQC_GetRmaparmsLoc>(s.GetService<RSQC_GetRmaparmsLoc>()));
            sc.AddScoped<IRSQC_GetRmaparmsLocCRUD, RSQC_GetRmaparmsLocCRUD>();
            sc.AddScoped<IRSQC_GetXrefItemData>(s => timerFactory.Create<IRSQC_GetXrefItemData>(s.GetService<RSQC_GetXrefItemData>()));
            sc.AddScoped<IRSQC_GetXrefItemDataCRUD, RSQC_GetXrefItemDataCRUD>();
            sc.AddScoped<IRSQC_Parmcu>(s => timerFactory.Create<IRSQC_Parmcu>(s.GetService<RSQC_Parmcu>()));
            sc.AddScoped<IRSQC_ParmcuCRUD, RSQC_ParmcuCRUD>();
            sc.AddScoped<ISalesOrderLocation, SalesOrderLocation>();
            sc.AddScoped<ISalesOrderLocationCRUD, SalesOrderLocationCRUD>();
            sc.AddScoped<ISalesOrderNonNettableLocation, SalesOrderNonNettableLocation>();
            sc.AddScoped<ISaveVchProceduralMarkings>(s => timerFactory.Create<ISaveVchProceduralMarkings>(s.GetService<SaveVchProceduralMarkings>()));
            sc.AddScoped<ISaveVchProceduralMarkingsCRUD, SaveVchProceduralMarkingsCRUD>();
            sc.AddScoped<ISerialSave, SerialSave>();
            sc.AddScoped<IScalarFunction, ScalarFunction>();
            sc.AddScoped<ISchemaLevelChecker, SchemaLevelChecker>();
            sc.AddScoped<ISchemaLevelCRUD, SchemaLevelCRUD>();
            sc.AddScoped<ISerializerFactory, SerializerFactory>();
            sc.AddScoped<ISerializer, NullSerializer>();
            sc.AddScoped<ISessionBasedCache, MGSessionVariableBasedCache>();
            sc.AddScoped<ISessionID, SessionID>();
            sc.AddScoped<ISetSite, MGSetSite>();
            sc.AddScoped<ISetTriggerState, SetTriggerState>();
            sc.AddScoped<IShipmentTMResponseDeserializer, ShipmentTMResponseDeserializer>();
            sc.AddScoped<IShipmentOrderIdGenerator, ShipmentOrderIdGenerator>();
            sc.AddScoped<IShipmentPackageFreightClass>(s => timerFactory.Create<IShipmentPackageFreightClass>(s.GetService<ShipmentPackageFreightClass>()));
            sc.AddScoped<IShipmentPackageFreightClassCRUD, ShipmentPackageFreightClassCRUD>();
            sc.AddScoped<ISiteDataBoundary, SiteDataBoundary>();
            sc.AddScoped<ISiteExportTaskDistributor, SiteExportTaskDistributor>();
            sc.AddScoped<ISiteImportTaskDistributor, SiteImportTaskDistributor>();
            sc.AddScoped<ISiteTaskListener, SiteTaskListener>();
            sc.AddScoped<ISiteStatusHandler, SiteStatusHandler>();
            sc.AddScoped<ISNTrackedItem, SNTrackedItem>();
            sc.AddScoped<ISortOrderFactory, SortOrderFactory>();
            sc.AddScoped<ISQLBulkCopyFactory, SQLBulkCopyFactory>();
            sc.AddScoped<ISQLCollectionLoad, SQLExpressionExecutor>();
            sc.AddScoped<ISQLCollectionLoadBuilderProcess, SQLCollectionLoadBuilderProcess>();
            sc.AddScoped<ISQLCollectionLoadProcess, SQLCollectionLoadProcess>();
            sc.AddScoped<ISQLCollectionNonTriggerDelete>(s => timerFactory.Create<ISQLCollectionNonTriggerDelete>(s.GetService<SQLCollectionNonTriggerDelete>()));
            sc.AddScoped<ISQLCollectionNonTriggerInsert>(s => timerFactory.Create<ISQLCollectionNonTriggerInsert>(s.GetService<SQLCollectionNonTriggerInsert>()));
            sc.AddScoped<ISQLCollectionNonTriggerUpdate>(s => timerFactory.Create<ISQLCollectionNonTriggerUpdate>(s.GetService<SQLCollectionNonTriggerUpdate>()));
            sc.AddScoped<ISQLExpressionExecutor, SQLExpressionExecutor>();
            sc.AddScoped<ISqlFilter, SqlFilter>();
            sc.AddScoped<ISQLParameterizedCommandFactory, SQLParameterizedCommandFactory>();
            sc.AddScoped<ISQLValueComparerUtil, SQLValueComparerUtil>();
            sc.AddScoped<ISSSFSExpenseReconSave>(s => timerFactory.Create<ISSSFSExpenseReconSave>(s.GetService<SSSFSExpenseReconSave>()));
            sc.AddScoped<ISSSFSExpenseReconSaveCRUD, SSSFSExpenseReconSaveCRUD>();
            sc.AddScoped<ISSSTraceStart, SSSTraceStart>();
            sc.AddScoped<ISSSTraceStartWrap>(s => timerFactory.Create<ISSSTraceStartWrap>(s.GetService<SSSTraceStartWrap>()));
            sc.AddScoped<ISSSTraceStartWrapCRUD, SSSTraceStartWrapCRUD>();
            sc.AddScoped<IStatusHandler, StatusHandler>();
            sc.AddScoped<IStreamReaderUtilFactory, StreamReaderUtilFactory>();
            sc.AddScoped<IStringOf, StringOf>();
            sc.AddScoped<IStringUtil, StringUtil>();
            sc.AddScoped<ITableColumnsCRUD, TableColumnsCRUD>();
            sc.AddScoped<ITaskDataCollectorCRUD, TaskDataCollectorCRUD>();
            sc.AddScoped<ITableDataExporter, TableDataExporter>();
            sc.AddScoped<ITableDataImporter, TableDataImporter>();
            sc.AddScoped<ITableNameCRUD, TableNameCRUD>();
            sc.AddScoped<ITableReferenceInfoList, TableReferenceInfoList>();
            sc.AddScoped<ITablePrimaryKeyCache, SQLTablePrimaryKeyCache>();
            sc.AddScoped<ITableSchemaCache, SQLTableSchemaCache>();
            sc.AddScoped<ITableStatusHandler, TableStatusHandler>();
            sc.AddScoped<ITagErrorMessage, TagErrorMessage>();
            sc.AddScoped<ITargetFileName, TargetFileName>();
            sc.AddScoped<ITaskDistributionBookmarkRowData, TaskDistributionBookmarkRowData>();
            sc.AddScoped<ITaskDistributionBookmarkRowDataCRUD, TaskDistributionBookmarkRowDataCRUD>();
            sc.AddScoped<ITaskDistributionCreateTaskWithWhereClause, TaskDistributionCreateTaskWithWhereClause>();
            sc.AddScoped<ITaskDistributionWhereClause, TaskDistributionWhereClause>();
            sc.AddScoped<ITaskStatusHandler, TaskStatusHandler>();
            sc.AddScoped<ITaskInfo, TaskInfo>();
            sc.AddScoped<ITmpSiteMgmtDataCRUD, TmpSiteMgmtDataCRUD>();
            sc.AddScoped<ITmpSiteMgmtTableData, TmpSiteMgmtTableData>();
            sc.AddScoped<ITmpSiteMgmtTableDataHandler, TmpSiteMgmtTableDataHandler>();
            sc.AddScoped<ITmpSiteMgmtTableDataCRUD, TmpSiteMgmtTableDataCRUD>();
            sc.AddScoped<ITmpSiteMgmtTableDataProcessor, TmpSiteMgmtTableDataProcessor>();
            sc.AddScoped<ITmpSiteMgmtTask, TmpSiteMgmtTask>();
            sc.AddScoped<ITmpSiteMgmtTaskCRUD, TmpSiteMgmtTaskCRUD>();
            sc.AddScoped<ITmpSiteMgmtTaskLoadColumnsCRUD, TmpSiteMgmtTaskLoadColumnsCRUD>();
            sc.AddScoped<ITransactionDate, TransactionDate>();
            sc.AddScoped<ITransactionFactory, TransactionFactory>();
            sc.AddScoped<ITransferOrderLocation, TransferOrderLocation>();
            sc.AddScoped<ITransferOrderLocationCRUD, TransferOrderLocationCRUD>();
            sc.AddScoped<ITransferOrderNonNettableLocation, TransferOrderNonNettableLocation>();
            sc.AddScoped<ITriggerManagement, TriggerManagement>();
            sc.AddScoped<ITwoCurrCnvt, TwoCurrCnvt>();
            sc.AddScoped<IUserDefinedField, UserDefinedField>();
            sc.AddScoped<IUserDefinedFieldBookmarkRowData, UserDefinedFieldBookmarkRowData>();
            sc.AddScoped<IUserDefinedFieldCreateTaskWithWhereClause, UserDefinedFieldCreateTaskWithWhereClause>();
            sc.AddScoped<IUserDefinedFieldCRUD, UserDefinedFieldCRUD>();
            sc.AddScoped<IUserDefinedFieldWhereClause, UserDefinedFieldWhereClause>();
            sc.AddScoped<IUndefineVariable, UndefineVariable>();
            sc.AddScoped<IUndefineVariable, UndefineVariable>();
            sc.AddScoped<IUnshipShipment, UnshipShipment>();
            sc.AddScoped<IUntagErrorMessage, UntagErrorMessage>();
            sc.AddScoped<IUomConvAmt, UomConvAmt>();
            sc.AddScoped<IUomConvQty, UomConvQty>();
            sc.AddScoped<IUpdateCurrentPeriodDepreciationToZero>(s => timerFactory.Create<IUpdateCurrentPeriodDepreciationToZero>(s.GetService<UpdateCurrentPeriodDepreciationToZero>()));
            sc.AddScoped<IUpdateCurrentPeriodDepreciationToZeroCRUD, UpdateCurrentPeriodDepreciationToZeroCRUD>();
            sc.AddScoped<IUpdateShipmentDetailsWithTMInfo, UpdateShipmentDetailsWithTMInfo>();
            sc.AddScoped<IUpdateShipmentDetailsWithTMInfoCRUD, UpdateShipmentDetailsWithTMInfoCRUD>();
            sc.AddScoped<IUpdateShipUnitDetailsWithTMInfo, UpdateShipUnitDetailsWithTMInfo>();
            sc.AddScoped<IUpdateShipUnitDetailsWithTMInfoCRUD, UpdateShipUnitDetailsWithTMInfoCRUD>();
            sc.AddScoped<IUpdateShipmentWithTMInfo>(s => timerFactory.Create<IUpdateShipmentWithTMInfo>(s.GetService<UpdateShipmentWithTMInfo>()));
            sc.AddScoped<IVariableUtil, VariableUtil>();
            sc.AddScoped<IWarehouseDefaultNonNettableLocation, WarehouseDefaultNonNettableLocation>();
            sc.AddScoped<IWarehouseDefaultNonNettableLocationCRUD, WarehouseDefaultNonNettableLocationCRUD>();
            sc.AddScoped<IWhereClauseForTask, WhereClauseForTask>();
            sc.AddScoped<IWhereClauseForUpdate, WhereClauseForUpdate>();
            sc.AddScoped<IXMLFileToServerManager, XMLFileToServerManager>();
            sc.AddScoped<IXMLFileToServerManagerCRUD, XMLFileToServerManagerCRUD>();
            sc.AddScoped<IXmlStringToDictionaryConvertor, XmlStringToDictionaryConvertor>();
            sc.AddScoped<IXmlTextWriterUtil, XmlTextWriterUtil>();
            sc.AddScoped<Logistics.Vendor.IInsertSiteGroupLoader, Logistics.Vendor.InsertSiteGroupLoader>();
            sc.AddScoped<ProcessFreightRateShopRequest>();
            sc.AddScoped<SQLQueryLanguage>();
            sc.AddScoped<ILiteralProvider, SQLLiteralProvider>();
            sc.AddTransient<IUnionUtil, UnionUtil>();

            #endregion interfaces

            return sc;
        }

        public ServiceCollection GetMongooseBasedServiceCollection(IMongooseDependencies mgDependencies)
        {
            var sc = this.GetServiceCollection();

            sc = this.AddApplicationClasses(sc);
            sc = this.AddMGDependencies(sc, mgDependencies); //if there are duplicates among the app classes, make sure the mongoose versions override by adding these last

            return sc;
        }

        public IServiceProvider BuildMongooseBasedServiceProvider(IMongooseDependencies mgDependencies)
        {
            return GetMongooseBasedServiceCollection(mgDependencies).BuildSyteLineServiceProvider();
        }

        public ServiceCollection GetSQLBasedServiceCollection(ISQLDependencies sqlDependencies)
        {
            var sc = this.GetServiceCollection();

            sc = this.AddApplicationClasses(sc);
            sc = this.AddSQLDependencies(sc, sqlDependencies); //if there are duplicates among the app classes, make sure the SQL versions override

            return sc;
        }

        public IServiceProvider BuildSQLBasedServiceProvider(ISQLDependencies sqlDependencies)
        {
            return GetSQLBasedServiceCollection(sqlDependencies).BuildSyteLineServiceProvider();
        }
    }
}