using CSI.MG.MGCore;


namespace CSI.BusInterface.ESBExtWhse
{
    public interface IHoldCode
    {
        string GetNewHoldCode();
        string GetOldHoldCode();
    }

    public class HoldCode : IHoldCode
    {

        readonly IGetVariable iGetVariable;

        int? servity;
        string infobar;
        string newHoldCode;
        string oldHoldCode;

        public HoldCode(IGetVariable iGetVariable)
        {
            this.iGetVariable = iGetVariable;
        }

        public string GetNewHoldCode()
        {
            (servity, newHoldCode, infobar) = iGetVariable.GetVariableSp(
                VariableName: "NewHoldCode",
                DefaultValue: "Nettable",
                DeleteVariable: 1,
                VariableValue: "",
                Infobar: "");
            if (servity != 0)
                throw new System.Exception(infobar);
            return newHoldCode;
        }

        public string GetOldHoldCode()
        {
            string infobar;
            int? servity;
            (servity, oldHoldCode, infobar) = iGetVariable.GetVariableSp(
                VariableName: "OldHoldCode",
                DefaultValue: "Nettable",
                DeleteVariable: 1,
                VariableValue: "",
                Infobar: "");
            if (servity != 0)
                throw new System.Exception(infobar);
            return oldHoldCode;
        }
    }
}
