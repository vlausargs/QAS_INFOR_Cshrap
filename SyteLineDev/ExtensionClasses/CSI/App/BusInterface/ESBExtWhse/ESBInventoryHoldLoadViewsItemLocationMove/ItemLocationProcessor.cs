using CSI.Material;
using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemLocationProcessor
    {

        void MoveItems(DateTime? transactionDate, decimal? qty, string item, string warehouse, string newHoldCode, string workkey);
    }

    public class ItemLocationProcessor : IItemLocationProcessor
    {
        readonly IInventoryHoldLoadPreOperation iInventoryHoldLoadPreOperations;
        readonly IMvPost iMvPost;

        public ItemLocationProcessor(IInventoryHoldLoadPreOperation iInventoryHoldLoadPreOperations, IMvPost iMvPost)
        {
            this.iInventoryHoldLoadPreOperations = iInventoryHoldLoadPreOperations;
            this.iMvPost = iMvPost;
        }

        public void MoveItems(DateTime? transactionDate, decimal? qty, string item, string warehouse, string newHoldCode, string workkey)
        {
            (string whse, DateTime tDate, string fromLoc, string toLoc, string lot) = iInventoryHoldLoadPreOperations.ValidateAndPrepareDataForItemMovement(item, warehouse, transactionDate, newHoldCode);

            (int? severityOutput, _, _, _, _, _, _, _, string infobarOutput) =
            iMvPost.MvPostSp(
            PType: "M",
            PDate: tDate,
            PQty: qty,
            PItem: item,
            FromWhse: whse,
            FromLoc: fromLoc,
            FromLot: lot,
            ToWhse: whse,
            ToLoc: toLoc,
            ToLot: lot,
            PZeroCost: 0,
            PTrnNum: null,
            PTrnLine: null,
            PTransNum: null,
            PRsvdNum: null,
            PStat: "I",
            PRefNum: null,
            PRefLineSuf: null,
            PRefRelease: null,
            RefStr: workkey,
            Infobar: "");

            if (severityOutput != 0)
                throw new Exception(infobarOutput);
        }
    }
}
