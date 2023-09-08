using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadStatement
    {
        ICollectionLoadResponse Load(ICollectionLoadStatementRequest loadRequest);
    }
}
