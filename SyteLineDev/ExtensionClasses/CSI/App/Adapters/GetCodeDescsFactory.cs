//PROJECT NAME: Adapters
//CLASS NAME: GetCodeDescsFactory.cs

using CSI.MG;

namespace CSI.Adapters
{
	public class GetCodeDescsFactory
	{
        public IGetCodeDescs Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetCodeDescs = new Adapters.GetCodeDescs(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCodeDescsExt = timerfactory.Create<Adapters.IGetCodeDescs>(_GetCodeDescs);

            return iGetCodeDescsExt;
        }
    }
}
