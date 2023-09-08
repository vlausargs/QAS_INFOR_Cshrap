//PROJECT NAME: CSIMaterial
//CLASS NAME: TH_StockBalanceCons_InitDataFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TH_StockBalanceCons_InitDataFactory
    {
        public ITH_StockBalanceCons_InitData Create(IApplicationDB appDB)
        {
            var _TH_StockBalanceCons_InitData = new TH_StockBalanceCons_InitData(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTH_StockBalanceCons_InitDataExt = timerfactory.Create<ITH_StockBalanceCons_InitData>(_TH_StockBalanceCons_InitData);

            return iTH_StockBalanceCons_InitDataExt;
        }
    }
}
