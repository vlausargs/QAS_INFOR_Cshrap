using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGPostUpdateCollectionHandler
    {
        IIDOExtensionClassContext context;
        ITriggerManagement triggerManagement;
        IIDOMetaData idoMetaData;

        public MGPostUpdateCollectionHandler(
            IIDOExtensionClassContext context, 
            ITriggerManagement triggerManagement,
            IIDOMetaData idoMetaData)
        {
            this.context = context;
            this.triggerManagement = triggerManagement;
            this.idoMetaData = idoMetaData;
        }

        bool performTrigger = false;

        public ITriggerState PrepareForTrigger(
            ITriggerState triggerState,
            UpdateAction actionMask,
            UpdateCollectionRequestData request,
            UpdateCollectionResponseData response)
        {
            if (!performTrigger)
                return null;

            string baseTable = idoMetaData.GetBaseTableFromIdoName(context.IDO.Name);
            var modifiedItemIDs = request.Items.Select(i => i.ItemID);

            switch (actionMask & UpdateAction.Delete)
            {
                case UpdateAction.Delete:
                    triggerManagement.SnapshotDataBeforeMGDelete(baseTable, triggerState, modifiedItemIDs);
                    return triggerState;

                case UpdateAction.Insert:
                    return triggerState;

                case UpdateAction.Update:
                    triggerManagement.SnapshotDataBeforeMGUpdate(baseTable, triggerState, modifiedItemIDs);
                    return triggerState;

                default:
                    //Hmm.. I wonder why we got here
                    return triggerState;
            }
        }

        public void ExecuteTrigger(
            ITriggerState triggerState,
            UpdateAction actionMask,
            UpdateCollectionRequestData request,
            UpdateCollectionResponseData response)
        {
            if (!performTrigger) return;

            string baseTable = idoMetaData.GetBaseTableFromIdoName(context.IDO.Name);

            switch (actionMask & UpdateAction.Delete)
            {
                case UpdateAction.Delete:
                    IRecordCollection deleted = null; //get the predelete data from triggerState
                    triggerManagement.ExecuteTriggerAfterDelete(baseTable, deleted);
                    return;

                case UpdateAction.Insert:
                    IRecordCollection inserted = null; //get the inserted data from request
                    triggerManagement.ExecuteTriggerAfterInsert(baseTable, inserted);
                    return;

                case UpdateAction.Update:
                    IRecordCollectionWithDeleted updated = null; //get the predelete data from triggerState and the inserted data from request
                    triggerManagement.ExecuteTriggerAfterUpdate(baseTable, updated);
                    return;

                default:
                    //Hmm.. I wonder why we got here
                    return;
            }
        }
    }
}
