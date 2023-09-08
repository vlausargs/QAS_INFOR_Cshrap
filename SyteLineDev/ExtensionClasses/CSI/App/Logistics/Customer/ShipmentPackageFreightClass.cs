using CSI.Admin;
using CSI.CRUD.Logistics.Customer;
using CSI.Data;
using CSI.Data.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public class ShipmentPackageFreightClass : IShipmentPackageFreightClass
    {
        IShipmentPackageFreightClassCRUD shipmentPackageFreightClassCRUD;
        IIsAddonAvailable iIsAddonAvailable;
        IIsFeatureActive iIsFeatureActive;

        public ShipmentPackageFreightClass(IShipmentPackageFreightClassCRUD shipmentPackageFreightClassCRUD, IIsAddonAvailable iIsAddonAvailable, IIsFeatureActive iIsFeatureActive)
        {
            this.shipmentPackageFreightClassCRUD = shipmentPackageFreightClassCRUD;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.iIsFeatureActive = iIsFeatureActive;
        }

        public (int Severity, string InfoBar) Process(decimal? ShipmentId, int? PackageId, string FreightClass)
        {
            int Severity = 0;
            string InfoBar = "";
            try
            {
                var ValidateFeature = this.ValidateFeature();
                if (ValidateFeature.Severity != 0)
                {
                    Severity = ValidateFeature.Severity.Value;
                    InfoBar = ValidateFeature.InfoBar;
                    return (Severity, InfoBar);
                }

                if (ValidateFeature.TransportationManagementOn == 1)
                {
                    if (FreightClass == String.Empty)
                    {
                        return (Severity, InfoBar);
                    }
                    shipmentPackageFreightClassCRUD.UpdateFreightClass(ShipmentId, PackageId, FreightClass);
                    
                }
            }
            catch (Exception e)
            {
                Severity = 16;
                InfoBar = e.Message;
            }

            return (Severity, InfoBar);
        }

        private (int? Severity, string InfoBar, int? TransportationManagementOn) ValidateFeature()
        {
            string ProductNameRS9222_3 = "CSI";
            string FeatureIDRS9222_3 = "RS9222_3";
            int? FeatureRS9222_3Active = null;
            int? TransportationManagementOn = null;
            int? Severity = 0;
            string InfoBar = "";
            int? TransportationManagement = 0;
            var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
                ProductName: ProductNameRS9222_3,
                FeatureID: FeatureIDRS9222_3,
                FeatureActive: FeatureRS9222_3Active,
                InfoBar: InfoBar);
            Severity = IsFeatureActive.ReturnCode;
            FeatureRS9222_3Active = IsFeatureActive.FeatureActive;
            InfoBar = IsFeatureActive.InfoBar;
            TransportationManagement = this.iIsAddonAvailable.IsAddonAvailableFn("TransportationManagement");
            if (FeatureRS9222_3Active == 1 && this.iIsAddonAvailable.IsAddonAvailableFn("TransportationManagement") == 1)
            {
                TransportationManagementOn = 1;
            }
            return (Severity, InfoBar, TransportationManagementOn);
        }
    }
}
