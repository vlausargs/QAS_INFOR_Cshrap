using CSI.Data;
using CSI.Data.SQL;
using CSI.MG;
using System.Diagnostics.CodeAnalysis;
using CSI.CRUD.Material.PlantMfgWhseValidityChecker;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material.PlantMfgWhseValidityChecker
{
    public class PlantMfgWhseValidityCheckerFactory
    {
        public const string IDO = "SLPlants";
        public const string Method = "PlantValidateMfgWhseChange";

        public IPlantMfgWhseValidityChecker Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, PlantType plant)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var msgApp = new MsgApp(appDB);
            IPlantMfgWhseValidityCheckerCRUD plantMfgWhseValidityCheckerCRUD = new PlantMfgWhseValidityCheckerCRUD(new CollectionLoadRequestFactory(queryLanguage), appDB);
            IPlantMfgWhseValidityChecker plantMfgWhseValidityChecker = new PlantMfgWhseValidityChecker(msgApp, plantMfgWhseValidityCheckerCRUD, plant);

            
            var interceptConfiguration = new InterceptConfiguration();
            plantMfgWhseValidityChecker = IDOMethodIntercept<IPlantMfgWhseValidityChecker>.Create(plantMfgWhseValidityChecker, IDO, Method, mgInvoker, interceptConfiguration);


            var timerFactory = new CSI.Data.Metric.TimerFactory();
            var plantActionMfgWhseChangeExt = timerFactory.Create<IPlantMfgWhseValidityChecker>(plantMfgWhseValidityChecker);

            return plantActionMfgWhseChangeExt;
        }
    }
}
