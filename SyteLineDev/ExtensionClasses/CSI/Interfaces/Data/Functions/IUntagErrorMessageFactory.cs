using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IUntagErrorMessageFactory
    {
        IUntagErrorMessage Create(IApplicationDB appDB);
    }
}
