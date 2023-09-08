//PROJECT NAME: Data
//CLASS NAME: CurrPerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CurrPerFactory
	{
		public ICurrPer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrPer = new CurrPer(appDB);


			return _CurrPer;
		}
	}
}
