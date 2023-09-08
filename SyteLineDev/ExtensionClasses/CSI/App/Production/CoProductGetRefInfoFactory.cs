//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductGetRefInfoFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CoProductGetRefInfoFactory
    {
        public ICoProductGetRefInfo Create(IApplicationDB appDB)
        {
            var _CoProductGetRefInfo = new CoProductGetRefInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoProductGetRefInfoExt = timerfactory.Create<ICoProductGetRefInfo>(_CoProductGetRefInfo);

            return iCoProductGetRefInfoExt;
        }
    }
}
