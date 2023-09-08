using CSI.Material;
using CSI.MG.MGCore;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IExternalLot
    {
        string GetExpandedLotFromSessionVariable();
    }

    public class ExternalLot : IExternalLot
    {
        readonly IGetVariable iGetVariable;
        readonly IExpandKyByType iExpandKyByType;

        public ExternalLot(IGetVariable iGetVariable, IExpandKyByType iExpandKyByType)
        {
            this.iGetVariable = iGetVariable;
            this.iExpandKyByType = iExpandKyByType;
        }

        public string GetExpandedLotFromSessionVariable()
        {
            int? severity;
            string infobar;
            string lotID = null;
            (severity, lotID, infobar) = iGetVariable.GetVariableSp(
                VariableName: "DerLotID",
                DefaultValue: "",
                DeleteVariable: 1,
                VariableValue: lotID,
                Infobar: "");
            if (severity != 0)
                throw new System.Exception(infobar);
            string lot = lotID?.Substring((lotID.LastIndexOf("~") + 1));
            (_, lot) = iExpandKyByType.ExpandKyByTypeSp("LotType", lot);
            return lot;
        }
    }
}
