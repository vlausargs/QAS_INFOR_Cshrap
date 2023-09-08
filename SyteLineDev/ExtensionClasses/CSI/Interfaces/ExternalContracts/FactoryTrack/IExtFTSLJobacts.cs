
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobacts
    {

        int CreateJobCompEsigSp(string UserName,
                string ReasonCode,
                string Job,
                string Suffix,
                string Item,
                string OperNum,
                string Qty,
                string Loc,
                [Optional] string ContainerNum,
                string Lot,
                string Project,
                ref Guid? EsigRowpointer); 

    }
}
    
