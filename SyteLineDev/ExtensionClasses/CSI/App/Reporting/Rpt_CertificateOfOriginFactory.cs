//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CertificateOfOriginFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CertificateOfOriginFactory
	{
		public IRpt_CertificateOfOrigin Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CertificateOfOrigin = new Reporting.Rpt_CertificateOfOrigin(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CertificateOfOriginExt = timerfactory.Create<Reporting.IRpt_CertificateOfOrigin>(_Rpt_CertificateOfOrigin);
			
			return iRpt_CertificateOfOriginExt;
		}
	}
}
