
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLShipmentPackages
    {

        int GenerateTmpShipSeqPackageSp(Guid? ProcessId,
                int? Select,
                decimal? ShipmentId,
                int? PackageId,
                string PackageType,
                string RateCode,
                string NMFC,
                decimal? Weight,
                int? Hazard,
                string Description,
                string Marksexcept,
                int? RefPackageId,
                string TH_CartonPrefix,
                decimal? TH_Measurement,
                string TH_CartonSize,
                ref string InfoBar); 

    }
}
    
