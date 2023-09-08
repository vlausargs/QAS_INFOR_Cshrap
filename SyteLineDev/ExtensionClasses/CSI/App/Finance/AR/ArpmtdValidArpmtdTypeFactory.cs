//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidArpmtdTypeFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdValidArpmtdTypeFactory
    {
        public IArpmtdValidArpmtdType Create(IApplicationDB appDB)
        {
            var _ArpmtdValidArpmtdType = new ArpmtdValidArpmtdType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdValidArpmtdTypeExt = timerfactory.Create<IArpmtdValidArpmtdType>(_ArpmtdValidArpmtdType);

            return iArpmtdValidArpmtdTypeExt;
        }
    }
}
