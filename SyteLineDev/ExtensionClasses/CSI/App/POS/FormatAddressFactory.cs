//PROJECT NAME: POS
//CLASS NAME: FormatAddressFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.POS
{
	public class FormatAddressFactory
	{
		public IFormatAddress Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FormatAddress = new POS.FormatAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormatAddressExt = timerfactory.Create<POS.IFormatAddress>(_FormatAddress);
			
			return iFormatAddressExt;
		}

		public IFormatAddress Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _FormatAddress = new FormatAddress(appDB);

			return _FormatAddress;
		}
	}
}
