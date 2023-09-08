using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGCollectionDelete : ICollectionDelete
    {
        IIDOExtensionClassContext context;

        public MGCollectionDelete(IIDOExtensionClassContext context)
        {
            this.context = context;
        }

        public void Delete(ICollectionDeleteRequest updateRequest)
        {
            var request = new UpdateCollectionRequestData();
            request.IDOName = updateRequest.IDOName;
            request.RefreshAfterUpdate = false;

            foreach (var record in updateRequest.Items)
            {
                var recordInternal = record as IRecordInternal;
                if (recordInternal == null) throw new Exception("Internal Error: IRecordInternal not implemented");

                var itemUpdate = new IDOUpdateItem();
                itemUpdate.Action = Mongoose.IDO.Protocol.UpdateAction.Delete;
                itemUpdate.ItemID = recordInternal.MGItemID;

                foreach (var column in updateRequest.Items.Columns)
                    itemUpdate.Properties.Add(column, recordInternal.GetValue(column));

                request.Items.Add(itemUpdate);
            }

            var response = context.Commands.UpdateCollection(request);
        }

        public void DeleteWithoutTrigger(ICollectionDeleteRequest deleteRequest)
        {
            throw new NotImplementedException();
        }
    }
}
