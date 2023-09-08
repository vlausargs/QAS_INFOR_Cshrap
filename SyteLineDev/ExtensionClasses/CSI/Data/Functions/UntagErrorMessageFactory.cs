using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Data
{
    public class UntagErrorMessageFactory : IUntagErrorMessageFactory
    {
        public IUntagErrorMessage Create(IApplicationDB appDB)
        {
            StringUtil stringUtil = new StringUtil();

            return new UntagErrorMessage(appDB, stringUtil);
        }
    }
}
