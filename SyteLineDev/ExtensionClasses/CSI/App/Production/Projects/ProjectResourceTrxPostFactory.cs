//PROJECT NAME: Production
//CLASS NAME: ProjectResourceTrxPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjectResourceTrxPostFactory
	{
		public IProjectResourceTrxPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjectResourceTrxPost = new Production.Projects.ProjectResourceTrxPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjectResourceTrxPostExt = timerfactory.Create<Production.Projects.IProjectResourceTrxPost>(_ProjectResourceTrxPost);
			
			return iProjectResourceTrxPostExt;
		}
	}
}
