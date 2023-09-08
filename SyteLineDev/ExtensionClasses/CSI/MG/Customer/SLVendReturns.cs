//PROJECT NAME: CustomerExt
//CLASS NAME: SLVendReturns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLVendReturns")]
    public class SLVendReturns : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSRMXRtnLoadSp(string VendNum,
                                         byte? Reverse,
                                         string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSRMXRtnLoadExt = new SSSRMXRtnLoadFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iSSSRMXRtnLoadExt.SSSRMXRtnLoadSp(VendNum,
                                                                 Reverse,
                                                                 FilterString);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXRtnOneSp(decimal? ReturnSeq,
                                  DateTime? ReturnDate,
                                  decimal? QtyToReturnConv,
                                  string Whse,
                                  string Loc,
                                  string Lot,
                                  string UM,
                                  byte? Reverse,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXRtnOneExt = new SSSRMXRtnOneFactory().Create(appDb);

                int Severity = iSSSRMXRtnOneExt.SSSRMXRtnOneSp(ReturnSeq,
                                                               ReturnDate,
                                                               QtyToReturnConv,
                                                               Whse,
                                                               Loc,
                                                               Lot,
                                                               UM,
                                                               Reverse,
                                                               ref Infobar);

                return Severity;
            }
        }
    }
}
