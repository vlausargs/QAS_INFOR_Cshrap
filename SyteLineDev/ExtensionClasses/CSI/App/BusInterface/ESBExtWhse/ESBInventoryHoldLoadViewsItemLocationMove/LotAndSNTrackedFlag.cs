using CSI.Data;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ILotAndSNTrackedFlag
    {
        (int lotTracked, int serialTracked) GetLotAndSNTrackedFlag(string Item);
    }

    public class LotAndSNTrackedFlag : ILotAndSNTrackedFlag
    {
        readonly ILotAndSNTrackedFlagCRUD iLotAndSNTrackedFlagCRUD;
        readonly IMsgApp iMsgApp;

        public LotAndSNTrackedFlag(ILotAndSNTrackedFlagCRUD iLotAndSNTrackedFlagCRUD, IMsgApp iMsgApp)
        {
            this.iLotAndSNTrackedFlagCRUD = iLotAndSNTrackedFlagCRUD;
            this.iMsgApp = iMsgApp;
        }

        public (int lotTracked, int serialTracked) GetLotAndSNTrackedFlag(string Item)
        {
            (int? lotTrackedReturn, int? serialTrackedReturn, int countReturn) = iLotAndSNTrackedFlagCRUD.GetLotAndSNTrackedFlag(Item);

            if (countReturn <= 0)
            {
                (int severity, string infoBar) = iMsgApp.MsgAppSp(
                    Infobar: "",
                    BaseMsg: "E=NoExist0",
                    Parm1: "@item.item"
                    );
                if (severity != 0)
                    throw new System.Exception(infoBar);
            }
            return (lotTrackedReturn ?? 0, serialTrackedReturn ?? 0);
        }
    }
}
