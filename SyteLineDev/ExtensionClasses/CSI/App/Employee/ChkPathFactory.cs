//PROJECT NAME: CSIEmployee
//CLASS NAME: ChkPathFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ChkPathFactory
    {
        public IChkPath Create(IApplicationDB appDB)
        {
            var _ChkPath = new ChkPath(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChkPathExt = timerfactory.Create<IChkPath>(_ChkPath);

            return iChkPathExt;
        }
    }
}
