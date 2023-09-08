//PROJECT NAME: MaterialExt
//CLASS NAME: SLNonInventoryItems.cs

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
    [IDOExtensionClass("SLNonInventoryItems")]
    public class SLNonInventoryItems : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateNonInventoryItemSp(string item, ref string PromptMsg)
        {
            var iValidateNonInventoryItemExt = new ValidateNonInventoryItemFactory().Create(this, true);

            var result = iValidateNonInventoryItemExt.ValidateNonInventoryItemSp(item, PromptMsg);

            PromptMsg = result.PromptMsg;

            return result.ReturnCode ?? 0;
        }
    }
}
