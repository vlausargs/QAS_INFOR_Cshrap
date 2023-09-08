//PROJECT NAME: AdminExt
//CLASS NAME: MobileHomepages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using CSI.Data.RecordSets;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("MobileHomepages")]
    public class MobileHomepages : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MobileSPMenuItemsSp(ref int? MaxMenuItems)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMobileSPMenuItemsExt = new MobileSPMenuItemsFactory().Create(appDb);

                IntType oMaxMenuItems = MaxMenuItems;

                int Severity = iMobileSPMenuItemsExt.MobileSPMenuItemsSp(ref oMaxMenuItems);

                MaxMenuItems = oMaxMenuItems;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MobileControllerMenuItemsSp(ref int? MaxMenuItems)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMobileControllerMenuItemsExt = new MobileControllerMenuItemsFactory().Create(appDb);

                IntType oMaxMenuItems = MaxMenuItems;

                int Severity = iMobileControllerMenuItemsExt.MobileControllerMenuItemsSp(ref oMaxMenuItems);

                MaxMenuItems = oMaxMenuItems;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable JobCalendarSp(DateTime? StartDate,
                                       DateTime? EndDate,
                                       string JobAction)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iJobCalendarExt = new JobCalendarFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iJobCalendarExt.JobCalendarSp(StartDate,
                                                             EndDate,
                                                             JobAction);

                return dt;
            }
        }
        
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetMobileImageSp(int? Position,
                                                      string HomePage)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_GetMobileImageExt = new CLM_GetMobileImageFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_GetMobileImageExt.CLM_GetMobileImageSp(Position,
                                                                           HomePage);

                return dt;
            }
        }
        








		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CoItemsBookingsbyProductCodeSp([Optional] string ProductCode,
            [Optional] int? StartYear,
            [Optional] int? EndYear,
            [Optional] int? StartPeriod,
            [Optional] int? EndPeriod,
            [Optional] int? PageNum,
            [Optional] int? EntriesPerPage,
            [Optional] string SiteRef)
        {
            var iCLM_CoItemsBookingsbyProductCodeExt = new CLM_CoItemsBookingsbyProductCodeFactory().Create(this, true);

            var result = iCLM_CoItemsBookingsbyProductCodeExt.CLM_CoItemsBookingsbyProductCodeSp(ProductCode,
                StartYear,
                EndYear,
                StartPeriod,
                EndPeriod,
                PageNum,
                EntriesPerPage,
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
		public DataTable CLM_CoItemsBookingsbyTerritorySp([Optional] string TerritoryCode,
		                                                  [Optional] int? StartYear,
		                                                  [Optional] int? EndYear,
		                                                  [Optional] int? StartPeriod,
		                                                  [Optional] int? EndPeriod,
		                                                  [Optional] int? PageNum,
		                                                  [Optional] int? EntriesPerPage,
		                                                  [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_CoItemsBookingsbyTerritoryExt = new CLM_CoItemsBookingsbyTerritoryFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_CoItemsBookingsbyTerritoryExt.CLM_CoItemsBookingsbyTerritorySp(TerritoryCode,
				                                                                                 StartYear,
				                                                                                 EndYear,
				                                                                                 StartPeriod,
				                                                                                 EndPeriod,
				                                                                                 PageNum,
				                                                                                 EntriesPerPage,
				                                                                                 SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CustomerGrossSp([Optional] string Cust_Num,
		                                     [Optional] DateTime? StartDate,
		                                     [Optional] DateTime? EndDate,
		                                     [Optional, DefaultParameterValue((byte)0)] byte? Detail,
		[Optional] string SiteRef,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_CustomerGrossExt = new CLM_CustomerGrossFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_CustomerGrossExt.CLM_CustomerGrossSp(Cust_Num,
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
		public DataTable CLM_ProductCodeMarginSp([Optional] string ProductCode,
			[Optional] int? StartYear,
			[Optional] int? EndYear,
			[Optional] int? StartPeriod,
			[Optional] int? EndPeriod,
			[Optional] int? PageNum,
			[Optional] int? EntriesPerPage,
			[Optional] string SiteRef)
		{
			var iCLM_ProductCodeMarginExt = new CLM_ProductCodeMarginFactory().Create(this, true);

			var result = iCLM_ProductCodeMarginExt.CLM_ProductCodeMarginSp(ProductCode,
				StartYear,
				EndYear,
				StartPeriod,
				EndPeriod,
				PageNum,
				EntriesPerPage,
				SiteRef);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}


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









		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CustomerInteractionCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		[Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustomerInteractionCalendarExt = new CustomerInteractionCalendarFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustomerInteractionCalendarExt.CustomerInteractionCalendarSp(StartDate,
				EndDate,
				Action,
				SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CustomerInteractionFollowUpSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		[Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCustomerInteractionFollowUpExt = new CustomerInteractionFollowUpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCustomerInteractionFollowUpExt.CustomerInteractionFollowUpSp(StartDate,
				EndDate,
				Action,
				SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DCJobLaborStatusSp([Optional] string Job,
		[Optional] int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDCJobLaborStatusExt = new DCJobLaborStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDCJobLaborStatusExt.DCJobLaborStatusSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DCJobLaborStatusSumSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDCJobLaborStatusSumExt = new DCJobLaborStatusSumFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDCJobLaborStatusSumExt.DCJobLaborStatusSumSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetOpportunityTaskCountSp(string OppID,
		string Slsman,
		DateTime? StartDate,
		DateTime? EndDate,
		ref int? TaskCount,
		ref int? DueCount,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetOpportunityTaskCountExt = new GetOpportunityTaskCountFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetOpportunityTaskCountExt.GetOpportunityTaskCountSp(OppID,
				Slsman,
				StartDate,
				EndDate,
				TaskCount,
				DueCount,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TaskCount = result.TaskCount;
				DueCount = result.DueCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable OpportunityTaskCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string Action,
		string Slsman)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iOpportunityTaskCalendarExt = new OpportunityTaskCalendarFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iOpportunityTaskCalendarExt.OpportunityTaskCalendarSp(StartDate,
				EndDate,
				Action,
				Slsman);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProspectInteractionCalendarSp(DateTime? StartDate,
		DateTime? EndDate,
		string ProspectID,
		string Slsman,
		string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProspectInteractionCalendarExt = new ProspectInteractionCalendarFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProspectInteractionCalendarExt.ProspectInteractionCalendarSp(StartDate,
				EndDate,
				ProspectID,
				Slsman,
				SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProspectInteractionFollowUpSp(DateTime? StartDate,
		DateTime? EndDate,
		string ProspectID,
		string Slsman,
		string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProspectInteractionFollowUpExt = new ProspectInteractionFollowUpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProspectInteractionFollowUpExt.ProspectInteractionFollowUpSp(StartDate,
				EndDate,
				ProspectID,
				Slsman,
				SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
