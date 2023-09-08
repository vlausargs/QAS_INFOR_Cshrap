//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcJobValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcJobValidFactory
	{
		public IDcsfcJobValid Create(IApplicationDB appDB)
		{
			var _DcsfcJobValid = new DataCollection.DcsfcJobValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcJobValidExt = timerfactory.Create<DataCollection.IDcsfcJobValid>(_DcsfcJobValid);
			
			return iDcsfcJobValidExt;
		}
	}
}
