
//PROJECT NAME: CustomerExt
//CLASS NAME: SLControllerAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;
using CSI.Finance;
using CSI.Finance.AR;
using Microsoft.Extensions.DependencyInjection;
using CSI.Data.SQL;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLControllerAlls")]
    public class SLControllerAlls : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetCashFlowDataSp(string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_GetCashFlowDataExt = new CLM_GetCashFlowDataFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_GetCashFlowDataExt.CLM_GetCashFlowDataSp(SiteRef);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_MobileControllerSp(int? Position)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_MobileControllerExt = new CLM_MobileControllerFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_MobileControllerExt.CLM_MobileControllerSp(Position);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Home_GetTodaysKeyControllerValuesSp(ref decimal? BookingAmount,
                                                       ref decimal? ShipmentAmount,
                                                       ref decimal? InvoicedAmount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHome_GetTodaysKeyControllerValuesExt = new Home_GetTodaysKeyControllerValuesFactory().Create(appDb);

                int Severity = iHome_GetTodaysKeyControllerValuesExt.Home_GetTodaysKeyControllerValuesSp(ref BookingAmount,
                                                                                                         ref ShipmentAmount,
                                                                                                         ref InvoicedAmount);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricCashImpactSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHome_MetricCashImpactExt = new Home_MetricCashImpactFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHome_MetricCashImpactExt.Home_MetricCashImpactSp();

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CashImpactGraphSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CashImpactGraphExt = new CLM_CashImpactGraphFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_CashImpactGraphExt.CLM_CashImpactGraphSp();

                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_APCashImpactSp([Optional] string TransactionType,
                                            string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_APCashImpactExt = new CLM_APCashImpactFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_APCashImpactExt.CLM_APCashImpactSp(TransactionType,
                                                                     FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ARCashImpactSp([Optional] string TransactionType,
                                            [Optional] string FilterString)
        {
            var iCLM_ARCashImpactExt = new CLM_ARCashImpactFactory().Create(this, true);

            var result = iCLM_ARCashImpactExt.CLM_ARCashImpactSp(TransactionType,
                FilterString);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CashImpactGridSp([Optional] string TransactionType,
                                              [Optional] string FilterString)
        {
            var iCLM_CashImpactGridExt = new CLM_CashImpactGridFactory().Create(this, true);

            var result = iCLM_CashImpactGridExt.CLM_CashImpactGridSp(TransactionType, FilterString);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CoItemsBookingsSp([Optional] string Cust_Num,
                                               [Optional] DateTime? StartDate,
                                               [Optional] DateTime? EndDate,
                                               [Optional, DefaultParameterValue((byte)0)] byte? Detail,
        [Optional] string SiteRef,
        [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CoItemsBookingsExt = new CLM_CoItemsBookingsFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_CoItemsBookingsExt.CLM_CoItemsBookingsSp(Cust_Num,
                                                                           StartDate,
                                                                           EndDate,
                                                                           Detail,
                                                                           SiteRef,
                                                                           FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CoItemsShippingSp([Optional] string Cust_Num,
                                               [Optional] DateTime? StartDate,
                                               [Optional] DateTime? EndDate,
                                               [Optional, DefaultParameterValue((byte)0)] byte? Detail,
        [Optional] string SiteRef,
        [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CoItemsShippingExt = new CLM_CoItemsShippingFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_CoItemsShippingExt.CLM_CoItemsShippingSp(Cust_Num,
                                                                           StartDate,
                                                                           EndDate,
                                                                           Detail,
                                                                           SiteRef,
                                                                           FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CustomerAgingBucketsSp([Optional] string FilterString,
                                                    [Optional] string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CustomerAgingBucketsExt = new CLM_CustomerAgingBucketsFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_CustomerAgingBucketsExt.CLM_CustomerAgingBucketsSp(FilterString,
                                                                                     SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CustomerBalanceSp([Optional] string FilterString,
                                               [Optional] string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_CustomerBalanceExt = new CLM_CustomerBalanceFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_CustomerBalanceExt.CLM_CustomerBalanceSp(FilterString,
                                                                           SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_VendorAgingBucketsSp([Optional] string FilterString,
                                                  [Optional] string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_VendorAgingBucketsExt = new CLM_VendorAgingBucketsFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_VendorAgingBucketsExt.CLM_VendorAgingBucketsSp(FilterString,
                                                                                 SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_VendorBalanceSp([Optional] string FilterString,
            [Optional] string SiteRef)
        {
            var iCLM_VendorBalanceExt = new CLM_VendorBalanceFactory().Create(this, true);

            var result = iCLM_VendorBalanceExt.CLM_VendorBalanceSp(FilterString,
                SiteRef);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricDPOSp([Optional, DefaultParameterValue(0)] int? MultipleSites,
			[Optional] string SiteGroup,
			[Optional, DefaultParameterValue(6)] int? NumPeriods)
		{
			var iHome_MetricDPOExt = new Home_MetricDPOFactory().Create(this, true);
			
			var result = iHome_MetricDPOExt.Home_MetricDPOSp(MultipleSites,
				SiteGroup,
				NumPeriods);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricDSOSp([Optional, DefaultParameterValue((byte)0)] byte? MultipleSites,
        [Optional] string SiteGroup,
        [Optional, DefaultParameterValue(6)] int? NumPeriods)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHome_MetricDSOExt = new Home_MetricDSOFactory().Create(appDb, bunchedLoadCollection);

                var result = iHome_MetricDSOExt.Home_MetricDSOSp(MultipleSites,
                                                                 SiteGroup,
                                                                 NumPeriods);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricJobWIPSp([Optional, DefaultParameterValue(5)] int? Count)
		{
			var iHome_MetricJobWIPExt = new Home_MetricJobWIPFactory().Create(this, true);
			
			var result = iHome_MetricJobWIPExt.Home_MetricJobWIPSp(Count);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricOnTimeShipmentSp([Optional, DefaultParameterValue(4)] int? Count,
			[Optional, DefaultParameterValue(0)] int? MultipleSites,
			[Optional] string SiteGroup)
		{
			var iHome_MetricOnTimeShipmentExt = new Home_MetricOnTimeShipmentFactory().Create(this, true);
			
			var result = iHome_MetricOnTimeShipmentExt.Home_MetricOnTimeShipmentSp(Count,
				MultipleSites,
				SiteGroup);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricShippingSp([Optional, DefaultParameterValue(6)] int? NumberOfRows)
        {
            var iHome_MetricShippingExt = new Home_MetricShippingFactory().Create(this, true);

            var result = iHome_MetricShippingExt.Home_MetricShippingSp(NumberOfRows);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_AccountBalanceSp(DateTime? StartDate,
        DateTime? EndDate,
        string Acct,
        string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_AccountBalanceExt = new CLM_AccountBalanceFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_AccountBalanceExt.CLM_AccountBalanceSp(StartDate,
                EndDate,
                Acct,
                SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetAPBalanceSp([Optional] string Site)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_GetAPBalanceExt = new CLM_GetAPBalanceFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_GetAPBalanceExt.CLM_GetAPBalanceSp(Site);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetARBalanceSp()
        {
            var iCLM_GetARBalanceExt = new CLM_GetARBalanceFactory().Create(this, true);

            var result = iCLM_GetARBalanceExt.CLM_GetARBalanceSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetCashSummarySp()
        {
            var iCLM_GetCashSummaryExt = new CLM_GetCashSummaryFactory().Create(this, true);

            var result = iCLM_GetCashSummaryExt.CLM_GetCashSummarySp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_LastStagePipelineSp()
        {
            var iCLM_LastStagePipelineExt = new CLM_LastStagePipelineFactory().Create(this, true);

            var result = iCLM_LastStagePipelineExt.CLM_LastStagePipelineSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_MobileDPOSp(string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_MobileDPOExt = new CLM_MobileDPOFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_MobileDPOExt.CLM_MobileDPOSp(SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_MobileDSOSp([Optional] string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_MobileDSOExt = new CLM_MobileDSOFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_MobileDSOExt.CLM_MobileDSOSp(SiteRef);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_AccountsSp([Optional] string FilterString,
            DateTime? StartDate,
            DateTime? EndDate,
            [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IBuildXMLFilterStringFactory buildXMLFilterStringFactory = new BuildXMLFilterStringFactory();
                IExecuteDynamicSQLFactory executeDynamicSQLFactory = new ExecuteDynamicSQLFactory();
                IDoubleQuoteFactory doubleQuoteFactory = new DoubleQuoteFactory();
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IDayEndOfFactory dayEndOfFactory = new DayEndOfFactory();

                var iHome_AccountsExt = new Home_AccountsFactory(buildXMLFilterStringFactory, executeDynamicSQLFactory, doubleQuoteFactory, midnightOfFactory,
                    dayEndOfFactory).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true);

                var result = iHome_AccountsExt.Home_AccountsSp(FilterString,
                    StartDate,
                    EndDate,
                    SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_APPostedTrxSp([Optional] string FilterString,
        DateTime? CutoffDate,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_APPostedTrxExt = new Home_APPostedTrxFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_APPostedTrxExt.Home_APPostedTrxSp(FilterString,
                CutoffDate,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_ARPostedTrxSp([Optional] string FilterString,
        DateTime? CutoffDate,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_ARPostedTrxExt = new Home_ARPostedTrxFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_ARPostedTrxExt.Home_ARPostedTrxSp(FilterString,
                CutoffDate,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_CashImpactSp([Optional] string FilterString,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_CashImpactExt = new Home_CashImpactFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_CashImpactExt.Home_CashImpactSp(FilterString,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_CustomerAnalysisSp([Optional] string FilterString,
            [Optional] string SiteGroup,
            [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_CustomerAnalysisExt = new Home_CustomerAnalysisFactory(new UndefineProcessVariableFactory(),
                    new DefineProcessVariableFactory(),
                    new BuildXMLFilterStringFactory(),
                    new DefaultToLocalSiteFactory(),
                    new GetProcessVariableFactory(),
                    new ExecuteDynamicSQLFactory(),
                    new ARAgingBucketsFactory(),
                    new GetStringValueFactory()).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true);

                var result = iHome_CustomerAnalysisExt.Home_CustomerAnalysisSp(FilterString,
                    SiteGroup,
                    Infobar);

                Infobar = result.Infobar;

                if (result.Data is null)
                    return new DataTable();
                else
                {
                    IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                    return recordCollectionToDataTable.ToDataTable(result.Data.Items);
                }
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_JobVarianceJobSp([Optional] string FilterString,
        string Acct,
        DateTime? PeriodStartDate,
        DateTime? PeriodEndDate,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_JobVarianceJobExt = new Home_JobVarianceJobFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_JobVarianceJobExt.Home_JobVarianceJobSp(FilterString,
                Acct,
                PeriodStartDate,
                PeriodEndDate,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_JobVarianceMatlSp([Optional] string FilterString,
        string JobJob,
        int? JobSuffix,
        string Item,
        decimal? JobQtyReleased,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_JobVarianceMatlExt = new Home_JobVarianceMatlFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_JobVarianceMatlExt.Home_JobVarianceMatlSp(FilterString,
                JobJob,
                JobSuffix,
                Item,
                JobQtyReleased,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_JobVarianceOperSp([Optional] string FilterString,
        string JobJob,
        int? JobSuffix,
        string Item,
        decimal? JobQtyReleased,
        string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_JobVarianceOperExt = new Home_JobVarianceOperFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_JobVarianceOperExt.Home_JobVarianceOperSp(FilterString,
                JobJob,
                JobSuffix,
                Item,
                JobQtyReleased,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricItemShortageSp([Optional, DefaultParameterValue(5)] int? Count)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_MetricItemShortageExt = new Home_MetricItemShortageFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_MetricItemShortageExt.Home_MetricItemShortageSp(Count);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricItemValueSp([Optional, DefaultParameterValue(5)] int? Count)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_MetricItemValueExt = new Home_MetricItemValueFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_MetricItemValueExt.Home_MetricItemValueSp(Count);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricOnTimeJobSp([Optional, DefaultParameterValue(4)] int? Count)
		{
			var iHome_MetricOnTimeJobExt = new Home_MetricOnTimeJobFactory().Create(this, true);
			
			var result = iHome_MetricOnTimeJobExt.Home_MetricOnTimeJobSp(Count);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricOnTimePaymentSp([Optional, DefaultParameterValue(4)] int? Count)
        {
            var iHome_MetricOnTimePaymentExt = new Home_MetricOnTimePaymentFactory().Create(this, true);

            var result = iHome_MetricOnTimePaymentExt.Home_MetricOnTimePaymentSp(Count);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_MetricVendorCommittedSp([Optional, DefaultParameterValue(10)] int? Count)
        {
            var iHome_MetricVendorCommittedExt = new Home_MetricVendorCommittedFactory().Create(this, true);

            var result = iHome_MetricVendorCommittedExt.Home_MetricVendorCommittedSp(Count);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_POFundsCommittedSp([Optional] string FilterString,
        string POStatus,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_POFundsCommittedExt = new Home_POFundsCommittedFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_POFundsCommittedExt.Home_POFundsCommittedSp(FilterString,
                POStatus,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_POVarianceSp([Optional] string FilterString,
        string Item,
        [Optional] string SiteGroup,
        [Optional] string Site)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_POVarianceExt = new Home_POVarianceFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_POVarianceExt.Home_POVarianceSp(FilterString,
                Item,
                SiteGroup,
                Site);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_PurchaseCostVarianceAnalysisSp([Optional] string FilterString,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_PurchaseCostVarianceAnalysisExt = new Home_PurchaseCostVarianceAnalysisFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_PurchaseCostVarianceAnalysisExt.Home_PurchaseCostVarianceAnalysisSp(FilterString,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_TrialBalanceSp([Optional] string FilterString, DateTime? AsOfDate, [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IBuildXMLFilterStringFactory buildXMLFilterStringFactory = new BuildXMLFilterStringFactory();
                IExecuteDynamicSQLFactory executeDynamicSQLFactory = new ExecuteDynamicSQLFactory();
                IPeriodsGetDatesFactory periodsGetDatesFactory = new PeriodsGetDatesFactory();
                ICalcBalFactory calcBalFactory = new CalcBalFactory();
                IPerGetFactory perGetFactory = new PerGetFactory();
                var iHome_TrialBalanceExt = new Home_TrialBalanceFactory(
                    buildXMLFilterStringFactory,
                    executeDynamicSQLFactory,
                    periodsGetDatesFactory,
                    calcBalFactory,
                    perGetFactory
                    ).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true);

                var result = iHome_TrialBalanceExt.Home_TrialBalanceSp(FilterString, AsOfDate, SiteGroup);

                if (result.Data is null)
                    return new DataTable();
                else
                {
                    IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                    return recordCollectionToDataTable.ToDataTable(result.Data.Items);
                }
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_VchPaySp([Optional] string FilterString,
		    DateTime? CutoffDate,
		    [Optional] string SiteGroup)
		{
            var iHome_VchPayExt = this.GetService<IHome_VchPay>();

            var result = iHome_VchPayExt.Home_VchPaySp(FilterString,
			    CutoffDate,
			    SiteGroup);
			
			if (result.Data is null)
			    return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Home_VendorAnalysisSp([Optional] string FilterString,
        [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHome_VendorAnalysisExt = new Home_VendorAnalysisFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHome_VendorAnalysisExt.Home_VendorAnalysisSp(FilterString,
                SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}