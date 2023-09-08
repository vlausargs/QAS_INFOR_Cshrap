using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.Metric;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class CollectionInsertFactory
    {
        public ICollectionInsert Create(IIDOExtensionClassContext context, ICommandProvider commandProvider, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement, IInterceptConfiguration interceptConfiguration)
        {
            var bulkCopyFactory = new SQLBulkCopyFactory();
            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
            ICollectionInsert sqlCollectionInsert = new SQLCollectionInsert(commandProvider, bulkCopyFactory, queryLanguage, triggerManagement, recordCollectionToDataTable);
            var mgInsertCollection = new MGCollectionInsert(context);
            sqlCollectionInsert = new SQLCollectionInsertWithMGIntercept(mgInsertCollection, sqlCollectionInsert, interceptConfiguration);

            sqlCollectionInsert = new TimerFactory().Create<ICollectionInsert>(sqlCollectionInsert);

            return sqlCollectionInsert;
        }
    }
}
