using CSI.Data.Metric;
using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerDeleteFactory
    {

        public ISQLCollectionNonTriggerDelete Create(IQueryLanguage queryLanguage, ICommandProvider commandProvide)
        {
            ISQLCollectionNonTriggerDelete sqlCollectionNonTriggerDelete = new SQLCollectionNonTriggerDelete(queryLanguage, commandProvide);
                
            sqlCollectionNonTriggerDelete = new TimerFactory().Create<ISQLCollectionNonTriggerDelete>(sqlCollectionNonTriggerDelete);
            
            return sqlCollectionNonTriggerDelete;
        }
    }
}
