using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadProcess : ISQLCollectionLoadProcess
    {
        readonly ICommandProvider cp;
        readonly ILoadRequestVariablesUpdate loadRequestVariablesUpdate;

        public SQLCollectionLoadProcess(
            ICommandProvider cp, 
            ILoadRequestVariablesUpdate loadRequestVariablesUpdate)
        {
            this.cp = cp ?? throw new ArgumentNullException(nameof(cp));
            this.loadRequestVariablesUpdate = loadRequestVariablesUpdate ?? throw new ArgumentNullException(nameof(loadRequestVariablesUpdate));
        }

        public ICollectionLoadResponse Process(
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            string statement,
            IEnumerable<IDataParameter> parameters,
            int? maximumRows,
            IEnumerable<string> augmentedRequestedColumns)
        {
            using (IDbCommand cmd = cp.CreateCommand())
            {
                cmd.CommandText = statement;

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                //Load the data
                var data = new List<Dictionary<string, object>>();
                int recordCount = maximumRows ?? 0;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //create a record
                        var recordData = new Dictionary<string, object>();
                        foreach (var column in augmentedRequestedColumns)
                        {
                            recordData[column] = reader[column];
                        }
                        data.Add(recordData);

                        //check the record max
                        if (recordCount > 0)
                        {
                            if (--recordCount == 0)
                                break;
                        }
                    }
                }

                var recordCollection = RecordCollection.Create(augmentedRequestedColumns, data);
                var response = new SQLCollectionLoadResponse(recordCollection);

                loadRequestVariablesUpdate.UpdateRequestVariables(response, columnNameByVariableToAssign);

                return response;
            }
        }
    }
}
