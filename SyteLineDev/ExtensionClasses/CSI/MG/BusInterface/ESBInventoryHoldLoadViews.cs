using Mongoose.IDO;
using System;
using Microsoft.Extensions.DependencyInjection;
using CSI.BusInterface.ESBExtWhse;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBInventoryHoldLoadViews")]
    public class ESBInventoryHoldLoadViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public void SetNewHoldCode(string newHoldCode)
        {
            var iESBInventoryHoldLoadViewsNewHoldCodesExt = this.GetService<IESBInventoryHoldLoadViewsNewHoldCodes>();
            iESBInventoryHoldLoadViewsNewHoldCodesExt.SetHoldCode(newHoldCode);
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void SetOldHoldCode(string oldHoldCode)
        {
            var iESBInventoryHoldLoadViewsOldHoldCodesExt = this.GetService<IESBInventoryHoldLoadViewsOldHoldCodes>();
            iESBInventoryHoldLoadViewsOldHoldCodesExt.SetHoldCode(oldHoldCode);
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void MoveItemsInOutNonNettableLocation(string documentID, string item, string warehouse, DateTime? transactionDate, decimal? qty)
        {
            var iESBInventoryHoldLoadViewsItemLocationMoveExt = this.GetService<IESBInventoryHoldLoadViewsItemLocationMove>();
            iESBInventoryHoldLoadViewsItemLocationMoveExt.MoveItemsInOutNonNettableLocation(documentID, item, warehouse, transactionDate, qty);
        }
    }
}
