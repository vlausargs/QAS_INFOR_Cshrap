using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class IsIntegerFactory : IIsIntegerFactory
	{
		public IIsInteger Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsInteger = new IsInteger();

			return _IsInteger;
		}
	}
}
