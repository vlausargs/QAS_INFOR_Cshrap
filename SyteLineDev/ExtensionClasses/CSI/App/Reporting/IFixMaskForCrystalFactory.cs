using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Reporting
{
    public interface IFixMaskForCrystalFactory
    {
        IFixMaskForCrystal Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}