using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.IDM
{
    public class IDMFactory
    {
        public IIDM Create(ICSIExtensionClassBase cSIExtensionClassBase, string baseURL, string username, string password)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(cSIExtensionClassBase.ParameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);

            return new IDM(baseURL, username, password);
        }
    }
}
