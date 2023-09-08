//PROJECT NAME: DataCollection
//CLASS NAME: DcAPhysinSerialFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPhysinSerialFactory
	{
		public IDcAPhysinSerial Create(IApplicationDB appDB)
		{
			var _DcAPhysinSerial = new DataCollection.DcAPhysinSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcAPhysinSerialExt = timerfactory.Create<DataCollection.IDcAPhysinSerial>(_DcAPhysinSerial);
			
			return iDcAPhysinSerialExt;
		}
	}
}
