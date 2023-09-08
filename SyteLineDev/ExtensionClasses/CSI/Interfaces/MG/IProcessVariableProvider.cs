using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IProcessVariableProvider
    {
        string GetProcessVariable(string name);
        string GetProcessVariable(string name, string defaultValue, bool deleteVariable);
        void SetProcessVariable(string name, string varValue, bool ignoreError);
        void SetProcessVariable(string name, string varValue);
        void SetProcessVariableBatch(string name1, string varValue1, string name2 = null, string varValue2 = null, string name3 = null, string varValue3 = null, string name4 = null, string varValue4 = null, string name5 = null, string varValue5 = null, string name6 = null, string varValue6 = null, string name7 = null, string varValue7 = null, string name8 = null, string varValue8 = null, string name9 = null, string varValue9 = null, string name10 = null, string varValue10 = null);
    }
}
