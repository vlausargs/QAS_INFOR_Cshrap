//PROJECT NAME: CSIMaterial
//CLASS NAME: MSQtyMoveQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MSQtyMoveQtyValidFactory
	{
		public IMSQtyMoveQtyValid Create(IApplicationDB appDB)
		{
			var _MSQtyMoveQtyValid = new Material.MSQtyMoveQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMSQtyMoveQtyValidExt = timerfactory.Create<Material.IMSQtyMoveQtyValid>(_MSQtyMoveQtyValid);
			
			return iMSQtyMoveQtyValidExt;
		}
	}
}
