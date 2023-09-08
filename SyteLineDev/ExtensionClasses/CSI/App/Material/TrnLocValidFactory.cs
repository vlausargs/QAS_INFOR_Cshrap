//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnLocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnLocValidFactory
    {
        public ITrnLocValid Create(IApplicationDB appDB)
        {
            var _TrnLocValid = new TrnLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnLocValidExt = timerfactory.Create<ITrnLocValid>(_TrnLocValid);

            return iTrnLocValidExt;
        }
    }
}
