//PROJECT NAME: CSIMaterial
//CLASS NAME: FbomVFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class FbomVFactory
    {
        public IFbomV Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _FbomV = new FbomV(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFbomVExt = timerfactory.Create<IFbomV>(_FbomV);

            return iFbomVExt;
        }
    }
}
