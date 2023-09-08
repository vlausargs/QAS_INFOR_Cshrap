using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionDelete
    {
        /// <summary>
        /// Perform a data deletion.
        /// </summary>
        /// <param name="deleteRequest">The requested data deletion.</param>
        void Delete(ICollectionDeleteRequest deleteRequest);
    }
}
