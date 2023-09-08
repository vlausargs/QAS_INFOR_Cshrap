//PROJECT NAME: Admin
//CLASS NAME: DocumentObjectsPostQueryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class DocumentObjectsPostQueryFactory
	{
		public IDocumentObjectsPostQuery Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DocumentObjectsPostQuery = new Admin.DocumentObjectsPostQuery(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDocumentObjectsPostQueryExt = timerfactory.Create<Admin.IDocumentObjectsPostQuery>(_DocumentObjectsPostQuery);
			
			return iDocumentObjectsPostQueryExt;
		}
	}
}
