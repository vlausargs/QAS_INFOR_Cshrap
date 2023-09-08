//PROJECT NAME: CSIEmployee
//CLASS NAME: GetNextJobDetailFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetNextJobDetailFactory
    {
        public IGetNextJobDetail Create(IApplicationDB appDB)
        {
            var _GetNextJobDetail = new GetNextJobDetail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetNextJobDetailExt = timerfactory.Create<IGetNextJobDetail>(_GetNextJobDetail);

            return iGetNextJobDetailExt;
        }
    }
}
