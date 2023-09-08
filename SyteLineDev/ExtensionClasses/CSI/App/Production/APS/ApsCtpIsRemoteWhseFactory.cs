//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsRemoteWhseFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpIsRemoteWhseFactory
    {
        public IApsCtpIsRemoteWhse Create(IApplicationDB appDB)
        {
            var _ApsCtpIsRemoteWhse = new ApsCtpIsRemoteWhse(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpIsRemoteWhseExt = timerfactory.Create<IApsCtpIsRemoteWhse>(_ApsCtpIsRemoteWhse);

            return iApsCtpIsRemoteWhseExt;
        }
    }
}
