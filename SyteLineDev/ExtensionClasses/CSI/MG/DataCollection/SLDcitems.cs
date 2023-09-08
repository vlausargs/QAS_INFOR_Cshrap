using CSI.MG;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.DataCollection;
using System.Runtime.InteropServices;

namespace CSI.MG.DataCollection
{
    [IDOExtensionClass("SLDcitems")]
    public class SLDcitems : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetumcfSp(string OtherUM,
                              string Item,
                              string VendNum,
                              string Area,
                              ref decimal? ConvFactor,
                              ref string Infobar,
                              [Optional] string Site)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iGetumcfExt = new GetumcfFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGetumcfExt.GetumcfSp(OtherUM,
                Item,
                VendNum,
                Area,
                ConvFactor,
                Infobar,
                Site);

                ConvFactor = result.ConvFactor;
                Infobar = result.Infobar;

                return result.ReturnCode.Value;
            }
        }
    }
}
