using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.App.Reporting.Rpt_JobBOM
{
    public class Rpt_JobBOMChangeValueForUbVisibleAndUbFlag : IRpt_JobBOMChangeValueForUbVisibleAndUbFlag
    {
        public ICollectionLoadResponse ChangeValueForUbVisibleAndUbFlag(
            ICollectionLoadResponse tv_tempOutputLoadResponse,
            string sortBy,
            string pageJob3
            )
        {
            string sourcePropertyName = string.Empty;
            sourcePropertyName = sortBy == "J" ? "col2job" : "col1item";

            for (int i = 0; i < tv_tempOutputLoadResponse.Items.Count; i++)
            {
                if (i > 0 && tv_tempOutputLoadResponse.Items[i].GetValue<string>(sourcePropertyName) !=
                tv_tempOutputLoadResponse.Items[i - 1].GetValue<string>(sourcePropertyName))
                {
                    tv_tempOutputLoadResponse.Items[i].SetValue<string>("UbVisible", pageJob3 == "S" ? "1" : "0");
                    tv_tempOutputLoadResponse.Items[i].SetValue<string>("UbFlag", pageJob3 == "P" ? "1" : "0");
                }
            }
            return tv_tempOutputLoadResponse;
        }
    }
}
