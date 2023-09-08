using System;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLEsigAuthorizations
    {
        int CreateCheckSum(Guid RowPointer, string UserName, string EncryptedUserpassword, string EsigType, ref string InfoBar);
        int EncryptString(string UnEncryptedString, ref string EncryptedString, ref string InfoBar);
        int ValidateSignature(string UserName, string EncryptedUserpassword, string EsigType, ref string InfoBar);
    }
}