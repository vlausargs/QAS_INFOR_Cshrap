//PROJECT NAME: Production
//CLASS NAME: CopyNotesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CopyNotesFactory
	{
		public ICopyNotes Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CopyNotes = new Production.CopyNotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyNotesExt = timerfactory.Create<Production.ICopyNotes>(_CopyNotes);
			
			return iCopyNotesExt;
		}
	}
}
