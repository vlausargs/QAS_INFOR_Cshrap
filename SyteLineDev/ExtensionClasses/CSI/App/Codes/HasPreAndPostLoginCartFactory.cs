//PROJECT NAME: CSICodes
//CLASS NAME: HasPreAndPostLoginCartFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class HasPreAndPostLoginCartFactory
	{
		public IHasPreAndPostLoginCart Create(IApplicationDB appDB)
		{
			var _HasPreAndPostLoginCart = new Codes.HasPreAndPostLoginCart(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHasPreAndPostLoginCartExt = timerfactory.Create<Codes.IHasPreAndPostLoginCart>(_HasPreAndPostLoginCart);
			
			return iHasPreAndPostLoginCartExt;
		}
	}
}
