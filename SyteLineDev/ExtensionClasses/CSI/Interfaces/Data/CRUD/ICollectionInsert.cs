using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionInsert
    {
        /// <summary>
        /// Perform a data insertion.
        /// </summary>
        /// <param name="insertRequest">The requested data insertion.</param>
        void Insert(ICollectionInsertRequest insertRequest);
    }
}
