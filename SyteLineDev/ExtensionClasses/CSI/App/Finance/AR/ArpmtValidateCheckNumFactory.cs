//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtValidateCheckNumFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtValidateCheckNumFactory
    {
        public IArpmtValidateCheckNum Create(IApplicationDB appDB)
        {
            var _ArpmtValidateCheckNum = new ArpmtValidateCheckNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtValidateCheckNumExt = timerfactory.Create<IArpmtValidateCheckNum>(_ArpmtValidateCheckNum);

            return iArpmtValidateCheckNumExt;
        }
    }
}
