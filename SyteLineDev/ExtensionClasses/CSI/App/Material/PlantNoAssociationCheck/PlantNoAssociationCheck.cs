using CSI.Data.SQL.UDDT;
using System;
using CSI.MG;
using CSI.CRUD.Material.PlantNoAssociationCheck;
using CSI.Data;

namespace CSI.Material.PlantNoAssociationCheck
{
    public interface IPlantNoAssociationCheck
    {
        PlantType plant { get; }
        (int Severity, string Infobar) ValidateNoPlantAssocations(byte? validatewhsecount, string pinfobar);
    }

    public class PlantNoAssociationCheck : IPlantNoAssociationCheck
    {
        public IMsgApp msgApp { get; private set; }
        public IPlantNoAssocationCheckCRUD plantNoAssocationCheckCRUD;
        public  PlantType plant { get; private set; }

        public const string PlantOutOfRangeMessage = "Plant parameter was passed in as blank or null.";
        public const string mEExistsFor = "E=ExistFor=";

        public PlantNoAssociationCheck(
               IMsgApp msgApp,
               IPlantNoAssocationCheckCRUD plantNoAssociationCheckCRUD,
               PlantType plant)
        {
            this.msgApp = msgApp ?? throw new ArgumentNullException(nameof(msgApp));
            this.plantNoAssocationCheckCRUD = plantNoAssociationCheckCRUD ?? throw new ArgumentNullException(nameof(plantNoAssociationCheckCRUD));
            this.plant = plant ?? throw new ArgumentNullException(nameof(plant));
        }

       

        public (int Severity,string Infobar) ValidateNoPlantAssocations(byte? pvalidatewhsecount, string pinfobar)
        {
            WhseType MfgWhse = "";
            IntType WhseCount = 0;
            IntType WCCount = 0;
            IntType RGRPCount = 0;
            IntType RESRCCount = 0;
            int Severity = 0;
            
            (MfgWhse, WhseCount, WCCount, RGRPCount, RESRCCount) = plantNoAssocationCheckCRUD.GetPlantAssociationCounts(plant);

            if (pvalidatewhsecount > 0 && WhseCount > 0)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar,mEExistsFor, "@whse", "@plant.plant", plant);
            else if (WCCount.Value > 0)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar,mEExistsFor, "@wc", "@plant.plant", plant);
            else if (RGRPCount.Value > 0)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar, mEExistsFor, "@rgrp", "@plant.plant", plant);
            else if (RESRCCount.Value > 0)
                (Severity, pinfobar) = msgApp.MsgAppSp(pinfobar, mEExistsFor, "@resrc", "@plant.plant", plant);

            return (Severity, pinfobar);
        }
    }
}
