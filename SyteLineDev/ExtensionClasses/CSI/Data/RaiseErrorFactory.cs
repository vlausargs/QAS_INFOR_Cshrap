using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Data
{
    public class RaiseErrorFactory : IRaiseErrorFactory
    {
        public IRaiseError Create(IApplicationDB appDB)
        {
            StringUtil stringUtil = new StringUtil();
            ITagErrorMessage tagErrorMessage = new TagErrorMessage(stringUtil);
            var untagErrorMessageFactory = new UntagErrorMessageFactory().Create(appDB);

            return new RaiseError(stringUtil, tagErrorMessage, untagErrorMessageFactory);
        }
    }
}
