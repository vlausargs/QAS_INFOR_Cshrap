using CSI.Admin;
using CSI.MG.MGCore;
using System;


namespace CSI.BusInterface.ESBExtWhse
{
    public interface IESBInventoryHoldLoadViewsItemLocationMove
    {
        void MoveItemsInOutNonNettableLocation(string documentID, string item, string warehouse, DateTime? transactionDate, decimal? qty);
    }

    public class ESBInventoryHoldLoadViewsItemLocationMove : IESBInventoryHoldLoadViewsItemLocationMove
    {
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IESBInventoryHoldLoadViewsItemLocationMoveCRUD iESBInventoryHoldLoadViewsItemLocationMoveCRUD;
        readonly IItemLocationProcessor iItemLocationProcessor;
        readonly IExternalWorkkey iExternalWorkkey;
        readonly ISessionID iSessionID;
        readonly IHoldCode iHoldCodes;

        public ESBInventoryHoldLoadViewsItemLocationMove(IIsFeatureActive iIsFeatureActive, IESBInventoryHoldLoadViewsItemLocationMoveCRUD iESBInventoryHoldLoadViewsItemLocationMoveCRUD, IItemLocationProcessor iItemLocationProcessor, ISessionID iSessionID, IExternalWorkkey iExternalWorkkey, IHoldCode iHoldCodes)
        {
            this.iIsFeatureActive = iIsFeatureActive;
            this.iESBInventoryHoldLoadViewsItemLocationMoveCRUD = iESBInventoryHoldLoadViewsItemLocationMoveCRUD;
            this.iItemLocationProcessor = iItemLocationProcessor;
            this.iSessionID = iSessionID;
            this.iExternalWorkkey = iExternalWorkkey;
            this.iHoldCodes = iHoldCodes;
        }

        public void MoveItemsInOutNonNettableLocation(string documentID, string item, string warehouse, DateTime? transactionDate, decimal? qty)
        {
            Guid sessionID = iSessionID.SessionIDSp();
            string workkey = iExternalWorkkey.ConcatWorkkey(documentID, "0");
            string newHoldCode = iHoldCodes.GetNewHoldCode();
            string oldHoldCode = iHoldCodes.GetOldHoldCode();
            try
            {
                (int? returnCode, int? featureActive, string infobar) = iIsFeatureActive.IsFeatureActiveSp(
                    ProductName: "CSI",
                    FeatureID: "RS9166",
                    FeatureActive: 0,
                    InfoBar: null);

                if ((returnCode ?? 0) != 0)
                    throw new Exception(infobar);
                else if ((featureActive ?? 0) == 0)
                    return;

                if (newHoldCode != oldHoldCode)
                    iItemLocationProcessor.MoveItems(transactionDate, qty, item, warehouse, newHoldCode, workkey);
            }
            finally
            {
                iESBInventoryHoldLoadViewsItemLocationMoveCRUD.DeleteTmpSerData(sessionID, workkey);
            }
        }
    }
}