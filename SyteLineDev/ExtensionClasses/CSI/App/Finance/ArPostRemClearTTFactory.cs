//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemClearTTFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ArPostRemClearTTFactory
	{
		public IArPostRemClearTT Create(IApplicationDB appDB)
		{
			var _ArPostRemClearTT = new Finance.ArPostRemClearTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArPostRemClearTTExt = timerfactory.Create<Finance.IArPostRemClearTT>(_ArPostRemClearTT);
			
			return iArPostRemClearTTExt;
		}
	}
}
