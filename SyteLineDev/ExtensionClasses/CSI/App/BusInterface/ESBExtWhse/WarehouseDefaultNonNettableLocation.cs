using CSI.Data;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IWarehouseDefaultNonNettableLocation
    {
        string CheckWhseDefNonNetLoc(string Whse);
    }

    public class WarehouseDefaultNonNettableLocation : IWarehouseDefaultNonNettableLocation
    {
        readonly IWarehouseDefaultNonNettableLocationCRUD iWarehouseDefaultNonNettableLocationCRUD;
        readonly IMsgApp iMsgApp;

        public WarehouseDefaultNonNettableLocation(IWarehouseDefaultNonNettableLocationCRUD iWarehouseDefaultNonNettableLocationCRUD,
            IMsgApp iMsgApp)
        {
            this.iWarehouseDefaultNonNettableLocationCRUD = iWarehouseDefaultNonNettableLocationCRUD;
            this.iMsgApp = iMsgApp;
        }

        public string CheckWhseDefNonNetLoc(string whse)
        {
            int severity;
            string infobar;
            string whseDefNonNetLoc = iWarehouseDefaultNonNettableLocationCRUD.GetWhseDefNonNetLoc(whse);

            if (string.IsNullOrEmpty(whseDefNonNetLoc))
            {
                (int ReturnCode, string Infobar) = iMsgApp.MsgAppSp(
                    Infobar: "",
                    BaseMsg: "E=NoExist0",
                    Parm1: "@whse.def_external_whse_non_nettable_loc");
                severity = ReturnCode;
                infobar = Infobar;

                if (severity != 0)
                    throw new System.Exception(infobar);
            }

            return whseDefNonNetLoc;
        }
    }
}
