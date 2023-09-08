//PROJECT NAME: Data
//CLASS NAME: EuroCnvtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class EuroCnvtFactory
	{
		public IEuroCnvt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EuroCnvt = new EuroCnvt(appDB);


			return _EuroCnvt;
		}
	}
}
