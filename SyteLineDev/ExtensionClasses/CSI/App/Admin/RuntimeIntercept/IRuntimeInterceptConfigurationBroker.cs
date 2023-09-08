using CSI.Data;
using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Admin.RuntimeIntercept
{
    public interface IRuntimeInterceptConfigurationBroker
    {
        IList<IRuntimeInterceptRecord> LoadAll();

        string GenerateMetadata(ICollectionLoadResponse rti);
    }
}
