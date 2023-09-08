//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtValidateTypeFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtValidateTypeFactory
    {
        public IArpmtValidateType Create(IApplicationDB appDB)
        {
            var _ArpmtValidateType = new ArpmtValidateType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtValidateTypeExt = timerfactory.Create<IArpmtValidateType>(_ArpmtValidateType);

            return iArpmtValidateTypeExt;
        }
    }
}
