//PROJECT NAME: Material
//CLASS NAME: JobtranSerialSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class JobtranSerialSaveFactory
	{
		public IJobtranSerialSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranSerialSave = new Material.JobtranSerialSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranSerialSaveExt = timerfactory.Create<Material.IJobtranSerialSave>(_JobtranSerialSave);
			
			return iJobtranSerialSaveExt;
		}
	}
}
