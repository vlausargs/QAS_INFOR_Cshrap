//PROJECT NAME: CSICodes
//CLASS NAME: EurDom3Factory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class EurDom3Factory
    {
        public IEurDom3 Create(IApplicationDB appDB)
        {
            var _EurDom3 = new EurDom3(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEurDom3Ext = timerfactory.Create<IEurDom3>(_EurDom3);

            return iEurDom3Ext;
        }
    }
}
