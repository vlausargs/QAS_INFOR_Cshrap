using CSI.Data;
using CSI.MG.MGCore;
using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ISNTrackedItem
    {
        void SetMvPostSpCheckLocFlag();
    }

    public class SNTrackedItem : ISNTrackedItem
    {
        readonly IDefineVariable iDefineVariable;

        public SNTrackedItem(IDefineVariable iDefineVariable)
        {
            this.iDefineVariable = iDefineVariable;
        }

        public void SetMvPostSpCheckLocFlag()
        {
            (int? returnCode, string infobar) = iDefineVariable.DefineVariableSp(
                VariableName: "MvPostSp.CheckLoc",
                VariableValue: "Yes",
                Infobar: null);
            if ((returnCode ?? 0) != 0)
                throw new System.Exception(infobar);
        }
    }
}
