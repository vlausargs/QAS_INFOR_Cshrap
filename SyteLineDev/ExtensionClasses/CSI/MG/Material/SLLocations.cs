//PROJECT NAME: MaterialExt
//CLASS NAME: SLLocations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLLocations")]
    public class SLLocations : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateLocationForExternalWarehouseSp(string PWhse,
                                                          string PLoc,
                                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateLocationForExternalWarehouseExt = new ValidateLocationForExternalWarehouseFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iValidateLocationForExternalWarehouseExt.ValidateLocationForExternalWarehouseSp(PWhse,
                                                                                      PLoc,
                                                                                      ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
