//PROJECT NAME: CSICodes
//CLASS NAME: LoadValueResFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class LoadValueResFactory
    {
        public ILoadValueRes Create(IApplicationDB appDB)
        {
            var _LoadValueRes = new LoadValueRes(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iLoadValueResExt = timerfactory.Create<ILoadValueRes>(_LoadValueRes);

            return iLoadValueResExt;
        }
    }
}
