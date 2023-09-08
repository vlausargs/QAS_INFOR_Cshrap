using System;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLCos
    {
        int GenerateGUIDSp(ref Guid? GUID);
    }
}