using CSI.Data.Metric;
using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerUpdateFactory
    {

        public ISQLCollectionNonTriggerUpdate Create(IQueryLanguage queryLanguage, ICommandProvider commandProvide)
        {
            ISQLCollectionNonTriggerUpdate sqlCollectionNonTriggerUpdate = new SQLCollectionNonTriggerUpdate(queryLanguage, commandProvide);
                
            sqlCollectionNonTriggerUpdate = new TimerFactory().Create<ISQLCollectionNonTriggerUpdate>(sqlCollectionNonTriggerUpdate);
            
            return sqlCollectionNonTriggerUpdate;
        }
    }
}
