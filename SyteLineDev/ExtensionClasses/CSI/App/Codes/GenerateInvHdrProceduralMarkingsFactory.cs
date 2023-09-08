//PROJECT NAME: Codes
//CLASS NAME: GenerateInvHdrProceduralMarkingsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GenerateInvHdrProceduralMarkingsFactory
	{
		public IGenerateInvHdrProceduralMarkings Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GenerateInvHdrProceduralMarkings = new Codes.GenerateInvHdrProceduralMarkings(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateInvHdrProceduralMarkingsExt = timerfactory.Create<Codes.IGenerateInvHdrProceduralMarkings>(_GenerateInvHdrProceduralMarkings);
			
			return iGenerateInvHdrProceduralMarkingsExt;
		}
	}
}
