//PROJECT NAME: NonTrans
//CLASS NAME: ShrinkDatabaseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.NonTrans
{
	public class ShrinkDatabaseFactory
	{
		public IShrinkDatabase Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ShrinkDatabase = new NonTrans.ShrinkDatabase(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShrinkDatabaseExt = timerfactory.Create<NonTrans.IShrinkDatabase>(_ShrinkDatabase);
			
			return iShrinkDatabaseExt;
		}
	}
}
