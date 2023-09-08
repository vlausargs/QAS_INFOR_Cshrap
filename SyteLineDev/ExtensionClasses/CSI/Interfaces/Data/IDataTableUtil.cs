using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data
{
    public interface IDataTableUtil
    {
        void CloneDataTableIntoDB(DataTable dataTable);
    }
}
