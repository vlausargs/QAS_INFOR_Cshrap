//PROJECT NAME: CSIMaterial
//CLASS NAME: ChkTempMessageBufferFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ChkTempMessageBufferFactory
    {
        public IChkTempMessageBuffer Create(IApplicationDB appDB)
        {
            var _ChkTempMessageBuffer = new ChkTempMessageBuffer(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChkTempMessageBufferExt = timerfactory.Create<IChkTempMessageBuffer>(_ChkTempMessageBuffer);

            return iChkTempMessageBufferExt;
        }
    }
}
