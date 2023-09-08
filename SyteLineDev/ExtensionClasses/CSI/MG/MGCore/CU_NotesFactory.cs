//PROJECT NAME: MG.MGCore
//CLASS NAME: CU_NotesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CU_NotesFactory : ICU_NotesFactory
    {
        public ICU_Notes Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CU_Notes = new CU_Notes(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCU_NotesExt = timerfactory.Create<MG.MGCore.ICU_Notes>(_CU_Notes);

            return iCU_NotesExt;
        }
    }
}
