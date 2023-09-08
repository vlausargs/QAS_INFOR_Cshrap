using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.MG
{
    public interface IMGLoadCollectionResponseData
    {
        DataTable GetReturnValueDataTable();
        ICollectionLoadResponse GetLoadCollectionResponseData();
        //IMGInvokeParameterList Parameters { get; set; }
        //bool IsReturnValueStdError();
    }
}
