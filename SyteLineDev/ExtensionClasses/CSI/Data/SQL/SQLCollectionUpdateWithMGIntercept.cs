using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionUpdateWithMGIntercept : ICollectionUpdate
    {
        readonly ICollectionUpdate mgCollectionUpdater;
        readonly ICollectionUpdate sqlCollectionUpdater;
        readonly IInterceptConfiguration interceptConfiguration;

        public SQLCollectionUpdateWithMGIntercept(ICollectionUpdate mgCollectionUpdater, ICollectionUpdate sqlCollectionUpdater, IInterceptConfiguration interceptConfiguration)
        {
            this.mgCollectionUpdater = mgCollectionUpdater;
            this.sqlCollectionUpdater = sqlCollectionUpdater;
            this.interceptConfiguration = interceptConfiguration;
        }

        public void Update(ICollectionUpdateRequest updateRequest)
        {
            //this should have been caught when the request was created
            Contract.Requires<ArgumentException>(updateRequest.CanIDO || updateRequest.CanSQL, "Internal Error: the update request can't be used for SQL or IDO");

            if (updateRequest.CanIDO && !updateRequest.CanSQL)
            {
                //mongoose is the only option
                mgCollectionUpdater.Update(updateRequest);
                return;
            }

            if (updateRequest.CanIDO && interceptConfiguration.InterceptEnabled(updateRequest.IDOName))
            {
                //there's an intercept in place
                mgCollectionUpdater.Update(updateRequest);
                return;
            }

            //go directly to SQL
            sqlCollectionUpdater.Update(updateRequest);
        }

    }
}
