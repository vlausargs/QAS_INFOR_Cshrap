//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAccountUnitAccessibilityFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSAccountUnitAccessibilityFactory
    {
        public ICHSAccountUnitAccessibility Create(IApplicationDB appDB)
        {
            var _CHSAccountUnitAccessibility = new CHSAccountUnitAccessibility(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSAccountUnitAccessibilityExt = timerfactory.Create<ICHSAccountUnitAccessibility>(_CHSAccountUnitAccessibility);

            return iCHSAccountUnitAccessibilityExt;
        }
    }
}

