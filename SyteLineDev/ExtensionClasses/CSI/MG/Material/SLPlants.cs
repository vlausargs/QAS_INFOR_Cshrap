using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material.PlantMfgWhseValidityChecker;
using CSI.Material.PlantNoAssociationCheck;
using CSI.Data;
using CSI.Data.RecordSets;
using CSI.Material;
using CSI.Data.SQL;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLPlants")]
    public class SLPlants : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PlantValidateMfgWhseChange(string plant,
                                          string mfgwhse,
                                          ref string infobar)
                                          
        {
            int severity;

            using (var MGAppDB = this.CreateAppDB())
            {
                var appDB = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                var mgCommandProvider = new MGCommandProvider(MGAppDB);
                var mgParameterProvider = new SQLParameterProvider();
                var PlantActionMfgWhseExt = new PlantMfgWhseValidityCheckerFactory().Create(appDB, mgInvoker, mgParameterProvider, plant);

                (severity, infobar) = PlantActionMfgWhseExt.ValidateMfgWhseChange(mfgwhse, infobar);

                return severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PlantValidateNoPlantAssocations(string plant,
                                                byte? validatewhsecount,
                                                ref string infobar)
        {
            int severity;
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDB = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                var mgCommandProvider = new MGCommandProvider(MGAppDB);
                var mgParameterProvider = new SQLParameterProvider();
                var plantNoAssociationCheck = new PlantNoAssociationCheckFactory().Create(appDB, mgInvoker, mgParameterProvider, plant);

                (severity, infobar) = plantNoAssociationCheck.ValidateNoPlantAssocations(validatewhsecount,infobar);
                return severity;
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RenamePlantSp(string OldPlantName,
		string NewPlantName,
		ref string Infobar)
		{
			var iRenamePlantExt = new RenamePlantFactory().Create(this, true);
			
			var result = iRenamePlantExt.RenamePlantSp(OldPlantName,
			NewPlantName,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
    }
}
