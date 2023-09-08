using Mongoose.IDO.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class ProcessVariableProvider : IProcessVariableProvider
    {
        readonly AppDB appDB;
        readonly IAppDBProvider appDBProvider;
        public ProcessVariableProvider(IAppDBProvider appDBProvider)
        {
            this.appDBProvider = appDBProvider;
        }
        [Obsolete("Use the other constuctor. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public ProcessVariableProvider(AppDB appDB)
        {
            this.appDB = appDB;
        }
        private AppDB RuntimeAppDB
        {
            get
            {
                if (this.appDB != null) return this.appDB;
                return this.appDBProvider.AppDB;
            }
        }
        public string GetProcessVariable(string name)
        {
            return RuntimeAppDB.GetProcessVariable(name);
        }

        public string GetProcessVariable(string name, string defaultValue, bool deleteVariable)
        {
            return RuntimeAppDB.GetProcessVariable(name, defaultValue, deleteVariable);
        }

        public void SetProcessVariable(string name, string varValue, bool ignoreError)
        {
            RuntimeAppDB.SetProcessVariable(name, varValue, ignoreError);
        }

        public void SetProcessVariable(string name, string varValue)
        {
            RuntimeAppDB.SetProcessVariable(name, varValue);
        }

        public void SetProcessVariableBatch(string name1, string varValue1, string name2 = null, string varValue2 = null, string name3 = null, string varValue3 = null, string name4 = null, string varValue4 = null, string name5 = null, string varValue5 = null, string name6 = null, string varValue6 = null, string name7 = null, string varValue7 = null, string name8 = null, string varValue8 = null, string name9 = null, string varValue9 = null, string name10 = null, string varValue10 = null)
        {
            RuntimeAppDB.SetProcessVariableBatch(name1, varValue1, name2, varValue2, name3, varValue3, name4, varValue4, name5, varValue5, name6, varValue6, name7, varValue7, name8, varValue8, name9, varValue9, name10, varValue10);
        }
    }
}
