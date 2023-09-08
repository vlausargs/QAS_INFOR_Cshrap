using CSI.Admin;
using CSI.MG.MGCore;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IESBInventoryHoldLoadViewsLots
    {
        void SetLot(string DerLotID);
    }

    public class ESBInventoryHoldLoadViewsLots : IESBInventoryHoldLoadViewsLots
    {

        readonly IDefineVariable iDefineVariable;
        readonly IIsFeatureActive iIsFeatureActive;

        public ESBInventoryHoldLoadViewsLots(IDefineVariable iDefineVariable, IIsFeatureActive iIsFeatureActive)
        {
            this.iDefineVariable = iDefineVariable;
            this.iIsFeatureActive = iIsFeatureActive;
        }

        public void SetLot(string DerLotID)
        {
            (int? returnCode, int? featureActive, string infobar) = iIsFeatureActive.IsFeatureActiveSp(
                ProductName: "CSI",
                FeatureID: "RS9166",
                FeatureActive: 0,
                InfoBar: null);

            if ((returnCode ?? 0) != 0)
                throw new System.Exception(infobar);
            else if ((featureActive ?? 0) == 0)
                return;

            (returnCode, infobar) = iDefineVariable.DefineVariableSp(
                VariableName: "DerLotID",
                VariableValue: DerLotID,
                Infobar: "");
            if (returnCode != 0)
                throw new System.Exception(infobar);
        }
    }
}
