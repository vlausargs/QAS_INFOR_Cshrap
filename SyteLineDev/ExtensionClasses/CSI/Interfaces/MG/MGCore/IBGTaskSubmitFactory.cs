using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IBGTaskSubmitFactory
    {
        IBGTaskSubmit Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}