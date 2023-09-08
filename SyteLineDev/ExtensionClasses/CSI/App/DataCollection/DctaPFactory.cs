//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaPFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DctaPFactory
    {
        public IDctaP Create(IApplicationDB appDB)
        {
            var _DctaP = new DctaP(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDctaPExt = timerfactory.Create<IDctaP>(_DctaP);

            return iDctaPExt;
        }
    }
}