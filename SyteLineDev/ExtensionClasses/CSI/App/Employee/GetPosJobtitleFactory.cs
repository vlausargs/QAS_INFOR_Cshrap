//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPosJobtitleFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetPosJobtitleFactory
    {
        public IGetPosJobtitle Create(IApplicationDB appDB)
        {
            var _GetPosJobtitle = new GetPosJobtitle(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetPosJobtitleExt = timerfactory.Create<IGetPosJobtitle>(_GetPosJobtitle);

            return iGetPosJobtitleExt;
        }
    }
}
