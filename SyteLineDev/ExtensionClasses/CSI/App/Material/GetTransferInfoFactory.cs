//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransferInfoFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetTransferInfoFactory
    {
        public IGetTransferInfo Create(IApplicationDB appDB)
        {
            var _GetTransferInfo = new GetTransferInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTransferInfoExt = timerfactory.Create<IGetTransferInfo>(_GetTransferInfo);

            return iGetTransferInfoExt;
        }
    }
}
