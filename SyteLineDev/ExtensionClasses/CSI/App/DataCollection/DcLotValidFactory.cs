//PROJECT NAME: CSIDataCollection
//CLASS NAME: DCLotValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
	public class DCLotValidFactory
	{
		public IDCLotValid Create(IApplicationDB appDB)
		{
			var _DCLotValid = new DataCollection.DCLotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDCLotValidExt = timerfactory.Create<DataCollection.IDCLotValid>(_DCLotValid);
			
			return iDCLotValidExt;
		}
	}
}
