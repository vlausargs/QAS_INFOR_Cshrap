
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLQcsTrans
    {

        int DispositionUpdate(string receiverNum, string ordType, string order, bool completeFlag, string userCode, string inspId, string qtyAccepted, string acceptReason,
                string acceptDispCode, string qtyRejected, string rejectReason, string rejectDispCode, string rejectCause, string rejectDispType, string qtyHold, string MrrHoldReason, string MrrNum,
                string qtyScrapped, string scrapReason, bool OperComplete, out string InfoBar, string additionalQty, string cocNum, string userInitial); 

        int GenerateTestUpdate(string receiverNum, string refType, string testType, string lot, string qcLot, string lotSize,
                string sampleSize, string inspId,   out string InfoBar); 

        int TestRecordsUpdate(string receiverNum, string ordType, string testId, string testSeq, string order, bool passFlag, string item, string qtyTested, string qtyAccepted,
                string qtyRejected, string actualMin, string actualNominal, string actualMax, string uom, string qcLot, string lot, string lotSize, string sampleSize,
                string inspId, string prmCheckFailCode, string actualGage, string transDate, string complete, string testValue, string testType, out string InfoBar, string userInitial); 

    }
}
    
