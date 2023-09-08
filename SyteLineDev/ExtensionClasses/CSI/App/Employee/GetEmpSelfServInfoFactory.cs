//PROJECT NAME: CSIEmployee
//CLASS NAME: GetEmpSelfServInfoFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetEmpSelfServInfoFactory
    {
        public IGetEmpSelfServInfo Create(IApplicationDB appDB)
        {
            var _GetEmpSelfServInfo = new GetEmpSelfServInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetEmpSelfServInfoExt = timerfactory.Create<IGetEmpSelfServInfo>(_GetEmpSelfServInfo);

            return iGetEmpSelfServInfoExt;
        }
    }
}
