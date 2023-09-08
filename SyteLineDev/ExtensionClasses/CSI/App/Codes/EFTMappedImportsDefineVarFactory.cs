//PROJECT NAME: CSICodes
//CLASS NAME: EFTMappedImportsDefineVarFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class EFTMappedImportsDefineVarFactory
	{
		public IEFTMappedImportsDefineVar Create(IApplicationDB appDB)
		{
			var _EFTMappedImportsDefineVar = new Codes.EFTMappedImportsDefineVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTMappedImportsDefineVarExt = timerfactory.Create<Codes.IEFTMappedImportsDefineVar>(_EFTMappedImportsDefineVar);
			
			return iEFTMappedImportsDefineVarExt;
		}
	}
}
