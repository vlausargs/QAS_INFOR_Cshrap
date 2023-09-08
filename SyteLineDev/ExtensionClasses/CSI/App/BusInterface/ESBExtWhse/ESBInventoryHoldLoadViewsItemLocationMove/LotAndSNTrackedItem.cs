using System;


namespace CSI.BusInterface.ESBExtWhse
{
    public interface ILotAndSNTrackedItem
    {
        string GetLotAndSetCheckLocFlag(string item);
    }

    public class LotAndSNTrackedItem : ILotAndSNTrackedItem
    {
        readonly ILotAndSNTrackedFlag iLotAndSNTrackedFlag;
        readonly ISNTrackedItem iSNTrackedItem;
        readonly IExternalLot externalLot;

        public LotAndSNTrackedItem(ILotAndSNTrackedFlag iLotAndSNTrackedFlag, ISNTrackedItem iSNTrackedItem, IExternalLot externalLot)
        {
            this.iLotAndSNTrackedFlag = iLotAndSNTrackedFlag;
            this.iSNTrackedItem = iSNTrackedItem;
            this.externalLot = externalLot;
        }

        public string GetLotAndSetCheckLocFlag(string item)
        {
            string lot = null;

            (int lotTracked, int serialTracked) = iLotAndSNTrackedFlag.GetLotAndSNTrackedFlag(item);

            if (serialTracked == 1)
                iSNTrackedItem.SetMvPostSpCheckLocFlag();
            if (lotTracked == 1)
                lot = externalLot.GetExpandedLotFromSessionVariable();
            return lot;
        }
    }
}
