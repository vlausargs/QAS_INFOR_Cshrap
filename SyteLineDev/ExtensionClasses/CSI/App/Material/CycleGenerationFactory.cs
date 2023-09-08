//PROJECT NAME: CSIMaterial
//CLASS NAME: CycleGenerationFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CycleGenerationFactory
    {
        public ICycleGeneration Create(IApplicationDB appDB)
        {
            var _CycleGeneration = new CycleGeneration(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCycleGenerationExt = timerfactory.Create<ICycleGeneration>(_CycleGeneration);

            return iCycleGenerationExt;
        }
    }
}
