//PROJECT NAME: CSIFinance
//CLASS NAME: DFaDispFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class DFaDispFactory
    {
        public IDFaDisp Create(IApplicationDB appDB)
        {
            var _DFaDisp = new DFaDisp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDispsExt = timerfactory.Create<IDFaDisp>(_DFaDisp);

            return iSLFaDispsExt;
        }
    }
}
