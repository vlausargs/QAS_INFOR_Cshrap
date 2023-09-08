
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLContainers
    {

        int ContainerAddSp(ref string ContainerNum,
                string Whse,
                string Loc,
                ref string Infobar); 

        int ContainerDeleteSp(string PContainerNum,
                ref string Infobar); 

        int GetNextContainerNumSp(ref string ContainerNum,
                string Whse,
                string Loc,
                ref string Infobar); 

        int ValidateQtyForRcvIntoContainerSp(string PItem,
                string PWhse,
                string PLoc,
                string PLot,
                [Optional] string PSite,
                ref string Infobar); 

    }
}
    
