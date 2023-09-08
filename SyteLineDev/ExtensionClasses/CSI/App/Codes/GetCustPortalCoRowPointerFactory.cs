//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalCoRowPointerFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetCustPortalCoRowPointerFactory
	{
		public IGetCustPortalCoRowPointer Create(IApplicationDB appDB)
		{
			var _GetCustPortalCoRowPointer = new Codes.GetCustPortalCoRowPointer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustPortalCoRowPointerExt = timerfactory.Create<Codes.IGetCustPortalCoRowPointer>(_GetCustPortalCoRowPointer);
			
			return iGetCustPortalCoRowPointerExt;
		}
	}
}
