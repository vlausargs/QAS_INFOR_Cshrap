//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcmatlDFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmatlDFactory
	{
		public IDcmatlD Create(IApplicationDB appDB)
		{
			var _DcmatlD = new DataCollection.DcmatlD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmatlDExt = timerfactory.Create<DataCollection.IDcmatlD>(_DcmatlD);
			
			return iDcmatlDExt;
		}
	}
}
