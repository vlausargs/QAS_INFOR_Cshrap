using CSI.MG.MGCore;
using CSI.Admin;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IESBInventoryHoldLoadViewsOldHoldCodes
    {
        void SetHoldCode(string holdCode);
    }

    public class ESBInventoryHoldLoadViewsOldHoldCodes : IESBInventoryHoldLoadViewsOldHoldCodes
    {
        readonly IDefineVariable iDefineVariable;
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IExternalHoldCodeCRUD iExternalHoldCodeCRUD;

        public ESBInventoryHoldLoadViewsOldHoldCodes(IDefineVariable iDefineVariable, IIsFeatureActive iIsFeatureActive, IExternalHoldCodeCRUD iExternalHoldCodeCRUD)
        {
            this.iDefineVariable = iDefineVariable;
            this.iIsFeatureActive = iIsFeatureActive;
            this.iExternalHoldCodeCRUD = iExternalHoldCodeCRUD;
        }

        public void SetHoldCode(string holdCode)
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

            if (iExternalHoldCodeCRUD.IsExistInExtWhseHoldCode(holdCode))
            {
                (returnCode, infobar) = iDefineVariable.DefineVariableSp(
                    VariableName: "OldHoldCode",
                    VariableValue: "NonNettable",
                    Infobar: "");
                if ((returnCode ?? 0) != 0)
                    throw new System.Exception(infobar);
            }
        }
    }
}
