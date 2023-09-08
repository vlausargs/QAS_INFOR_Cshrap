//PROJECT NAME: CSIEmployee
//CLASS NAME: VerifyHrTypeFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class VerifyHrTypeFactory
    {
        public IVerifyHrType Create(IApplicationDB appDB)
        {
            var _VerifyHrType = new VerifyHrType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iVerifyHrTypeExt = timerfactory.Create<IVerifyHrType>(_VerifyHrType);

            return iVerifyHrTypeExt;
        }
    }
}
