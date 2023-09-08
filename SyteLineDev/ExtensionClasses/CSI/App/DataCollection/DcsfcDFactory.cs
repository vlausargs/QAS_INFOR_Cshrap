//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcDFactory
	{
		public IDcsfcD Create(IApplicationDB appDB)
		{
			var _DcsfcD = new DataCollection.DcsfcD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcDExt = timerfactory.Create<DataCollection.IDcsfcD>(_DcsfcD);
			
			return iDcsfcDExt;
		}
	}
}
