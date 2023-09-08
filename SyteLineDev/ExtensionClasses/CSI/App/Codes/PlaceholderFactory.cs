//PROJECT NAME: Codes
//CLASS NAME: PlaceholderFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PlaceholderFactory
	{
		public IPlaceholder Create(IApplicationDB appDB)
		{
			var _Placeholder = new Codes.Placeholder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlaceholderExt = timerfactory.Create<Codes.IPlaceholder>(_Placeholder);
			
			return iPlaceholderExt;
		}
	}
}
