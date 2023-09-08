//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoitemShps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCoitemShps")]
    public class SLCoitemShps : CSIExtensionClassBase, IExtFTSLCoitemShps
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COShippingQtyConvWrapperSp(decimal? UbQtyToShpConv,
                                              string Item,
                                              string UM,
                                              string CoCustNum,
                                              ref decimal? UbQtyToShp,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCOShippingQtyConvWrapperExt = new COShippingQtyConvWrapperFactory().Create(appDb);

                int Severity = iCOShippingQtyConvWrapperExt.COShippingQtyConvWrapperSp(UbQtyToShpConv,
                                                                                       Item,
                                                                                       UM,
                                                                                       CoCustNum,
                                                                                       ref UbQtyToShp,
                                                                                       ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DoLineValidForOrderShipSp(string PDoNum,
                                             int? PDoLine,
                                             decimal? PQtyToShip,
                                             string PCoNum,
                                             short? PCoLine,
                                             short? PCoRelease,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDoLineValidForOrderShipExt = new DoLineValidForOrderShipFactory().Create(appDb);

                int Severity = iDoLineValidForOrderShipExt.DoLineValidForOrderShipSp(PDoNum,
                                                                                     PDoLine,
                                                                                     PQtyToShip,
                                                                                     PCoNum,
                                                                                     PCoLine,
                                                                                     PCoRelease,
                                                                                     ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DoNumForOrderShipValidSp(string PDoNum,
                                            decimal? PQtyToShip,
                                            string PCoNum,
                                            short? PCoLine,
                                            short? PCoRelease,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iDoNumForOrderShipValidExt = new DoNumForOrderShipValidFactory().Create(appDb);

                int Severity = iDoNumForOrderShipValidExt.DoNumForOrderShipValidSp(PDoNum,
                                                                                   PQtyToShip,
                                                                                   PCoNum,
                                                                                   PCoLine,
                                                                                   PCoRelease,
                                                                                   ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int OrderShipPackNumValidationSp(string CoNum,
                                                short? CoLine,
                                                short? CoRelease,
                                                int? PackNum,
                                                decimal? QtyShipped,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iOrderShipPackNumValidationExt = new OrderShipPackNumValidationFactory().Create(appDb);

                int Severity = iOrderShipPackNumValidationExt.OrderShipPackNumValidationSp(CoNum,
                                                                                           CoLine,
                                                                                           CoRelease,
                                                                                           PackNum,
                                                                                           QtyShipped,
                                                                                           ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateCONumStatusSp(string PCONum,
                                         string PCOLineStatus,
                                         ref byte? Consignment,
                                         ref string ConsignmentWarehouse,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateCONumStatusExt = new ValidateCONumStatusFactory().Create(appDb);

                int Severity = iValidateCONumStatusExt.ValidateCONumStatusSp(PCONum,
                                                                             PCOLineStatus,
                                                                             ref Consignment,
                                                                             ref ConsignmentWarehouse,
                                                                             ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COShippingCleanupSp()
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCOShippingCleanupExt = new COShippingCleanupFactory().Create(appDb);

                int Severity = iCOShippingCleanupExt.COShippingCleanupSp();

                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ShipLcrSp(string PCoNum,
                             DateTime? PTransDate,
                             string PMText,
                             ref string PromptMsg,
                             ref string PromptButtons,
                             ref string Infobar)
        {
            var iShipLcrExt = new ShipLcrFactory().Create(this, true);

            var result = iShipLcrExt.ShipLcrSp(PCoNum,
            PTransDate,
            PMText,
            PromptMsg,
            PromptButtons,
            Infobar);

            int Severity = result.ReturnCode.Value;
            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;
            return Severity;
        }


        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_OrderShippingSp([Optional] string CoNum,
                                             [Optional] DateTime? StartDate,
                                             [Optional] DateTime? EndDate,
                                             [Optional] string CoitemStatuses,
                                             [Optional] string CurWhse,
                                             string ContainerNum,
                                             ref string Infobar,
                                             [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_OrderShippingExt = new CLM_OrderShippingFactory().Create(appDb, bunchedLoadCollection);

                var result = iCLM_OrderShippingExt.CLM_OrderShippingSp(CoNum,
                                                                       StartDate,
                                                                       EndDate,
                                                                       CoitemStatuses,
                                                                       CurWhse,
                                                                       ContainerNum,
                                                                       Infobar,
                                                                       FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                Infobar = result.Infobar;
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COReturnQtyValidateSp(string CoitemCoNum,
            int? CoitemCoLine,
            int? CoitemCoRelease,
            string SDoNum,
            int? SDoLine,
            decimal? SQty,
            int? SReturn,
            string SLoc,
            string SLot,
            [Optional] int? PackNum,
            int? LotTrack,
            [Optional] ref string Infobar)
        {
            var iCOReturnQtyValidateExt = new COReturnQtyValidateFactory().Create(this, true);

            var result = iCOReturnQtyValidateExt.COReturnQtyValidateSp(CoitemCoNum,
                CoitemCoLine,
                CoitemCoRelease,
                SDoNum,
                SDoLine,
                SQty,
                SReturn,
                SLoc,
                SLot,
                PackNum,
                LotTrack,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COShippingLoopSp(int? OnHandNegative,
                                    ref int? FirstSequenceWithError,
                                    ref int? RecordsPosted,
                                    ref string Infobar,
                                    ref string PromptButtons,
                                    [Optional, DefaultParameterValue((byte)1)] byte? MsgFlag,
        [Optional, DefaultParameterValue((byte)1)] byte? SuppressReturnError,
        [Optional] string DocumentNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCOShippingLoopExt = new COShippingLoopFactory().Create(appDb);

                var result = iCOShippingLoopExt.COShippingLoopSp(OnHandNegative,
                                                                 FirstSequenceWithError,
                                                                 RecordsPosted,
                                                                 Infobar,
                                                                 PromptButtons,
                                                                 MsgFlag,
                                                                 SuppressReturnError,
                                                                 DocumentNum);

                int Severity = result.ReturnCode.Value;
                FirstSequenceWithError = result.FirstSequenceWithError;
                RecordsPosted = result.RecordsPosted;
                Infobar = result.Infobar;
                PromptButtons = result.PromptButtons;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SerialExpiryDateSp(string SerialNum,
                                      string SerialItem,
                                      [Optional, DefaultParameterValue((byte)1)] byte? SelectFlag,
        ref string PromptMsg,
        ref string PromptButtons,
        ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSerialExpiryDateExt = new SerialExpiryDateFactory().Create(appDb);

                var result = iSerialExpiryDateExt.SerialExpiryDateSp(SerialNum,
                                                                     SerialItem,
                                                                     SelectFlag,
                                                                     PromptMsg,
                                                                     PromptButtons,
                                                                     InfoBar);

                int Severity = result.ReturnCode.Value;
                PromptMsg = result.PromptMsg;
                PromptButtons = result.PromptButtons;
                InfoBar = result.InfoBar;
                return Severity;
            }
        }






        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_GetCOFilterSp(string PCOLineStatus,
        string PCONum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iCLM_GetCOFilterExt = new CLM_GetCOFilterFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCLM_GetCOFilterExt.CLM_GetCOFilterSp(PCOLineStatus,
                PCONum);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COShipGetPoXRefSp(string PPoNum,
        int? PPoLine,
        int? PPoRelease,
        ref int? PFound,
        ref string PType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iCOShipGetPoXRefExt = new COShipGetPoXRefFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCOShipGetPoXRefExt.COShipGetPoXRefSp(PPoNum,
                PPoLine,
                PPoRelease,
                PFound,
                PType);

                int Severity = result.ReturnCode.Value;
                PFound = result.PFound;
                PType = result.PType;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int COShippingPopulateTmpShpSP(string CoNum,
        int? CoLine,
        int? CoRelease,
        string UbDoNum,
        int? UbDoLine,
        decimal? UbQtyToShipConv,
        decimal? UbQtyToShip,
        string UbLoc,
        string UbLot,
        int? UbCrReturn,
        int? UbRtnToStk,
        int? UbByCons,
        string UbReasonCode,
        string UbWorkkey,
        DateTime? UbTransDate,
        Guid? RowPointer,
        int? UbSequence,
        string UbOrigInvoice,
        string UbReasonText,
        string UbImportdocId,
        string UbExportDocId,
        int? PackNum,
        string ContainerNum,
        string UM,
        string UbUserName,
        string UbEsigReason,
        Guid? UbEsigRowPointer,
        string UbEsigEncryptedPassword,
        DateTime? RecordDate,
        [Optional] decimal? ShipmentId,
        [Optional] int? ShipmentLine,
        [Optional] int? ShipmentSeq,
        [Optional] string UbOrigProFormaInvoice)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iCOShippingPopulateTmpShpExt = new COShippingPopulateTmpShpFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iCOShippingPopulateTmpShpExt.COShippingPopulateTmpShpSP(CoNum,
                CoLine,
                CoRelease,
                UbDoNum,
                UbDoLine,
                UbQtyToShipConv,
                UbQtyToShip,
                UbLoc,
                UbLot,
                UbCrReturn,
                UbRtnToStk,
                UbByCons,
                UbReasonCode,
                UbWorkkey,
                UbTransDate,
                RowPointer,
                UbSequence,
                UbOrigInvoice,
                UbReasonText,
                UbImportdocId,
                UbExportDocId,
                PackNum,
                ContainerNum,
                UM,
                UbUserName,
                UbEsigReason,
                UbEsigRowPointer,
                UbEsigEncryptedPassword,
                RecordDate,
                ShipmentId,
                ShipmentLine,
                ShipmentSeq,
                UbOrigProFormaInvoice);

                int Severity = result.Value;
                return Severity;
            }
        }
    }
}
