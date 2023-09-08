using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol; 
using Mongoose.IDO;
using Mongoose.Core;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class ContainerFunctions : ShopFloorUtilities 
    {
        private string site = "";
        private string job = "";
        private string suffix = "";
        private string item = "";
        private string whse = "";
        private string containerNum = "";
        private string InfoBar = "";

        public ContainerFunctions(string site, string job, string suffix, string item, string whse, string containerNum, string InfoBar)
        {
            this.site = site;
            this.job = job;
            this.suffix = suffix;
            this.item = item;
            this.whse = whse;
            this.containerNum = containerNum;
            this.InfoBar = InfoBar;
            
        }

        public LoadCollectionResponseData GetJobMatlsByContainer()
        {
            LoadCollectionResponseData responseDataNew = new LoadCollectionResponseData();
            try {
                containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
                LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();
                requestDataNew.IDOName = "SLJobmatls";
                requestDataNew.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum,UbAcctAccessUnit1,UbAcctAccessUnit2,UbAcctAccessUnit3,UbAcctAccessUnit4,UbTransDate,RefLineSuf,RefRelease,DerByProduct,DerItemTaxFreeMatl,WcOutside,RecordDate,UbStartingSerial,UbEndingSerial");
                requestDataNew.Filter = "Job = '" + job + "' and Suffix = '" + suffix + "'";
                requestDataNew.RecordCap = -1;
                requestDataNew.OrderBy = "Job";
                CustomLoadMethod customLoadMethod = new CustomLoadMethod();
                customLoadMethod.Name = "GetJobMatlsSp";
                customLoadMethod.Parameters.Add(site);
                customLoadMethod.Parameters.Add(job);
                customLoadMethod.Parameters.Add(suffix);
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add(item);
                customLoadMethod.Parameters.Add("");
                customLoadMethod.Parameters.Add("1");
                customLoadMethod.Parameters.Add(whse);
                customLoadMethod.Parameters.Add("1");
                customLoadMethod.Parameters.Add(containerNum);                //container num
                customLoadMethod.Parameters.Add("");                //inforBar
                requestDataNew.CustomLoadMethod = customLoadMethod;
                responseDataNew = ExcuteQueryRequest(requestDataNew);
                if (responseDataNew == null || responseDataNew.Items.Count > 0)
                {
                }
                return responseDataNew;
            }
            catch (Exception ex)
            {
                InfoBar = ex.Message;
                return responseDataNew;
            }
           
        }
        
       public int GetContainerQtyCount(string containerNum, string item, string lot)
        {
            int iconserial = 0;
            LoadCollectionRequestData ConrequestData = new LoadCollectionRequestData();
            ConrequestData.IDOName = "SLContainerItems";
            ConrequestData.PropertyList.SetProperties("RowPointer, RecordDate, ContainerNum, Item,QtyContained");
            string filterString = "";
            if (string.IsNullOrEmpty(lot))
            {
                filterString = "ContainerNum = '" + containerNum + "' and Item ='" + formatItem(item) + "'";
            }
            else
            {
                filterString = "ContainerNum = '" + containerNum + "' and Item ='" + formatItem(item) + "' and Lot='" + lot + "'";
            }
            ConrequestData.Filter = filterString;
            ConrequestData.RecordCap = 1;
            ConrequestData.OrderBy = "ContainerNum";
            LoadCollectionResponseData ContainerSerialResponseData = ExcuteQueryRequest(ConrequestData);
            iconserial = Decimal.ToInt32(Convert.ToDecimal(ContainerSerialResponseData[0, "QtyContained"].ToString()));
            return iconserial;
        }
        public bool CheckContainerAndJobItems(LoadCollectionResponseData containerResponseData, out string errorMessage)
        {
            StringBuilder items = new StringBuilder();
            errorMessage = string.Empty;
            List<string> lstItems = new List<string>();
            for (int row = 0; row <= containerResponseData.Items.Count - 1; row++)
            {
                if (containerResponseData[row, "Item"] != null)
                {
                    lstItems.Add(containerResponseData[row, "Item"].ToString());
                    items = items.Append("'").Append(containerResponseData[row, "Item"].ToString()).Append("'").Append(",");
                }
            }
            if (items.Length > 1 && lstItems.Count > 0)
            {
                items = items.Remove(items.Length - 1, 1);

                LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                requestData.IDOName = "SLJobmatls";
                requestData.PropertyList.SetProperties("Job, Suffix, Item");
                requestData.Filter = String.Format("Job = '{0}' AND Suffix ='{1}' AND Item IN ({2})",job,suffix, items.ToString());
                requestData.Distinct = true;                
                LoadCollectionResponseData OrderOperSeqResponseData = ExcuteQueryRequest(requestData);
                
                if (OrderOperSeqResponseData.Items.Count == lstItems.Distinct().Count())
                {
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {                     
                    InvokeResponseData response = this.Context.Commands.Invoke("ApplicationMessages", "MsgAppSp", errorMessage
                                   , "W=ContainMoreItem2", "@container.container_num", this.containerNum
                                   , "@job", job, "@job.suffix", suffix, "", "", "", "", "", "", "", "", "");
                    if (response != null && response.Parameters != null && response.Parameters.Count > 0)
                        errorMessage = response.Parameters[0].GetValue(string.Empty);                   
                    return false;

                }
            }
            return true;
        }

    }
}
