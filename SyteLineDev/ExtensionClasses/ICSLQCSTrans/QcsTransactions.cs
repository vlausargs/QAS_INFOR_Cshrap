using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.ExternalContracts.FactoryTrack;

namespace InforCollect.ERP.SL.ICSLQCSTrans
{
    public class QcsTransactions : ExtensionClassBase, IExtFTICSLQcsTrans
    {
        private int retVal = 16;
        public int TestRecordsUpdate(string receiverNum, string ordType, string testId, string testSeq, string order, bool passFlag, string item, string qtyTested, string qtyAccepted,
                                 string qtyRejected, string actualMin, string actualNominal, string actualMax, string uom, string qcLot, string lot, string lotSize, string sampleSize,
                                 string inspId, string prmCheckFailCode, string actualGage, string transDate, string complete, string testValue, string testType, out string InfoBar, string userInitial)
        {           
            InfoBar = "";
            TestRecordsUpdate testRecordsUpdate = new TestRecordsUpdate( receiverNum,ordType,  testId,  testSeq,  order,  ""+passFlag,    item,  qtyTested,  qtyAccepted,
                                  qtyRejected,  actualMin,  actualNominal,  actualMax,  uom,  qcLot,  lot,  lotSize,sampleSize,  inspId,
                                  prmCheckFailCode, actualGage, transDate, complete, testValue, testType,userInitial);
            
            testRecordsUpdate.Initialize(); 
            testRecordsUpdate.SetContext(this.Context); 
            testRecordsUpdate.SetMessageProvider(this.GetMessageProvider());

            retVal = testRecordsUpdate.PerformUpdate(out InfoBar);
            return retVal;             
        }
        public int GenerateTestUpdate(string receiverNum, string refType, string testType, string lot, string qcLot, string lotSize,
                                      string sampleSize, string inspId,   out string InfoBar)
        {
            InfoBar = "";
            GenerateTestUpdate generateTestUpdate = new GenerateTestUpdate( receiverNum,  refType,  testType,  lot,  qcLot,  lotSize,  sampleSize,  inspId );
          
            generateTestUpdate.Initialize(); 
            generateTestUpdate.SetContext(this.Context); 
            generateTestUpdate.SetMessageProvider(this.GetMessageProvider());
            retVal = generateTestUpdate.PerformUpdate(out InfoBar );
            return retVal;

        }

        public int DispositionUpdate(string receiverNum, string ordType, string order, bool completeFlag, string userCode, string inspId, string qtyAccepted, string acceptReason,
                                 string acceptDispCode, string qtyRejected, string rejectReason, string rejectDispCode, string rejectCause, string rejectDispType, string qtyHold, string MrrHoldReason, string MrrNum,
                                 string qtyScrapped, string scrapReason, bool OperComplete, out string InfoBar, string additionalQty, string cocNum, string userInitial)
        {
            InfoBar = "";
            DispositionUpdate dispositionUpdate = new  DispositionUpdate( receiverNum,   ordType,  order,  ""+completeFlag,  userCode,  inspId,  qtyAccepted,  acceptReason, 
                                  acceptDispCode, qtyRejected,  rejectReason,  rejectDispCode,  rejectCause,  rejectDispType,  qtyHold,  MrrHoldReason,  MrrNum,
                                  qtyScrapped, scrapReason, "" + OperComplete, additionalQty,cocNum,userInitial);
            
            dispositionUpdate.Initialize(); 
            dispositionUpdate.SetContext(this.Context); 
            dispositionUpdate.SetMessageProvider(this.GetMessageProvider());

            retVal = dispositionUpdate.PerformUpdate(out InfoBar);
            return retVal;

        }


        

    }
}
