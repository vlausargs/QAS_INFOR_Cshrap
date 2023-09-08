using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionLoadWithMGIntercept : ICollectionLoad
    {
        readonly ICollectionLoad mgLoadCollection;
        readonly ICollectionLoad sqlLoadCollection;
        readonly IInterceptConfiguration interceptConfiguration;

        public SQLCollectionLoadWithMGIntercept(ICollectionLoad mgLoadCollection, ICollectionLoad sqlLoadCollection, IInterceptConfiguration interceptConfiguration)
        {
            this.mgLoadCollection = mgLoadCollection ?? throw new ArgumentNullException(nameof(mgLoadCollection));
            this.sqlLoadCollection = sqlLoadCollection ?? throw new ArgumentNullException(nameof(sqlLoadCollection));
            this.interceptConfiguration = interceptConfiguration ?? throw new ArgumentNullException(nameof(interceptConfiguration));
        }

        public ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest)
        {
            //this should have been caught when the load request was created
            Contract.Requires<ArgumentException>(loadRequest.CanIDO || loadRequest.CanSQL, "Internal Error: the load request can't be used for SQL or IDO");

            if (loadRequest.CanIDO && !loadRequest.CanSQL)
                //mongoose is the only option
                return mgLoadCollection.Load(loadRequest);

            if (loadRequest.CanIDO && interceptConfiguration.InterceptEnabled(loadRequest.IDOName))
                //there's an intercept in place
                return mgLoadCollection.Load(loadRequest);

            //go directly to SQL
            return sqlLoadCollection.Load(loadRequest);
        }
    }
}
