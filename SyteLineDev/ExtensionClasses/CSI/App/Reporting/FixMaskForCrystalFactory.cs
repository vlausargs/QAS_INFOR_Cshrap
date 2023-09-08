//PROJECT NAME: Reporting
//CLASS NAME: FixMaskForCrystalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Reporting
{
    public class FixMaskForCrystalFactory : IFixMaskForCrystalFactory
    {
        public IFixMaskForCrystal Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _FixMaskForCrystal = new Reporting.FixMaskForCrystal(appDB);


            return _FixMaskForCrystal;
        }
        public IFixMaskForCrystal Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _FixMaskForCrystal = new FixMaskForCrystal(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iFixMaskForCrystalExt = timerfactory.Create<IFixMaskForCrystal>(_FixMaskForCrystal);

            return iFixMaskForCrystalExt;
        }
    }
}
