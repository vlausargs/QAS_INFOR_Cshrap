using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoad
    {
        /// <summary>
        /// Perform a data load.
        /// </summary>
        /// <param name="updateRequest">The requested data load.</param>
        ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest);
    }
}
