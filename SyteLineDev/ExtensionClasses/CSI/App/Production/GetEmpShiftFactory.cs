//PROJECT NAME: CSIProduct
//CLASS NAME: GetEmpShiftFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GetEmpShiftFactory
    {
        public IGetEmpShift Create(IApplicationDB appDB)
        {
            var _GetEmpShift = new GetEmpShift(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetEmpShiftExt = timerfactory.Create<IGetEmpShift>(_GetEmpShift);

            return iGetEmpShiftExt;
        }
    }
}
