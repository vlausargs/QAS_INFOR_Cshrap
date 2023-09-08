//PROJECT NAME: CustomerExt
//CLASS NAME: SLHomepages.cs

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
using CSI.Material;
using CSI.Finance;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLHomepages")]
    public class SLHomepages : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_AccountBalanceBPSp(string Acct,
                                                     string SiteRef)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_AccountBalanceBPExt = new Homepage_AccountBalanceBPFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_AccountBalanceBPExt.Homepage_AccountBalanceBPSp(Acct,
                                                                                         SiteRef);

                return dt;
            }
        }






        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_CheckCustCreditHoldSp(string CustNum, ref int? CreditHold)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_CheckCustCreditHoldExt = new Homepage_CheckCustCreditHoldFactory().Create(appDb,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_CheckCustCreditHoldExt.Homepage_CheckCustCreditHoldSp(CustNum, CreditHold);

                CreditHold = result.CreditHold;

                return result.ReturnCode.Value;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_CustomerOrderFollowUpSp()
        {
            var iHomepage_CustomerOrderFollowUpExt = new Homepage_CustomerOrderFollowUpFactory().Create(this, true);

            var result = iHomepage_CustomerOrderFollowUpExt.Homepage_CustomerOrderFollowUpSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_GetItemVendPriceBrkInfoSp(string VendNum,
                                                      string Item,
                                                      string VendItem,
                                                      ref decimal? BrkQty1,
                                                      ref decimal? BrkQty2,
                                                      ref decimal? BrkQty3,
                                                      ref decimal? BrkQty4,
                                                      ref decimal? BrkQty5,
                                                      ref decimal? BrkCost1,
                                                      ref decimal? BrkCost2,
                                                      ref decimal? BrkCost3,
                                                      ref decimal? BrkCost4,
                                                      ref decimal? BrkCost5,
                                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHomepage_GetItemVendPriceBrkInfoExt = new Homepage_GetItemVendPriceBrkInfoFactory().Create(appDb);

                int Severity = iHomepage_GetItemVendPriceBrkInfoExt.Homepage_GetItemVendPriceBrkInfoSp(VendNum,
                                                                                                       Item,
                                                                                                       VendItem,
                                                                                                       ref BrkQty1,
                                                                                                       ref BrkQty2,
                                                                                                       ref BrkQty3,
                                                                                                       ref BrkQty4,
                                                                                                       ref BrkQty5,
                                                                                                       ref BrkCost1,
                                                                                                       ref BrkCost2,
                                                                                                       ref BrkCost3,
                                                                                                       ref BrkCost4,
                                                                                                       ref BrkCost5,
                                                                                                       ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionDue,
                                                            ref decimal? CommissionPaid,
                                                            ref decimal? BookingAmount,
                                                            ref decimal? PipelineAmount,
                                                            ref decimal? EstimateAmount,
                                                            ref DateTime? PeriodStart,
                                                            ref DateTime? PeriodEnd,
                                                            ref string Slsman)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHomepage_GetTodaysKeySalespersonValuesExt = new Homepage_GetTodaysKeySalespersonValuesFactory().Create(appDb);

                int Severity = iHomepage_GetTodaysKeySalespersonValuesExt.Homepage_GetTodaysKeySalespersonValuesSp(ref CommissionDue,
                                                                                                                   ref CommissionPaid,
                                                                                                                   ref BookingAmount,
                                                                                                                   ref PipelineAmount,
                                                                                                                   ref EstimateAmount,
                                                                                                                   ref PeriodStart,
                                                                                                                   ref PeriodEnd,
                                                                                                                   ref Slsman);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_InventoryFollowUpSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_InventoryFollowUpExt = new Homepage_InventoryFollowUpFactory(new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_InventoryFollowUpExt.Homepage_InventoryFollowUpSp();

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
        public DataTable Homepage_MyInteractionsSp(string UserName,
                                                   string InteractionType,
                                                   string Filter,
                                                   string ParmsLanguageId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_MyInteractionsExt = new Homepage_MyInteractionsFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_MyInteractionsExt.Homepage_MyInteractionsSp(UserName,
                                                                                     InteractionType,
                                                                                     Filter,
                                                                                     ParmsLanguageId);

                return dt;
            }
        }





        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MySalespersonInteractionsSp(string UserName,
                                                              string Filter,
                                                              string ParmsLanguageId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_MySalespersonInteractionsExt = new Homepage_MySalespersonInteractionsFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_MySalespersonInteractionsExt.Homepage_MySalespersonInteractionsSp(UserName,
                                                                                                           Filter,
                                                                                                           ParmsLanguageId);

                return dt;
            }
        }







        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_PastDueDatePOCountSp(ref int? PastDueDatePOCount,
                                                 ref int? NotPastDueDatePOCount,
                                                 ref decimal? PastDueDatePOAmount,
                                                 ref decimal? NotPastDueDatePOAmount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_PastDueDatePOCountExt = new Homepage_PastDueDatePOCountFactory().Create(appDb,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PastDueDatePOCountExt.Homepage_PastDueDatePOCountSp(PastDueDatePOCount,
                    NotPastDueDatePOCount,
                    PastDueDatePOAmount,
                    NotPastDueDatePOAmount);

                PastDueDatePOCount = result.PastDueDatePOCount;
                NotPastDueDatePOCount = result.NotPastDueDatePOCount;
                PastDueDatePOAmount = result.PastDueDatePOAmount;
                NotPastDueDatePOAmount = result.NotPastDueDatePOAmount;

                return result.ReturnCode.Value;
            }
        }










        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ProductionFollowUpSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_ProductionFollowUpExt = new Homepage_ProductionFollowUpFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_ProductionFollowUpExt.Homepage_ProductionFollowUpSp();

                return dt;
            }
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ProjectTaskFollowUpSp(string ProjMgr)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_ProjectTaskFollowUpExt = new Homepage_ProjectTaskFollowUpFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_ProjectTaskFollowUpExt.Homepage_ProjectTaskFollowUpSp(ProjMgr);

                return dt;
            }
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_PurchaseOrderFollowUpSp(string Buyer)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_PurchaseOrderFollowUpExt = new Homepage_PurchaseOrderFollowUpFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_PurchaseOrderFollowUpExt.Homepage_PurchaseOrderFollowUpSp(Buyer);

                return dt;
            }
        }




        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ResourceGroupOEESp(short? Altno,
                                                     DateTime? StartDate,
                                                     DateTime? EndDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_ResourceGroupOEEExt = new Homepage_ResourceGroupOEEFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_ResourceGroupOEEExt.Homepage_ResourceGroupOEESp(Altno,
                                                                                         StartDate,
                                                                                         EndDate);

                return dt;
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_SalespersonFollowUpSp(string Salesperson,
                                                        string Username)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_SalespersonFollowUpExt = new Homepage_SalespersonFollowUpFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iHomepage_SalespersonFollowUpExt.Homepage_SalespersonFollowUpSp(Salesperson,
                                                                                               Username);

                return dt;
            }
        }





        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ToBeShippedValueSp()
        {
            var iHomepage_ToBeShippedValueExt = new Homepage_ToBeShippedValueFactory().Create(this, true);

            var result = iHomepage_ToBeShippedValueExt.Homepage_ToBeShippedValueSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_AverageOrderAmountSp([Optional, DefaultParameterValue("T")] string Range, [Optional] string CustNum)
        {
            var iHomepage_AverageOrderAmountExt = new Homepage_AverageOrderAmountFactory().Create(this, true);

            var result = iHomepage_AverageOrderAmountExt.Homepage_AverageOrderAmountSp(Range, CustNum);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_AverageOrderTurnaroundDaysSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_AverageOrderTurnaroundDaysExt = new Homepage_AverageOrderTurnaroundDaysFactory(midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_AverageOrderTurnaroundDaysExt.Homepage_AverageOrderTurnaroundDaysSp(DaysBefore);

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
        public DataTable Homepage_AvgElapsedTimetoRepairSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_AvgElapsedTimetoRepairExt = new Homepage_AvgElapsedTimetoRepairFactory(midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_AvgElapsedTimetoRepairExt.Homepage_AvgElapsedTimetoRepairSp(DaysBefore);

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
        public DataTable Homepage_BODExceptionSp([Optional, DefaultParameterValue(0)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_BODExceptionExt = new Homepage_BODExceptionFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_BODExceptionExt.Homepage_BODExceptionSp(DaysBefore);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_BookingsByTimeSp([Optional] string Salesperson,
                                                   [Optional, DefaultParameterValue((byte)1)] byte? IncludeDirectReports,
        [Optional, DefaultParameterValue("D")] string DateType,
        [Optional] string CustNum,
        [Optional] ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_BookingsByTimeExt = new Homepage_BookingsByTimeFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_BookingsByTimeExt.Homepage_BookingsByTimeSp(Salesperson,
                                                                                   IncludeDirectReports,
                                                                                   DateType,
                                                                                   CustNum,
                                                                                   Infobar);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                Infobar = result.Infobar;
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_ExecutiveOppWonLostSp(DateTime? Date,
                                                        [Optional, DefaultParameterValue("D")] string DateType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_ExecutiveOppWonLostExt = new Homepage_ExecutiveOppWonLostFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_ExecutiveOppWonLostExt.Homepage_ExecutiveOppWonLostSp(Date,
                                                                                             DateType);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_IncidentsCountSp([Optional, DefaultParameterValue(30)] int? DaysBefore, [Optional] string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_IncidentsCountExt = new Homepage_IncidentsCountFactory(new ExpandKyByTypeFactory(), new InterpretTextFactory(), new MidnightOfFactory(), new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_IncidentsCountExt.Homepage_IncidentsCountSp(DaysBefore, CustNum);

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
        public DataTable Homepage_JobMaterialVarianceSp(DateTime? StartDate, DateTime? EndDate, [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_JobMaterialVarianceExt = new Homepage_JobMaterialVarianceFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_JobMaterialVarianceExt.Homepage_JobMaterialVarianceSp(StartDate,
                    EndDate,
                    SiteGroup);


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
        public DataTable Homepage_LeadsCountSp([Optional, DefaultParameterValue(30)] int? DaysBefore,
                [Optional] string CustNumProspectId,
                [Optional, DefaultParameterValue("Customer")] string Type)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IExpandKyByTypeFactory expandKyByTypeFactory = new ExpandKyByTypeFactory();
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_LeadsCountExt = new Homepage_LeadsCountFactory(expandKyByTypeFactory, midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_LeadsCountExt.Homepage_LeadsCountSp(DaysBefore,
                    CustNumProspectId,
                    Type);


                if (result.Data is null)
                    return new DataTable();
                else
                {
                    IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                    return recordCollectionToDataTable.ToDataTable(result.Data.Items);
                }
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_LotSerialExpSp(DateTime? Date,
                                           [Optional, DefaultParameterValue("D")] string DateType,
        ref int? SerialCount,
        ref decimal? SerialValue,
        ref int? LotCount,
        ref decimal? LotValue)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHomepage_LotSerialExpExt = new Homepage_LotSerialExpFactory().Create(appDb);

                var result = iHomepage_LotSerialExpExt.Homepage_LotSerialExpSp(Date,
                                                                               DateType,
                                                                               SerialCount,
                                                                               SerialValue,
                                                                               LotCount,
                                                                               LotValue);

                int Severity = result.ReturnCode.Value;
                SerialCount = result.SerialCount;
                SerialValue = result.SerialValue;
                LotCount = result.LotCount;
                LotValue = result.LotValue;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MeanTimetoRepairSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_MeanTimetoRepairExt = new Homepage_MeanTimetoRepairFactory(midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_MeanTimetoRepairExt.Homepage_MeanTimetoRepairSp(DaysBefore);

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
        public DataTable Homepage_MRPOrderActionItemsSp([Optional] string Buyer,
                                                        [Optional] string Source,
                                                        [Optional] string Filter)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_MRPOrderActionItemsExt = new Homepage_MRPOrderActionItemsFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_MRPOrderActionItemsExt.Homepage_MRPOrderActionItemsSp(Buyer,
                                                                                             Source,
                                                                                             Filter);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MyCustomerOrdersSp(string TakenBy,
            DateTime? Date,
            [Optional, DefaultParameterValue("D")] string DateType,
            string Salesperson,
            [Optional] string ProjMgr,
            [Optional, DefaultParameterValue((byte)0)] byte? OnlyProj)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_MyCustomerOrdersExt = new Homepage_MyCustomerOrdersFactory(new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_MyCustomerOrdersExt.Homepage_MyCustomerOrdersSp(TakenBy,
                    Date,
                    DateType,
                    Salesperson,
                    ProjMgr,
                    OnlyProj);

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
        public DataTable Homepage_MyCustomerTop5SalesSp([Optional] string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_MyCustomerTop5SalesExt = new Homepage_MyCustomerTop5SalesFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_MyCustomerTop5SalesExt.Homepage_MyCustomerTop5SalesSp(CustNum);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MyJobOrdersSp(DateTime? Date,
                                                [Optional, DefaultParameterValue("D")] string DateType,
        [Optional] string TakenBy,
        [Optional] string Salesperson,
        [Optional, DefaultParameterValue((byte)0)] byte? OnlyCo,
        [Optional] string ProjMgr,
        [Optional, DefaultParameterValue((byte)0)] byte? OnlyProj)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_MyJobOrdersExt = new Homepage_MyJobOrdersFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_MyJobOrdersExt.Homepage_MyJobOrdersSp(Date,
                                                                             DateType,
                                                                             TakenBy,
                                                                             Salesperson,
                                                                             OnlyCo,
                                                                             ProjMgr,
                                                                             OnlyProj);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MyPipelineValueSp([Optional] string Salesperson,
                                                    [Optional, DefaultParameterValue((byte)0)] byte? IncludeDirectReports)
        {
            var iHomepage_MyPipelineValueExt = new Homepage_MyPipelineValueFactory().Create(this, true);

            var result = iHomepage_MyPipelineValueExt.Homepage_MyPipelineValueSp(Salesperson,
            IncludeDirectReports);


            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_MyProjectVariancesSp([Optional] string ProjMgr,
                                                 ref int? InControl,
                                                 ref int? SchedVarY,
                                                 ref int? SchedVarR,
                                                 ref int? CostVarY,
                                                 ref int? CostVarR)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHomepage_MyProjectVariancesExt = new Homepage_MyProjectVariancesFactory().Create(appDb);

                var result = iHomepage_MyProjectVariancesExt.Homepage_MyProjectVariancesSp(ProjMgr,
                                                                                           InControl,
                                                                                           SchedVarY,
                                                                                           SchedVarR,
                                                                                           CostVarY,
                                                                                           CostVarR);

                int Severity = result.ReturnCode.Value;
                InControl = result.InControl;
                SchedVarY = result.SchedVarY;
                SchedVarR = result.SchedVarR;
                CostVarY = result.CostVarY;
                CostVarR = result.CostVarR;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_MyPurchaseOrdersSp([Optional] string Buyer,
                                                     [Optional] DateTime? Date,
                                                     [Optional, DefaultParameterValue("D")] string DateType,
                                                     [Optional] string TakenBy,
                                                     [Optional] string Salesperson,
                                                     [Optional, DefaultParameterValue((byte)0)] byte? OnlyCo,
                                                     [Optional] string ProjMgr,
                                                     [Optional, DefaultParameterValue((byte)0)] byte? OnlyProj)
        {
            var iHomepage_MyPurchaseOrdersExt = new Homepage_MyPurchaseOrdersFactory().Create(this, true);

            var result = iHomepage_MyPurchaseOrdersExt.Homepage_MyPurchaseOrdersSp(Buyer,
                Date,
                DateType,
                TakenBy,
                Salesperson,
                OnlyCo,
                ProjMgr,
                OnlyProj);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_OnTimeDeliverySp([Optional, DefaultParameterValue(0)] int? DaysBefore,
        [Optional, DefaultParameterValue("OL")] string DisplayCategory)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_OnTimeDeliveryExt = new Homepage_OnTimeDeliveryFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_OnTimeDeliveryExt.Homepage_OnTimeDeliverySp(DaysBefore,
                                                                                   DisplayCategory);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_OperationsEfficiencySp([Optional] DateTime? StartTrxDate,
                                                         [Optional] DateTime? EndtrxDate,
                                                         [Optional] string StartJob,
                                                         [Optional] string EndJob,
                                                         [Optional] string SiteGroup)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_OperationsEfficiencyExt = new Homepage_OperationsEfficiencyFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_OperationsEfficiencyExt.Homepage_OperationsEfficiencySp(StartTrxDate,
                                                                                               EndtrxDate,
                                                                                               StartJob,
                                                                                               EndJob,
                                                                                               SiteGroup);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Homepage_OpportunitySp([Optional, DefaultParameterValue(30)] int? DaysBefore,
        [Optional] string CustNumProspectId,
        [Optional, DefaultParameterValue("Customer")] string Type,
        ref int? OppCount,
        ref int? OppAmount)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iHomepage_OpportunityExt = new Homepage_OpportunityFactory().Create(appDb);

                var result = iHomepage_OpportunityExt.Homepage_OpportunitySp(DaysBefore,
                                                                             CustNumProspectId,
                                                                             Type,
                                                                             OppCount,
                                                                             OppAmount);

                int Severity = result.ReturnCode.Value;
                OppCount = result.OppCount;
                OppAmount = result.OppAmount;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_OrdersShippedAmountSp([Optional, DefaultParameterValue("T")] string Range)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_OrdersShippedAmountExt = new Homepage_OrdersShippedAmountFactory(new MidnightOfFactory(), new GetLabelFactory(), new CurrCnvtSingleAmt2Factory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_OrdersShippedAmountExt.Homepage_OrdersShippedAmountSp(Range);

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
        public DataTable Homepage_OutstandingARBalanceSp([Optional, DefaultParameterValue(30)] int? DaysBefore, [Optional] string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_OutstandingARBalanceExt = new Homepage_OutstandingARBalanceFactory(new MidnightOfFactory(), new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_OutstandingARBalanceExt.Homepage_OutstandingARBalanceSp(DaysBefore, CustNum);

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
        public DataTable Homepage_PastDueIncidentCountSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_PastDueIncidentCountExt = new Homepage_PastDueIncidentCountFactory(midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PastDueIncidentCountExt.Homepage_PastDueIncidentCountSp(DaysBefore);

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
        public DataTable Homepage_PercentofMarginSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_PercentofMarginExt = new Homepage_PercentofMarginFactory(new MidnightOfFactory(), new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PercentofMarginExt.Homepage_PercentofMarginSp(DaysBefore);

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
        public DataTable Homepage_PercentofOrdersFulfilledOnTimeSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_PercentofOrdersFulfilledOnTimeExt = new Homepage_PercentofOrdersFulfilledOnTimeFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_PercentofOrdersFulfilledOnTimeExt.Homepage_PercentofOrdersFulfilledOnTimeSp(DaysBefore);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_POCountbyMonthSp([Optional, DefaultParameterValue(6)] int? MonthCount,
        [Optional] string VendNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_POCountbyMonthExt = new Homepage_POCountbyMonthFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_POCountbyMonthExt.Homepage_POCountbyMonthSp(MonthCount,
                                                                                   VendNum);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_POLinesReceivedCountSp([Optional, DefaultParameterValue(0)] int? DaysBefore, [Optional] string VendNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IExpandKyByTypeFactory expandKyByTypeFactory = new ExpandKyByTypeFactory();
                IInterpretTextFactory interpretTextFactory = new InterpretTextFactory();
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_POLinesReceivedCountExt = new Homepage_POLinesReceivedCountFactory(
                    expandKyByTypeFactory,
                    interpretTextFactory,
                    midnightOfFactory,
                    getLabelFactory).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true);

                var result = iHomepage_POLinesReceivedCountExt.Homepage_POLinesReceivedCountSp(DaysBefore, VendNum);

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
        public DataTable Homepage_PORequisitionLineByStatusSp([Optional, DefaultParameterValue(0)] int? DaysBefore, [Optional] string Item)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_PORequisitionLineByStatusExt = new Homepage_PORequisitionLineByStatusFactory(getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PORequisitionLineByStatusExt.Homepage_PORequisitionLineByStatusSp(DaysBefore, Item);

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
        public DataTable Homepage_POReturnsSp([Optional, DefaultParameterValue(6)] int? MonthCount, [Optional] string VendNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IExpandKyByTypeFactory expandKyByTypeFactory = new ExpandKyByTypeFactory();
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_POReturnsExt = new Homepage_POReturnsFactory(expandKyByTypeFactory, midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_POReturnsExt.Homepage_POReturnsSp(MonthCount, VendNum);

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
        public DataTable Homepage_ProjectShippingSp([Optional] string ProjMgr,
                                                    [Optional] DateTime? Date,
                                                    [Optional, DefaultParameterValue("D")] string DateType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_ProjectShippingExt = new Homepage_ProjectShippingFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_ProjectShippingExt.Homepage_ProjectShippingSp(ProjMgr,
                                                                                     Date,
                                                                                     DateType);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_QCRejectionPercentageByItemSp(DateTime? DateEnd,
            DateTime? DateStart,
            string RefType)
        {
            var iHomepage_QCRejectionPercentageByItemExt = new Homepage_QCRejectionPercentageByItemFactory().Create(this, true);

            var result = iHomepage_QCRejectionPercentageByItemExt.Homepage_QCRejectionPercentageByItemSp(DateEnd,
                DateStart,
                RefType);


            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_QCScrappedStockByItemSp([Optional, DefaultParameterValue(10)] int? Count)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_QCScrappedStockByItemExt = new Homepage_QCScrappedStockByItemFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_QCScrappedStockByItemExt.Homepage_QCScrappedStockByItemSp(Count);

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
        public DataTable Homepage_RequisitionCountbyStatusSp([Optional, DefaultParameterValue(0)] int? DaysBefore, [Optional] string Item)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_RequisitionCountbyStatusExt = new Homepage_RequisitionCountbyStatusFactory(new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_RequisitionCountbyStatusExt.Homepage_RequisitionCountbyStatusSp(DaysBefore, Item);

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
        public DataTable Homepage_RMAAmountSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            var iHomepage_RMAAmountExt = new Homepage_RMAAmountFactory().Create(this, true);

            var result = iHomepage_RMAAmountExt.Homepage_RMAAmountSp(DaysBefore);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_SalespersonOppsClosedSp([Optional] string Salesperson,
                                                          [Optional, DefaultParameterValue((byte)1)] byte? IncludeDirectReports,
        [Optional, DefaultParameterValue("D")] string DateType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_SalespersonOppsClosedExt = new Homepage_SalespersonOppsClosedFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_SalespersonOppsClosedExt.Homepage_SalespersonOppsClosedSp(Salesperson,
                                                                                                 IncludeDirectReports,
                                                                                                 DateType);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_SROAwaitingSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_SROAwaitingExt = new Homepage_SROAwaitingFactory(new MidnightOfFactory(), new GetLabelFactory()).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_SROAwaitingExt.Homepage_SROAwaitingSp(DaysBefore);

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
        public DataTable Homepage_SROEstSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory midnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_SROEstExt = new Homepage_SROEstFactory(midnightOfFactory, getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_SROEstExt.Homepage_SROEstSp(DaysBefore);

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
        public DataTable Homepage_SROsAmountandTimeSp([Optional, DefaultParameterValue(6)] int? MonthCount,
            [Optional, DefaultParameterValue("A")] string DisplayCategory)
        {
            var iHomepage_SROsAmountandTimeExt = new Homepage_SROsAmountandTimeFactory().Create(this, true);

            var result = iHomepage_SROsAmountandTimeExt.Homepage_SROsAmountandTimeSp(MonthCount,
                DisplayCategory);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_TotalSalesSp([Optional] string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IGetLabelFactory getLabelFactory = new GetLabelFactory();
                var iHomepage_TotalSalesExt = new Homepage_TotalSalesFactory(getLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_TotalSalesExt.Homepage_TotalSalesSp(CustNum);

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
        public DataTable Homepage_UpcomingProductionSp([Optional, DefaultParameterValue(10)] int? NumberOfRows,
        [Optional, DefaultParameterValue("E")] string Type)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_UpcomingProductionExt = new Homepage_UpcomingProductionFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_UpcomingProductionExt.Homepage_UpcomingProductionSp(NumberOfRows,
                                                                                           Type);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_UpcomingReceiptsSp([Optional, DefaultParameterValue(5)] int? NumberOfRows)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_UpcomingReceiptsExt = new Homepage_UpcomingReceiptsFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_UpcomingReceiptsExt.Homepage_UpcomingReceiptsSp(NumberOfRows);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_UpcomingShipmentsSp([Optional, DefaultParameterValue(10)] int? NumberOfRows)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iHomepage_UpcomingShipmentsExt = new Homepage_UpcomingShipmentsFactory().Create(appDb, bunchedLoadCollection);

                var result = iHomepage_UpcomingShipmentsExt.Homepage_UpcomingShipmentsSp(NumberOfRows);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }



        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_CustomerProductCodeBacklogSp([Optional] string CustNum,
                                                               [Optional] string ProductCode,
                                                               [Optional] string SiteRef,
                                                               [Optional] string FilterString)
        {
            var iHomepage_CustomerProductCodeBacklogExt = new Homepage_CustomerProductCodeBacklogFactory().Create(this, true);

            var result = iHomepage_CustomerProductCodeBacklogExt.Homepage_CustomerProductCodeBacklogSp(CustNum,
                ProductCode,
                SiteRef,
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
        public DataTable Homepage_CODocLifecycleDocumentSp(string DocType,
        string DocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_CODocLifecycleDocumentExt = new Homepage_CODocLifecycleDocumentFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHomepage_CODocLifecycleDocumentExt.Homepage_CODocLifecycleDocumentSp(DocType,
                DocId);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_DaysOutstandingSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_DaysOutstandingExt = new Homepage_DaysOutstandingFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHomepage_DaysOutstandingExt.Homepage_DaysOutstandingSp();

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_PODocLifecycleDocumentSp(string DocType,
        string DocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_PODocLifecycleDocumentExt = new Homepage_PODocLifecycleDocumentFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iHomepage_PODocLifecycleDocumentExt.Homepage_PODocLifecycleDocumentSp(DocType,
                DocId);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_TimePhasedItemQtySp(string Item, string Whse)
        {
            var iHomepage_TimePhasedItemQtyExt = new Homepage_TimePhasedItemQtyFactory().Create(this, true);

            var result = iHomepage_TimePhasedItemQtyExt.Homepage_TimePhasedItemQtySp(Item, Whse);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Homepage_LateSROCountSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory MidnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory GetLabelFactory = new GetLabelFactory();
                var iHomepage_LateSROCountExt = new Homepage_LateSROCountFactory(MidnightOfFactory, GetLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_LateSROCountExt.Homepage_LateSROCountSp(DaysBefore);


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
        public DataTable Homepage_VoucheredPOLinesCountSp([Optional, DefaultParameterValue(0)] int? DaysBefore, [Optional] string VendNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                IExpandKyByTypeFactory ExpandKyByTypeFactory = new ExpandKyByTypeFactory();
                IMidnightOfFactory MidnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory GetLabelFactory = new GetLabelFactory();
                var iHomepage_VoucheredPOLinesCountExt = new Homepage_VoucheredPOLinesCountFactory(ExpandKyByTypeFactory,
                   MidnightOfFactory, GetLabelFactory).Create(appDb,
                        bunchedLoadCollection,
                        mgInvoker,
                        new CSI.Data.SQL.SQLParameterProvider(),
                        true);

                var result = iHomepage_VoucheredPOLinesCountExt.Homepage_VoucheredPOLinesCountSp(DaysBefore, VendNum);

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
        public DataTable Homepage_LaborUtilizationSp([Optional, DefaultParameterValue(30)] int? DaysBefore)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory MidnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory GetLabelFactory = new GetLabelFactory();
                var iHomepage_LaborUtilizationExt = new Homepage_LaborUtilizationFactory(MidnightOfFactory, GetLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_LaborUtilizationExt.Homepage_LaborUtilizationSp(DaysBefore);


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
        public DataTable Homepage_PastDueDatePOSp([Optional, DefaultParameterValue(0)] int? IsPastDueDatePO)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_PastDueDatePOExt = new Homepage_PastDueDatePOFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PastDueDatePOExt.Homepage_PastDueDatePOSp(IsPastDueDatePO);

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
        public DataTable Homepage_POCountSp([Optional, DefaultParameterValue(0)] int? DaysBefore, [Optional] string PoStat)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory MidnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory GetLabelFactory = new GetLabelFactory();
                var iHomepage_POCountExt = new Homepage_POCountFactory(MidnightOfFactory, GetLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_POCountExt.Homepage_POCountSp(DaysBefore, PoStat);

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
        public DataTable Homepage_PurchaseOrderByVendorSp([Optional, DefaultParameterValue(5)] int? Count)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_PurchaseOrderByVendorExt = new Homepage_PurchaseOrderByVendorFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_PurchaseOrderByVendorExt.Homepage_PurchaseOrderByVendorSp(Count);

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
        public DataTable Homepage_SalesForecastSp([Optional] string Salesperson,
            [Optional, DefaultParameterValue(1)] int? IncludeDirectReports,
            [Optional] string SalesPeriod)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iHomepage_SalesForecastExt = new Homepage_SalesForecastFactory().Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_SalesForecastExt.Homepage_SalesForecastSp(Salesperson,
                    IncludeDirectReports,
                    SalesPeriod);

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
        public DataTable Homepage_OpenPOCountSp([Optional, DefaultParameterValue(0)] int? DaysBefore,
            [Optional, DefaultParameterValue(0)] int? CountAtLineLevel)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);
                IMidnightOfFactory MidnightOfFactory = new MidnightOfFactory();
                IGetLabelFactory GetLabelFactory = new GetLabelFactory();
                var iHomepage_OpenPOCountExt = new Homepage_OpenPOCountFactory(MidnightOfFactory, GetLabelFactory).Create(appDb,
                    bunchedLoadCollection,
                    mgInvoker,
                    new CSI.Data.SQL.SQLParameterProvider(),
                    true);

                var result = iHomepage_OpenPOCountExt.Homepage_OpenPOCountSp(DaysBefore,
                    CountAtLineLevel);


                if (result.Data is null)
                    return new DataTable();
                else
                {
                    IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                    return recordCollectionToDataTable.ToDataTable(result.Data.Items);
                }
            }
        }
    }
}
