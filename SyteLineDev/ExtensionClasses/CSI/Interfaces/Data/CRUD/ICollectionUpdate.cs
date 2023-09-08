using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionUpdate
    {
        /// <summary>
        /// Perform a data change.
        /// </summary>
        /// <param name="updateRequest">The requested data change.</param>
        void Update(ICollectionUpdateRequest updateRequest);

    }
}
