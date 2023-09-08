using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadBuilderProcess : ISQLCollectionLoadBuilderProcess
    {
        readonly ILoadRequestVariablesUpdate loadRequestVariablesUpdate;

        public SQLCollectionLoadBuilderProcess(ILoadRequestVariablesUpdate loadRequestVariablesUpdate)
        {
            this.loadRequestVariablesUpdate = loadRequestVariablesUpdate;
        }

        public ICollectionLoadResponse Process(
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IEnumerable<string> columns,
            IReadOnlyDictionary<string, object> data)
        {
            var dictionaryOfData = new Dictionary<string, object>();
            foreach (var v in data)
            {
                if (v.Value is IUDDTType uDDTVar)
                {
                    dictionaryOfData.Add(v.Key, uDDTVar.Value);
                }
                else
                {
                    dictionaryOfData.Add(v.Key, v.Value);
                }
            }
            var listOfData = new List<Dictionary<string, object>>() { dictionaryOfData };

            var recordCollection = RecordCollection.Create(columns, listOfData);
            var response = new SQLCollectionLoadResponse(recordCollection);
            loadRequestVariablesUpdate.UpdateRequestVariables(response, columnNameByVariableToAssign);

            return response;
        }

        public ICollectionLoadResponse Process(
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IEnumerable<string> columns,
            IReadOnlyDictionary<string, IParameterizedCommand> data)
        {
            var dictionaryOfData = new Dictionary<string, object>();
            foreach (var v in data)
            {
                dictionaryOfData.Add(v.Key, v.Value);
            }
            var listOfData = new List<Dictionary<string, object>>() { dictionaryOfData };

            var recordCollection = RecordCollection.Create(columns, listOfData);
            var response = new SQLCollectionLoadResponse(recordCollection);
            loadRequestVariablesUpdate.UpdateRequestVariables(response, columnNameByVariableToAssign);

            return response;
        }
    }
}
