using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Project
{
    public interface ISLProjTasks
    {
        int NextProjTaskSp(string ProjNum,
                           ref int? ProjTaskNum,
                           ref string Infobar);
    }
}
