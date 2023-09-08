using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLDctrans
    {
        int ChkSnSp(string PSite, string PSerNum, string PItem, decimal? PQtyShip, ref string PErr, ref string Infobar, [DefaultParameterValue((byte)0)] byte? CalledFromSerialTrigger);
    }
}