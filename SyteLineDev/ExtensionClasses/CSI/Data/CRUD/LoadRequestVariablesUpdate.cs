using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.SQL.UDDT;
using CSI.Data.RecordSets;

namespace CSI.Data.CRUD
{
    public class LoadRequestVariablesUpdate : ILoadRequestVariablesUpdate
    {
        public void UpdateRequestVariables(ICollectionLoadResponse response, IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign)
        {
            if (columnNameByVariableToAssign.Count() == 0)
                return;

            //var target = GetTarget(response);

            int targetRecordIndex = response.Items.Count - 1;

            if (targetRecordIndex < 0)
            {
                //odd, we didn't get even a single record

                //post warning

                //nothing to do
                return;
            }

            if (targetRecordIndex > 0)
            {
                //odd, we got more than one record; this routine might be inefficient

                //post warning
            }

            //update each variable
            var targetRecord = response.Items[targetRecordIndex];

            var targetRecordInternal = targetRecord as IRecordInternal;
            if (targetRecordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

            foreach (var pair in columnNameByVariableToAssign)
            {
                var variable = pair.Key;
                var columnName = pair.Value;
                variable.Value = targetRecordInternal.GetValue(columnName);
            }
        }
    }
}
