using CSI.Data.Metric;
using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerInsertFactory
    {

        public ISQLCollectionNonTriggerInsert Create(IQueryLanguage queryLanguage, ICommandProvider commandProvide)
        {
            ISQLCollectionNonTriggerInsert sqlCollectionNonTriggerInsert = new SQLCollectionNonTriggerInsert(queryLanguage, commandProvide);

            sqlCollectionNonTriggerInsert = new TimerFactory().Create<ISQLCollectionNonTriggerInsert>(sqlCollectionNonTriggerInsert);
            
            return sqlCollectionNonTriggerInsert;
        }
    }
}
