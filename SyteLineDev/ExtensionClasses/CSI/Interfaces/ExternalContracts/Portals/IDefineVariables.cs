using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IDefineVariables
    {
        int DefineVariableSp(string VariableName, string VariableValue, string Infobar);
    }
}
