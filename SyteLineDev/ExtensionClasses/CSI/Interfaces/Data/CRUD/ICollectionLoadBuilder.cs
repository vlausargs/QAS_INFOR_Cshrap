using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadBuilder
    {
        ICollectionLoadResponse Load(ICollectionLoadBuilderRequest loadBuildRequest);
    }
}
