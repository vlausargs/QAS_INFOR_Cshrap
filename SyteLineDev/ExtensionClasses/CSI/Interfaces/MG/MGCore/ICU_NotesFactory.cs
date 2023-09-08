using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICU_NotesFactory
    {
        ICU_Notes Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}