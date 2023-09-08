//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_CoProductFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class MO_Rpt_CoProductFactory
	{
		public IMO_Rpt_CoProduct Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_Rpt_CoProduct = new Reporting.MO_Rpt_CoProduct(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_Rpt_CoProductExt = timerfactory.Create<Reporting.IMO_Rpt_CoProduct>(_MO_Rpt_CoProduct);
			
			return iMO_Rpt_CoProductExt;
		}
	}
}
