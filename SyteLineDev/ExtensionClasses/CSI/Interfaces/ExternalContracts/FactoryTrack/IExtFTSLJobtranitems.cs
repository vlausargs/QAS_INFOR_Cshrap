
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobtranitems
    {

        int SaveJobtranitemSp(decimal? TransNum,
                string Item,
                decimal? QtyComplete,
                decimal? QtyMoved,
                decimal? QtyScrapped,
                string Reason,
                int? NextOper,
                string Loc,
                string Lot); 

        int SWcmachISp(string PWorkCenter,
                decimal? PTotalHours,
                int? PStartTime,
                int? PEndTime,
                string PShift,
                DateTime? PTransDate,
                string PEmpNum,
                string PUserID,
                Guid? SessionID,
                ref byte? TCoby,
                ref decimal? JobtranTransNum,
                ref string Infobar); 

    }
}
    
