
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLInventoryCountTrans
    {

        int CycleCountUpdate(string item, string site, string whse,
                string loc, string lot, string uom, string qty,string user, string RowPointer,
                string RecordDate, string SerNum, bool addItemLocRecord,bool addCycleCountRecord ,
                bool addPermanentItemWhseLocLink, out string Infobar, string userInitial=""); 

        int PhysicalInvTagUpdate(string tag, string sheet,string item, string site, string whse,
                string loc, string lot, string uom, string qty,string user, string RowPointer,
                string RecordDate, string SerNum, bool addItemLocRecord, bool isChecker,
                bool addPermanentItemWhseLocLink, bool addSerial,
                bool addLot, out string Infobar, string userInitial=""); 

    }
}
    
