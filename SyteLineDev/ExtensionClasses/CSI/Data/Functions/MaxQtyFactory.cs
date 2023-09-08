//PROJECT NAME: Data
//CLASS NAME: MaxQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class MaxQtyFactory : IMaxQtyFactory
	{
		public IMaxQty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MaxQty = new Functions.MaxQty(appDB);


			return _MaxQty;
		}

		public IMaxQty Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _MaxQty = new Functions.MaxQty(appDB);

			return _MaxQty;
		}
	}
}
