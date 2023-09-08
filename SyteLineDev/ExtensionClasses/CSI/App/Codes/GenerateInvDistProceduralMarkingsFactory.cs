//PROJECT NAME: Codes
//CLASS NAME: GenerateInvDistProceduralMarkingsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GenerateInvDistProceduralMarkingsFactory
	{
		public IGenerateInvDistProceduralMarkings Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GenerateInvDistProceduralMarkings = new Codes.GenerateInvDistProceduralMarkings(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateInvDistProceduralMarkingsExt = timerfactory.Create<Codes.IGenerateInvDistProceduralMarkings>(_GenerateInvDistProceduralMarkings);
			
			return iGenerateInvDistProceduralMarkingsExt;
		}
	}
}
