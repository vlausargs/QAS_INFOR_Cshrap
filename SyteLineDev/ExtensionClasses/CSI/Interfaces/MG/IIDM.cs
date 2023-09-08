using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.IDM
{
    public interface IIDM
    {
        bool ConnectOAuth1(string tenantID, string iFSUID, bool connectValidate = false);
        string GetFileContent(string fileName, string documentType, string direction);
    }
}
