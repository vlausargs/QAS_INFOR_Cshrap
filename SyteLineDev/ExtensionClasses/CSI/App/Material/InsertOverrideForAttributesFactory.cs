//PROJECT NAME: Material
//CLASS NAME: InsertOverrideForAttributesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InsertOverrideForAttributesFactory
	{
		public IInsertOverrideForAttributes Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertOverrideForAttributes = new Material.InsertOverrideForAttributes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOverrideForAttributesExt = timerfactory.Create<Material.IInsertOverrideForAttributes>(_InsertOverrideForAttributes);
			
			return iInsertOverrideForAttributesExt;
		}
	}
}
