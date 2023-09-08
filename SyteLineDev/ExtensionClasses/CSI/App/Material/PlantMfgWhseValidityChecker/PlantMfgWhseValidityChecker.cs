using CSI.Data.SQL.UDDT;
using System;
using CSI.MG;
using CSI.CRUD.Material.PlantMfgWhseValidityChecker;
using CSI.Data;

namespace CSI.Material.PlantMfgWhseValidityChecker
{
    public interface IPlantMfgWhseValidityChecker
    {
        PlantType plant { get; }
        (int Severity, string Infobar) ValidateMfgWhseChange(string mfgwhse, string pinfobar);
    }

    public class PlantMfgWhseValidityChecker : IPlantMfgWhseValidityChecker
    {
        public IMsgApp msgApp { get; private set; }
        public IPlantMfgWhseValidityCheckerCRUD plantMfgWhseValidityCheckerCRUD { get; private set; }
        public PlantType plant { get; private set; }
        
        public const string MfgWhseOutOfRangeMessage = "Manufacturing Warehouse parameter was passed in as blank or null.";
        public const string mEExist1 = "E=Exist1";
        public const string mEMfgWhseNoDedicatedInventory = "E=MfgWhseNoDedicatedInventory";
        public const string mEMfgWhseNoExternalWms = "E=MfgWhseNoExternalWms";
        public const string mEMfgWhseNoConsignType = "E=MfgWhseNoConsignType";
        public PlantMfgWhseValidityChecker(IMsgApp msgApp, IPlantMfgWhseValidityCheckerCRUD plantActionMfgWhseChangeCRUD, PlantType plant)
        {
            this.msgApp = msgApp ?? throw new ArgumentNullException(nameof(msgApp));
            this.plantMfgWhseValidityCheckerCRUD = plantActionMfgWhseChangeCRUD ?? throw new ArgumentNullException(nameof(plantActionMfgWhseChangeCRUD));
            this.plant = plant ?? throw new ArgumentNullException(nameof(plant));
        }

        public (int Severity,string Infobar) ValidateMfgWhseChange(string pmfgwhse, string pinfobar)
        {
            PlantType ExistingPlant = DBNull.Value;
            ListYesNoType DedicatedInventory = DBNull.Value;
            ConsignmentTypeType ConsignmentType = DBNull.Value;
            ListYesNoType ControlledByExternalWMS = DBNull.Value;
            int Severity = 0;
            
            if (String.IsNullOrEmpty(pmfgwhse))
                throw new System.ArgumentOutOfRangeException("pmfgwhse",pmfgwhse, MfgWhseOutOfRangeMessage);
            
            ExistingPlant = plantMfgWhseValidityCheckerCRUD.GetPlantByMfgWhse(pmfgwhse);
            (DedicatedInventory, ConsignmentType, ControlledByExternalWMS) = plantMfgWhseValidityCheckerCRUD.GetWhseSettings(pmfgwhse);

            //if existing plant plant is null or itself, the mfg whse is valid
            if (!ExistingPlant.IsNull && ExistingPlant.Value != plant.Value)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar,mEExist1, "@plant", "@plant.mfg_whse", pmfgwhse);
            else if (DedicatedInventory.Value == 1)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar, mEMfgWhseNoDedicatedInventory);
            else if (!ConsignmentType.IsNull && ConsignmentType.Value != "N")
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar, mEMfgWhseNoConsignType);
            else if (ControlledByExternalWMS.Value == 1)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar, mEMfgWhseNoExternalWms);

            return (Severity, pinfobar);
        }
    }
}
