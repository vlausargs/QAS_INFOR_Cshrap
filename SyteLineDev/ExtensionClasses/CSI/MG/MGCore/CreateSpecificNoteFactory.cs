//PROJECT NAME: MG.MGCore
//CLASS NAME: CreateSpecificNoteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CreateSpecificNoteFactory : ICreateSpecificNoteFactory
    {
        public ICreateSpecificNote Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CreateSpecificNote = new CreateSpecificNote(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCreateSpecificNoteExt = timerfactory.Create<MG.MGCore.ICreateSpecificNote>(_CreateSpecificNote);

            return iCreateSpecificNoteExt;
        }
    }
}
