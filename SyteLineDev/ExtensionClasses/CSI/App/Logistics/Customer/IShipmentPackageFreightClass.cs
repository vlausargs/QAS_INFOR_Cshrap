using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public interface IShipmentPackageFreightClass
    {
        (int Severity, string InfoBar) Process(decimal? ShipmentId, int? PackageId, string FreightClass);
        
    }
}
