//PROJECT NAME: FinanceExt
//CLASS NAME: SLExecutives.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLExecutives")]
    public class SLExecutives : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MobileMaxMenuItemsSp(string MobileHomepage,
                                        ref int? MaxMenuItems)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMobileHomepagesExt = new MobileMaxMenuItemsFactory().Create(appDb);

                IntType oMaxMenuItems = MaxMenuItems;

                int Severity = iMobileHomepagesExt.MobileMaxMenuItemsSp(MobileHomepage,
                                                                        ref oMaxMenuItems);

                MaxMenuItems = oMaxMenuItems;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int IsExecutiveHomeSiteGroupValidSp(ref string SiteGroup,
                                                   ref string SiteList,
                                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLExecutivesExt = new IsExecutiveHomeSiteGroupValidFactory().Create(appDb);

                SiteGroupType oSiteGroup = SiteGroup;
                InfobarType oSiteList = SiteList;
                InfobarType oInfobar = Infobar;

                int Severity = iSLExecutivesExt.IsExecutiveHomeSiteGroupValidSp(ref oSiteGroup,
                                                                                ref oSiteList,
                                                                                ref oInfobar);

                SiteGroup = oSiteGroup;
                SiteList = oSiteList;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Home_GetTodaysKeyExecutiveValuesSp(string SiteGroup,
                                                      ref decimal? BookingAmount,
                                                      ref decimal? ReceiptAmount,
                                                      ref decimal? POFundAmount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLExecutivesExt = new Home_GetTodaysKeyExecutiveValuesFactory().Create(appDb);

                AmountType oBookingAmount = BookingAmount;
                AmountType oReceiptAmount = ReceiptAmount;
                AmountType oPOFundAmount = POFundAmount;

                int Severity = iSLExecutivesExt.Home_GetTodaysKeyExecutiveValuesSp(SiteGroup,
                                                                                   ref oBookingAmount,
                                                                                   ref oReceiptAmount,
                                                                                   ref oPOFundAmount);

                BookingAmount = oBookingAmount;
                ReceiptAmount = oReceiptAmount;
                POFundAmount = oPOFundAmount;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_MobileHomepagePicturesSp(int? Position,
                                                       string MobileHomepage)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSLExecutivesExt = new CLM_MobileHomepagePicturesFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSLExecutivesExt.CLM_MobileHomepagePicturesSp(Position,
                                                                             MobileHomepage);

                return dt;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveOrderBookingsSp(string View,
		                                              byte? Detail,
		                                              string SiteGroup,
		                                              DateTime? DateStarting,
		                                              DateTime? DateEnding,
		                                              [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ExecutiveOrderBookingsExt = new CLM_ExecutiveOrderBookingsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ExecutiveOrderBookingsExt.CLM_ExecutiveOrderBookingsSp(View,
				                                                                         Detail,
				                                                                         SiteGroup,
				                                                                         DateStarting,
				                                                                         DateEnding,
				                                                                         FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutivePipelineSp(string ViewBy,
		                                         int? Detail,
		                                         DateTime? DateStarting,
		                                         DateTime? DateEnding,
		                                         [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ExecutivePipelineExt = new CLM_ExecutivePipelineFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ExecutivePipelineExt.CLM_ExecutivePipelineSp(ViewBy,
				                                                               Detail,
				                                                               DateStarting,
				                                                               DateEnding,
				                                                               FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveShipmentRevenueSp(string View,
			string SiteGroup,
			DateTime? DateStarting,
			DateTime? DateEnding,
			[Optional] string FilterString)
		{
			var iCLM_ExecutiveShipmentRevenueExt = this.GetService<ICLM_ExecutiveShipmentRevenue>();

			var result = iCLM_ExecutiveShipmentRevenueExt.CLM_ExecutiveShipmentRevenueSp(View,
				SiteGroup,
				DateStarting,
				DateEnding,
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
		public DataTable Home_MetricPaymentComparisonSp([Optional] string SiteGroup)
		{
			var iHome_MetricPaymentComparisonExt = new Home_MetricPaymentComparisonFactory().Create(this, true);
			
			var result = iHome_MetricPaymentComparisonExt.Home_MetricPaymentComparisonSp(SiteGroup);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveCashReceivedSp([Optional] string SiteGroup,
		[Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveCashReceivedExt = new CLM_ExecutiveCashReceivedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveCashReceivedExt.CLM_ExecutiveCashReceivedSp(SiteGroup,
				DateStarting,
				DateEnding,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveCustomerAnalysisSp([Optional] string FilterString,
		[Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveCustomerAnalysisExt = new CLM_ExecutiveCustomerAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveCustomerAnalysisExt.CLM_ExecutiveCustomerAnalysisSp(FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveLateOrdersSp(string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveLateOrdersExt = new CLM_ExecutiveLateOrdersFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveLateOrdersExt.CLM_ExecutiveLateOrdersSp(SiteGroup,
				DateStarting,
				DateEnding,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveOppWonLostSp(DateTime? DateStarting,
		DateTime? DateEnding,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveOppWonLostExt = new CLM_ExecutiveOppWonLostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveOppWonLostExt.CLM_ExecutiveOppWonLostSp(DateStarting,
				DateEnding,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutivePOFundsCommittedSp([Optional] string FilterString,
		string POStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutivePOFundsCommittedExt = new CLM_ExecutivePOFundsCommittedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutivePOFundsCommittedExt.CLM_ExecutivePOFundsCommittedSp(FilterString,
				POStatus);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutivePOValueSp(string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutivePOValueExt = new CLM_ExecutivePOValueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutivePOValueExt.CLM_ExecutivePOValueSp(SiteGroup,
				DateStarting,
				DateEnding,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveVendorAnalysisSp([Optional] string FilterString,
		[Optional] string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveVendorAnalysisExt = new CLM_ExecutiveVendorAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveVendorAnalysisExt.CLM_ExecutiveVendorAnalysisSp(FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExecutiveWCEarnedAmountsSp(DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExecutiveWCEarnedAmountsExt = new CLM_ExecutiveWCEarnedAmountsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExecutiveWCEarnedAmountsExt.CLM_ExecutiveWCEarnedAmountsSp(DateStarting,
				DateEnding,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
