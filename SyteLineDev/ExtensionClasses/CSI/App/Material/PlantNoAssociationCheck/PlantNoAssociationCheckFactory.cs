using CSI.Data;
using CSI.Data.SQL;
using CSI.MG;
using System.Diagnostics.CodeAnalysis;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.CRUD.Material.PlantNoAssociationCheck;

namespace CSI.Material.PlantNoAssociationCheck
{
    [ExcludeFromCodeCoverage]
    public class PlantNoAssociationCheckFactory
    {
        public const string IDO = "SLPlants";
        public const string Method = "PlantValidateNoPlantAssocations";

        public IPlantNoAssociationCheck Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, PlantType plant)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var msgApp = new MsgApp(appDB);
            IPlantNoAssocationCheckCRUD plantNoAssocationCheckCRUD = new PlantNoAssociationCheckCRUD(new CollectionLoadRequestFactory(queryLanguage), appDB);
            IPlantNoAssociationCheck plantNoAssociationCheck = new PlantNoAssociationCheck(msgApp, plantNoAssocationCheckCRUD, plant);

            var interceptConfiguration = new InterceptConfiguration();
            plantNoAssociationCheck = IDOMethodIntercept<IPlantNoAssociationCheck>.Create(plantNoAssociationCheck, IDO, Method, mgInvoker, interceptConfiguration);


            var timerFactory = new CSI.Data.Metric.TimerFactory();
            var plantNoAssociationCheckExt = timerFactory.Create<IPlantNoAssociationCheck>(plantNoAssociationCheck);

            return plantNoAssociationCheckExt;
        }
    }
}
