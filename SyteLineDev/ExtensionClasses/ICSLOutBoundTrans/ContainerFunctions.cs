using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class ContainerFunctions : OutBoundUtilities
    {
        private string order = "";
        private string whse = "";
        private string containerNum = "";
      
        public ContainerFunctions(string order, string whse, string containerNum)
        {
            this.order = order;
            this.whse = whse;
            this.containerNum = containerNum;          
        }

        public LoadCollectionResponseData GetCOByContainer(ref string InfoBar)
        {
            LoadCollectionResponseData responseDataNew = new LoadCollectionResponseData();
            try
            {
                LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();
                requestDataNew.IDOName = "SLCoitemShps";
                requestDataNew.PropertyList.SetProperties("CoNum,CoLine,CoRelease,NoteExistsFlag,RowPointer,UM,DerShipStat,CoCustNum,AdrName,CoStat,DueDate,Stat,QtyOrderedConv,DerQtyShippedConv,DerQtyReturnedConv,DerQtyInvoicedConv,CoEinvoice,CoShipEarly,CoShipPartial,Item," +
                    "ItDescription,RefType,RefNum,RefLineSuf,RefRelease,ShipDate,DerQtyAvailableConv,DerItwhsQtyOnHandConv,ItSerialTracked,Whse,ItLotTracked,CoFixedRate,DerDropShipFlag,DerUM,DerQtyAvailable,ItwhsQtyOnHand,QtyOrdered,QtyReturned,QtyShipped,QtyInvoiced,UbLoc,UbLot," +
                    "UbQtyToShp,UbQtyToShpConv,UbRtnToStk,UbCrReturn,CusPrintPackInv,ItReservable,ItTaxFreeMatl,CoExportType,ItemTrackPieces,ItemDimensionGroup,UbStartingSerial,UbEndingSerial,UbContainerNum,ManufacturerId,ManufacturerItem,ManName,ManitemDescription,RecordDate,UbCoType," +
                    "CouEcCode,CusTaxCode1Type,DerItemExists,CusTaxRegNum1ExpDate");
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
                requestDataNew.RecordCap = -1;
                requestDataNew.OrderBy = "CoLine";
                CustomLoadMethod customLoadMethod = new CustomLoadMethod();
                customLoadMethod.Name = "CLM_OrderShippingSp";
                customLoadMethod.Parameters.Add(order);
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add("O");
                customLoadMethod.Parameters.Add(whse);
                customLoadMethod.Parameters.Add(containerNum);
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add("");
                requestDataNew.CustomLoadMethod = customLoadMethod;
                responseDataNew = ExcuteQueryRequest(requestDataNew);
                return responseDataNew;
            }
            catch (Exception ex)
            {
                InfoBar = ex.Message;
                return responseDataNew;
            }
        }

    }
}
