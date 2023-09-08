
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLProjLabrs
    {

        int ProjLabrEmpNumValidSp(string EmpNum,
                ref string EmpName,
                ref string Shift,
                ref decimal? TotalAHours,
                ref string Infobar,
                ref string PromptMessage,
                ref string PromptButtons); 

        int ProjLabrInitialRateSp(string EmpNum,
                string PayType,
                string Shift,
                DateTime? TransDate,
                ref decimal? PrRate,
                ref decimal? ProjRate,
                ref string Infobar); 

    }
}
    
