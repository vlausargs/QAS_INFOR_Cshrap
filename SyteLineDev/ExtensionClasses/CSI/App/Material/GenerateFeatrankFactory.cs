//PROJECT NAME: CSIMaterial
//CLASS NAME: GenerateFeatrankFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GenerateFeatrankFactory
    {
        public IGenerateFeatrank Create(IApplicationDB appDB)
        {
            var _GenerateFeatrank = new GenerateFeatrank(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenerateFeatrankExt = timerfactory.Create<IGenerateFeatrank>(_GenerateFeatrank);

            return iGenerateFeatrankExt;
        }
    }
}
