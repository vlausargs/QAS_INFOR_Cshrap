//PROJECT NAME: CSICustomer
//CLASS NAME: ArParmsInfoFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArParmsInfoFactory
    {
        public IArParmsInfo Create(IApplicationDB appDB)
        {
            var _ArParmsInfo = new ArParmsInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArParmsInfoExt = timerfactory.Create<IArParmsInfo>(_ArParmsInfo);

            return iArParmsInfoExt;
        }
    }
}
