using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.ExternalContracts.FactoryTrack;

namespace InforCollect.ERP.SL.ICSLInventoryCountTrans
{
    public class InventoryCountTransactions : ExtensionClassBase, IExtFTICSLInventoryCountTrans
    {
        private int retVal = -1;
        public int PhysicalInvTagUpdate(string tag, string sheet,string item, string site, string whse,
                                    string loc, string lot, string uom, string qty,string user, string RowPointer,
                                     string RecordDate, string SerNum, bool addItemLocRecord, bool isChecker,
                                          bool addPermanentItemWhseLocLink, bool addSerial,
                                          bool addLot, out string Infobar, string userInitial="")
        {

            Infobar = "";
            PhysicalInvTagUpdate physicalInvTagUpdate = new PhysicalInvTagUpdate(tag,sheet, item, site, whse,
                                     loc,lot, uom,qty,user,RowPointer,RecordDate,SerNum, addItemLocRecord,
                                      isChecker, addPermanentItemWhseLocLink, addSerial,addLot);

            //  The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            physicalInvTagUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103            

            physicalInvTagUpdate.SetContext(this.Context);
            physicalInvTagUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = physicalInvTagUpdate.PerformUpdate(out Infobar);
            return retVal;
        }
        public int CycleCountUpdate(string item, string site, string whse,
                                    string loc, string lot, string uom, string qty,string user, string RowPointer,
                                    string RecordDate, string SerNum, bool addItemLocRecord,bool addCycleCountRecord ,
                                    bool addPermanentItemWhseLocLink, out string Infobar, string userInitial="")
        {

            Infobar = "";
            CycleCountUpdate cycleCountUpdate = new CycleCountUpdate( item, site, whse,
                                     loc, lot, uom, qty, user, RowPointer, RecordDate, SerNum, addItemLocRecord,
                                      addCycleCountRecord, addPermanentItemWhseLocLink);
                        //  The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            cycleCountUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103            

            cycleCountUpdate.SetContext(this.Context);
            cycleCountUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = cycleCountUpdate.PerformUpdate(out Infobar);
            return retVal;
        }

        
    }
}
