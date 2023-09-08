//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReceiveShipLineViews.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System.Runtime.InteropServices;
using CSI.BusInterface;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;
using CSI.BusInterface.ESBExtWhse;
using CSI.Data.SQL;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBReceiveShipLineViews")]
    public class ESBReceiveShipLineViews : CSIExtensionClassBase
    {



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LoadESBReceiveShipLineSP(string BODNOUN,
                                            string BODVERB,
                                            string Item,
                                            decimal? OrderQty,
                                            string ISOUM,
                                            decimal? EstimatedWeight,
                                            string EstimatedWeightISOUM,
                                            string PurchaseOrderRef,
                                            int? PurchaseOrderLine,
                                            int? PurchaseOrderRelease,
                                            decimal? PurchaseOrderQty,
                                            string PurchaseOrderISOUM,
                                            string SalesOrderRef,
                                            int? SalesOrderRelease,
                                            int? SalesOrderLine,
                                            decimal? SalesOrderQty,
                                            string SalesOrderISOUM,
                                            string DocumentIDName,
                                            string RefNum,
                                            short? RefLine,
                                            int? RefProdOrderSequence,
                                            int? RefOperationID,
                                            string RefConsumedItemLineNum,
                                            string RefOutputItemLineNum,
                                            short? RefRelease,
                                            decimal? QtyShipped,
                                            string SerializedLotID,
                                            DateTime? SerializedLotExpDate,
                                            string HoldCode,
                                            decimal? CountSequence,
                                            int? LineNumber,
                                            DateTime? ReceivedDateTime,
                                            string WareHouse,
                                            ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iLoadESBReceiveShipLineExt = new LoadESBReceiveShipLineFactory().Create(appDb);

                int Severity = iLoadESBReceiveShipLineExt.LoadESBReceiveShipLineSP(BODNOUN,
                                                                                   BODVERB,
                                                                                   Item,
                                                                                   OrderQty,
                                                                                   ISOUM,
                                                                                   EstimatedWeight,
                                                                                   EstimatedWeightISOUM,
                                                                                   PurchaseOrderRef,
                                                                                   PurchaseOrderLine,
                                                                                   PurchaseOrderRelease,
                                                                                   PurchaseOrderQty,
                                                                                   PurchaseOrderISOUM,
                                                                                   SalesOrderRef,
                                                                                   SalesOrderRelease,
                                                                                   SalesOrderLine,
                                                                                   SalesOrderQty,
                                                                                   SalesOrderISOUM,
                                                                                   DocumentIDName,
                                                                                   RefNum,
                                                                                   RefLine,
                                                                                   RefProdOrderSequence,
                                                                                   RefOperationID,
                                                                                   RefConsumedItemLineNum,
                                                                                   RefOutputItemLineNum,
                                                                                   RefRelease,
                                                                                   QtyShipped,
                                                                                   SerializedLotID,
                                                                                   SerializedLotExpDate,
                                                                                   HoldCode,
                                                                                   CountSequence,
                                                                                   LineNumber,
                                                                                   ReceivedDateTime,
                                                                                   WareHouse,
                                                                                   ref InfoBar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int LoadESBReceiveShippingLoopSp(string DocumentIDName,
                                                string BODNOUN,
                                                string BODVERB,
                                                string DocumentID,
                                                string LineNumber,
                                                decimal? QtyShipped,
                                                string QtyShippedISOUM,
                                                string Item,
                                                decimal? OrderQty,
                                                string ISOUM,
                                                decimal? EstimatedWeight,
                                                string EstimatedWeightISOUM,
                                                string PurchaseOrderRef,
                                                int? PurchaseOrderLine,
                                                int? PurchaseOrderRelease,
                                                decimal? PurchaseOrderQty,
                                                string PurchaseOrderISOUM,
                                                string SalesOrderRef,
                                                int? SalesOrderRelease,
                                                int? SalesOrderLine,
                                                decimal? SalesOrderQty,
                                                string SalesOrderISOUM,
                                                string RefNum,
                                                short? RefLine,
                                                int? RefProdOrderSequence,
                                                int? RefOperationID,
                                                string RefConsumedItemLineNum,
                                                string RefOutputItemLineNum,
                                                short? RefRelease,
                                                string SerializedLotID,
                                                DateTime? SerializedLotExpDate,
                                                string HoldCode,
                                                decimal? CountSequence,
                                                DateTime? ReceivedDateTime,
                                                string WareHouse,
                                                string Status,
                                                ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iLoadESBReceiveShippingLoopExt = new LoadESBReceiveShippingLoopFactory().Create(appDb);

                int Severity = iLoadESBReceiveShippingLoopExt.LoadESBReceiveShippingLoopSp(DocumentIDName,
                                                                                           BODNOUN,
                                                                                           BODVERB,
                                                                                           DocumentID,
                                                                                           LineNumber,
                                                                                           QtyShipped,
                                                                                           QtyShippedISOUM,
                                                                                           Item,
                                                                                           OrderQty,
                                                                                           ISOUM,
                                                                                           EstimatedWeight,
                                                                                           EstimatedWeightISOUM,
                                                                                           PurchaseOrderRef,
                                                                                           PurchaseOrderLine,
                                                                                           PurchaseOrderRelease,
                                                                                           PurchaseOrderQty,
                                                                                           PurchaseOrderISOUM,
                                                                                           SalesOrderRef,
                                                                                           SalesOrderRelease,
                                                                                           SalesOrderLine,
                                                                                           SalesOrderQty,
                                                                                           SalesOrderISOUM,
                                                                                           RefNum,
                                                                                           RefLine,
                                                                                           RefProdOrderSequence,
                                                                                           RefOperationID,
                                                                                           RefConsumedItemLineNum,
                                                                                           RefOutputItemLineNum,
                                                                                           RefRelease,
                                                                                           SerializedLotID,
                                                                                           SerializedLotExpDate,
                                                                                           HoldCode,
                                                                                           CountSequence,
                                                                                           ReceivedDateTime,
                                                                                           WareHouse,
                                                                                           Status,
                                                                                           ref InfoBar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBReceiveLinePLSp(string RefNum,
        DateTime? ReceivedDateTime,
        string RefType,
        [Optional] decimal? ShipmentID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ESBReceiveLinePLExt = new CLM_ESBReceiveLinePLFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iCLM_ESBReceiveLinePLExt.CLM_ESBReceiveLinePLSp(RefNum,
                ReceivedDateTime,
                RefType,
                ShipmentID);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBReceiveShipLineSp(decimal? DocumentID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ESBReceiveShipLineExt = new CLM_ESBReceiveShipLineFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iCLM_ESBReceiveShipLineExt.CLM_ESBReceiveShipLineSp(DocumentID);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBShipLinePLSp(string RefNum,
        DateTime? ShippedDateTime,
        string RefType,
        [Optional] decimal? ShipmentID,
        [Optional] string ShipmentStatus)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ESBShipLinePLExt = new CLM_ESBShipLinePLFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iCLM_ESBShipLinePLExt.CLM_ESBShipLinePLSp(RefNum,
                ShippedDateTime,
                RefType,
                ShipmentID,
                ShipmentStatus);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }






        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SerialClearSp([Optional] string RefStr,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iSerialClearExt = new CSI.BusInterface.SerialClearFactory().Create(appDb,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iSerialClearExt.SerialClearSp(RefStr,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_ESBExt = new CLM_ESBFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new SQLParameterProvider(),
                true);

                var result = iCLM_ESBExt.CLM_ESBSp();

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void UpdateReceiveLocationPerHoldCode(
            string documentIDName,
            string purchaseOrderRef,
            string salesOrderRef,
            string item,
            string warehouse,
            string holdcode)
        {
            var iESBUpdLocExt = this.GetService<IESBReceiveShipLineViewsReceiveLocation>();
            iESBUpdLocExt.UpdateReceiveLocationPerHoldCode(
            documentIDName,
            purchaseOrderRef,
            salesOrderRef,
            item,
            warehouse,
            holdcode);
        }

    }
}
