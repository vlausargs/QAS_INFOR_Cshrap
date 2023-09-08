//PROJECT NAME: DataCollection
//CLASS NAME: GetumcfFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class GetumcfFactory
	{
		public IGetumcf Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Getumcf = new DataCollection.Getumcf(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetumcfExt = timerfactory.Create<DataCollection.IGetumcf>(_Getumcf);
			
			return iGetumcfExt;
		}
        public IGetumcf Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _Getumcf = new Getumcf(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetumcfExt = timerfactory.Create<IGetumcf>(_Getumcf);

            return iGetumcfExt;
        }

        public IGetumcf Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _Getumcf = new Getumcf(appDB);


            return _Getumcf;
        }
    }
}
