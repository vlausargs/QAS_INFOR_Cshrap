using CSI.Admin;
using CSI.MG.MGCore;


namespace CSI.BusInterface.ESBExtWhse
{

    public interface IESBInventoryHoldLoadViewsNewHoldCodes
    {
        void SetHoldCode(string holdCode);
    }
    public class ESBInventoryHoldLoadViewsNewHoldCodes : IESBInventoryHoldLoadViewsNewHoldCodes
    {
        readonly IDefineVariable iDefineVariable;
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IExternalHoldCodeCRUD iExternalHoldCodeCRUD;

        public ESBInventoryHoldLoadViewsNewHoldCodes(IDefineVariable iDefineVariable, IIsFeatureActive iIsFeatureActive, IExternalHoldCodeCRUD iExternalHoldCodeCRUD)
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
                    VariableName: "NewHoldCode",
                    VariableValue: "NonNettable",
                    Infobar: "");
                if ((returnCode ?? 0) != 0)
                    throw new System.Exception(infobar);
            }
        }
    }
}
