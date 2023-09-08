//PROJECT NAME: Finance
//CLASS NAME: UpdateDimAndDimAttributesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class UpdateDimAndDimAttributesFactory
	{
		public IUpdateDimAndDimAttributes Create(IApplicationDB appDB)
		{
			var _UpdateDimAndDimAttributes = new Finance.UpdateDimAndDimAttributes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateDimAndDimAttributesExt = timerfactory.Create<Finance.IUpdateDimAndDimAttributes>(_UpdateDimAndDimAttributes);
			
			return iUpdateDimAndDimAttributesExt;
		}
	}
}
