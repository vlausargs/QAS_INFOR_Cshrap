using CSI.ServiceClasses.CSIServiceClasses;
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
    public class MGCollectionUpdate : ICollectionUpdate
    {
        IIDOExtensionClassContext context;

        public MGCollectionUpdate(IIDOExtensionClassContext context)
        {
            this.context = context;
        }

        public void Update(ICollectionUpdateRequest updateRequest)
        {
            if (updateRequest.ValuesByColumnToAssign != null)
                MGUpdateFromValues(updateRequest);

            if (updateRequest.Items != null)
                MGUpdateFromTable(updateRequest);
        }

        void MGUpdateFromValues(ICollectionUpdateRequest updateRequest)
        {
            if(updateRequest.Items.Count > 1)
            {
                //warning - one set of variables is updating many records
                //this might be valid, but let's throw an exception for now
                throw new Exception("Update request against many records via one set of variables");
            }

            var request = new UpdateCollectionRequestData();
            request.IDOName = updateRequest.IDOName;
            request.RefreshAfterUpdate = false;

            foreach (var record in updateRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                var itemUpdate = new IDOUpdateItem();
                itemUpdate.Action = UpdateAction.Update;
                itemUpdate.ItemID = recordInternal.MGItemID;

                foreach (var pair in updateRequest.ValuesByColumnToAssign)
                {
                    var column = pair.Key;
                    var variable = pair.Value;
                    var variableValue = variable is IUDDTType ? (variable as IUDDTType).Value : variable;

                    itemUpdate.Properties.Add(column, variableValue);
                }

                request.Items.Add(itemUpdate);
            }

            var response = context.Commands.UpdateCollection(request);
        }

        void MGUpdateFromTable(ICollectionUpdateRequest updateRequest)
        {
            var request = new UpdateCollectionRequestData();
            request.IDOName = updateRequest.IDOName;
            request.RefreshAfterUpdate = false;

            foreach (var record in updateRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                var itemUpdate = new IDOUpdateItem();
                itemUpdate.Action = UpdateAction.Update;
                itemUpdate.ItemID = recordInternal.MGItemID;

                foreach (var column in updateRequest.Items.Columns)
                    itemUpdate.Properties.Add(column, recordInternal.GetValue(column));

                request.Items.Add(itemUpdate);
            }

            var response = context.Commands.UpdateCollection(request);
        }

    }
}
