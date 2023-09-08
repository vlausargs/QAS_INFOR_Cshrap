//PROJECT NAME: TestExt
//CLASS NAME: SAMPCases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;

namespace CSI.MG.Test
{
    [IDOExtensionClass("SAMPCases")]
    public class SAMPCases : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemCostMethodCostTypeValidSp(string CostMethod,
                                                 string CostType,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemCostMethodCostTypeValidExt = new ItemCostMethodCostTypeValidFactory_().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iItemCostMethodCostTypeValidExt.ItemCostMethodCostTypeValidSp(CostMethod,
                                                                                             CostType,
                                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
