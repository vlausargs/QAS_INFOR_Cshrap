using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Data.SQL
{
    public class SQLProcessVariableProvider : IProcessVariableProvider
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        ICollectionLoad collectionLoad;
        ICollectionInsertRequestFactory collectionInsertRequestFactory;
        ICollectionInsert collectionInsert;
        ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        ICollectionUpdate collectionUpdate;

        public SQLProcessVariableProvider(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoad collectionLoad,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionInsert collectionInsert,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionUpdate collectionUpdate)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoad = collectionLoad;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionInsert = collectionInsert;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionUpdate = collectionUpdate;
        }

        public string GetProcessVariable(string name)
        {
            //here we manually do what mongoose would do so we don't have to call mongoose
            var loadRequest = collectionLoadRequestFactory.SQLLoad(
columns: new List<string>() { "Value" },
loadForChange: true,
lockingType: LockingType.UPDLock,
tableName: "Variables",
fromClause: collectionLoadRequestFactory.Clause(""),
whereClause: collectionLoadRequestFactory.Clause("FormID = {0} and Name = {1}", -1, name));
            var loadResponse = collectionLoad.Load(loadRequest);
            if (loadResponse.Items.Count > 0)
                return loadResponse.Items[0].GetValue<string>("Value");
            return string.Empty;
        }

        public string GetProcessVariable(string name, string defaultValue, bool deleteVariable)
        {
            throw new NotImplementedException();
        }

        public void SetProcessVariable(string name, string varValue, bool ignoreError)
        {
            throw new NotImplementedException();
        }

        public void SetProcessVariable(string name, string varValue)
        {
            //here we manually do what mongoose would do so we don't have to call mongoose
            var loadRequest = collectionLoadRequestFactory.SQLLoad(
columns: new List<string>() { "Value" },
loadForChange: true,
lockingType: LockingType.UPDLock,
tableName: "Variables",
fromClause: collectionLoadRequestFactory.Clause(""),
whereClause: collectionLoadRequestFactory.Clause("FormID = {0} and Name = {1}", -1, name));
            var loadResponse = collectionLoad.Load(loadRequest);
            if (loadResponse.Items.Count == 0)
            {
                var insertRequest = collectionInsertRequestFactory.SQLInsert(
tableName: "Variables",
valuesByColumnToAssign: new Dictionary<string, object>() { { "FormID", -1 }, { "Name", name }, { "Value", varValue } }
                    );
                collectionInsert.Insert(insertRequest);
                return;
            }

            loadResponse.Items[0].SetValue("Value", varValue);
            var updateRequest = collectionUpdateRequestFactory.SQLUpdate(
tableName: "Variables",
items: loadResponse.Items);
            collectionUpdate.Update(updateRequest);
        }

        public void SetProcessVariableBatch(string name1, string varValue1, string name2 = null, string varValue2 = null, string name3 = null, string varValue3 = null, string name4 = null, string varValue4 = null, string name5 = null, string varValue5 = null, string name6 = null, string varValue6 = null, string name7 = null, string varValue7 = null, string name8 = null, string varValue8 = null, string name9 = null, string varValue9 = null, string name10 = null, string varValue10 = null)
        {
            if (name1 != null) SetProcessVariable(name1, varValue1);
            if (name2 != null) SetProcessVariable(name2, varValue2);
            if (name3 != null) SetProcessVariable(name3, varValue3);
            if (name4 != null) SetProcessVariable(name4, varValue4);
            if (name5 != null) SetProcessVariable(name5, varValue5);
            if (name6 != null) SetProcessVariable(name6, varValue6);
            if (name7 != null) SetProcessVariable(name7, varValue7);
            if (name8 != null) SetProcessVariable(name8, varValue8);
            if (name9 != null) SetProcessVariable(name9, varValue9);
            if (name10 != null) SetProcessVariable(name10, varValue10);
        }
    }
}