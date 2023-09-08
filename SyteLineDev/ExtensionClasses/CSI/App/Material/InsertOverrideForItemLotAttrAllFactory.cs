//PROJECT NAME: Material
//CLASS NAME: InsertOverrideForItemLotAttrAllFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InsertOverrideForItemLotAttrAllFactory
	{
		public IInsertOverrideForItemLotAttrAll Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertOverrideForItemLotAttrAll = new Material.InsertOverrideForItemLotAttrAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOverrideForItemLotAttrAllExt = timerfactory.Create<Material.IInsertOverrideForItemLotAttrAll>(_InsertOverrideForItemLotAttrAll);
			
			return iInsertOverrideForItemLotAttrAllExt;
		}
	}
}
