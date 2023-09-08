using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.MG
{
    public class MGCollectionInsert : ICollectionInsert
    {
        IIDOExtensionClassContext context;

        public MGCollectionInsert(IIDOExtensionClassContext context)
        {
            this.context = context;
        }

        public void Insert(ICollectionInsertRequest insertRequest)
        {
            if (insertRequest.ValuesByColumnToAssign != null)
            {
                MGInsertFromValues(insertRequest);
                return;
            }

            if (insertRequest.Items != null)
            {
                MGInsertFromTable(insertRequest);
                return;
            }
        }

        void MGInsertFromValues(ICollectionInsertRequest insertRequest)
        {
            var request = new UpdateCollectionRequestData();
            request.IDOName = insertRequest.IDOName;
            request.RefreshAfterUpdate = false;

            var itemUpdate = new IDOUpdateItem();
            itemUpdate.Action = UpdateAction.Insert;

            foreach (var pair in insertRequest.ValuesByColumnToAssign)
            {
                var column = pair.Key;
                var variable = pair.Value;
                var variableValue = variable is IUDDTType ? (variable as IUDDTType).Value : variable;

                itemUpdate.Properties.Add(column, variableValue);
            }

            request.Items.Add(itemUpdate);

            var response = context.Commands.UpdateCollection(request);
        }

        void MGInsertFromTable(ICollectionInsertRequest insertRequest)
        {
            var request = new UpdateCollectionRequestData();
            request.IDOName = insertRequest.IDOName;
            request.RefreshAfterUpdate = false;

            foreach (var record in insertRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                var itemUpdate = new IDOUpdateItem();
                itemUpdate.Action = Mongoose.IDO.Protocol.UpdateAction.Insert;

                foreach (var column in insertRequest.Items.Columns)
                    itemUpdate.Properties.Add(column, recordInternal.GetValue(column));

                request.Items.Add(itemUpdate);
            }

            var response = context.Commands.UpdateCollection(request);
        }
    }
}
