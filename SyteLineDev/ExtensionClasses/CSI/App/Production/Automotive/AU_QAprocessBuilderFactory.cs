//PROJECT NAME: Production
//CLASS NAME: AU_QAprocessBuilderFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
	public class AU_QAprocessBuilderFactory
	{
		public IAU_QAprocessBuilder Create(IApplicationDB appDB)
		{
			var _AU_QAprocessBuilder = new Production.Automotive.AU_QAprocessBuilder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_QAprocessBuilderExt = timerfactory.Create<Production.Automotive.IAU_QAprocessBuilder>(_AU_QAprocessBuilder);
			
			return iAU_QAprocessBuilderExt;
		}
	}
}
