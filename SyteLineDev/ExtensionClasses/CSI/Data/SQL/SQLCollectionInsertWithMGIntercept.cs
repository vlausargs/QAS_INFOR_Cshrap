using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionInsertWithMGIntercept : ICollectionInsert
    {
        readonly ICollectionInsert mgCollectionInsert;
        readonly ICollectionInsert sqlCollectionInsert;
        readonly IInterceptConfiguration interceptConfiguration;

        public SQLCollectionInsertWithMGIntercept(ICollectionInsert mgCollectionInsert, ICollectionInsert sqlCollectionInsert, IInterceptConfiguration interceptConfiguration)
        {
            this.mgCollectionInsert = mgCollectionInsert ?? throw new ArgumentNullException(nameof(mgCollectionInsert));
            this.sqlCollectionInsert = sqlCollectionInsert ?? throw new ArgumentNullException(nameof(sqlCollectionInsert));
            this.interceptConfiguration = interceptConfiguration;
        }

        public void Insert(ICollectionInsertRequest insertRequest)
        {
            if (insertRequest.CanIDO && !insertRequest.CanSQL)
            {
                //mongoose is the only option
                mgCollectionInsert.Insert(insertRequest);
                return;
            }

            if (insertRequest.CanIDO && interceptConfiguration.InterceptEnabled(insertRequest.IDOName))
            {
                //there's an intercept in place
                mgCollectionInsert.Insert(insertRequest);
                return;
            }

            //go directly to SQL
            sqlCollectionInsert.Insert(insertRequest);
        }
    }
}
