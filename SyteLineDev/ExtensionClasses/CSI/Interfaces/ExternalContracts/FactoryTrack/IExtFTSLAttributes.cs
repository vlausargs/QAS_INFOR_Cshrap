
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLAttributes
    {

        int InsertOverrideForAttributesSp(string ValColName,
                string Value,
                string Type,
                Guid? RefRowPointer,
                ref Guid? RowPointer,
                ref string Infobar); 

    }
}
    
