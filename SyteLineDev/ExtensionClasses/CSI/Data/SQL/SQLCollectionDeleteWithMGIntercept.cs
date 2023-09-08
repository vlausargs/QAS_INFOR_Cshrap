using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLCollectionDeleteWithMGIntercept : ICollectionDelete
    {
        readonly ICollectionDelete mgCollectionDelete;
        readonly ICollectionDelete sqlCollectionDelete;
        readonly IInterceptConfiguration interceptConfiguration;

        public SQLCollectionDeleteWithMGIntercept(ICollectionDelete mgCollectionDelete, ICollectionDelete sqlCollectionDelete, IInterceptConfiguration interceptConfiguration)
        {
            this.mgCollectionDelete = mgCollectionDelete ?? throw new ArgumentNullException(nameof(mgCollectionDelete));
            this.sqlCollectionDelete = sqlCollectionDelete ?? throw new ArgumentNullException(nameof(sqlCollectionDelete));
            this.interceptConfiguration = interceptConfiguration;
        }

        public void Delete(ICollectionDeleteRequest deleteRequest)
        {
            if (deleteRequest.CanIDO && !deleteRequest.CanSQL)
            {
                //mongoose is the only option
                mgCollectionDelete.Delete(deleteRequest);
                return;
            }

            if (deleteRequest.CanIDO && interceptConfiguration.InterceptEnabled(deleteRequest.IDOName))
            {
                //there's an intercept in place
                mgCollectionDelete.Delete(deleteRequest);
                return;
            }

            //go directly to SQL
            sqlCollectionDelete.Delete(deleteRequest);
        }

    }
}
