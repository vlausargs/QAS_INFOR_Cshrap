//PROJECT NAME: CSIRSQCS
//CLASS NAME: GeneratePackageFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class GeneratePackageFactory
	{
		public IGeneratePackage Create(IApplicationDB appDB)
		{
			var _GeneratePackage = new Production.Quality.GeneratePackage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePackageExt = timerfactory.Create<Production.Quality.IGeneratePackage>(_GeneratePackage);
			
			return iGeneratePackageExt;
		}
	}
}
