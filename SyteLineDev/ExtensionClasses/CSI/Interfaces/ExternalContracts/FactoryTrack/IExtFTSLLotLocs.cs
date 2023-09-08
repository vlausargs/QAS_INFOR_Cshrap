
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLLotLocs
    {

        int GetLotManufacturerSp([Optional] string Item,
                [Optional] string Lot,
                ref string LotManufacturer,
                ref string LotManufacturerName,
                ref string LotManufacturerItem,
                ref string LotManItemDescription); 

        int SetLotManufacturerSp([Optional] string Item,
                [Optional] string Lot,
                [Optional] string Manufacturer,
                [Optional] string ManufacturerItem,
                [Optional, DefaultParameterValue((byte)1)] byte? SetAllowFlag); 

    }
}
    
