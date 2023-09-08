using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.App.Reporting.Rpt_JobBOM
{
    public interface IRpt_JobBOMChangeValueForUbVisibleAndUbFlag
    {
         ICollectionLoadResponse ChangeValueForUbVisibleAndUbFlag(
            ICollectionLoadResponse tv_tempOutputLoadResponse,
            string sortBy,
            string pageJob3
            );
    }
}
