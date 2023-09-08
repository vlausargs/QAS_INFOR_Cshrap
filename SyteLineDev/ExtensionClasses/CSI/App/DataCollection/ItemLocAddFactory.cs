//PROJECT NAME: DataCollection
//CLASS NAME: ItemLocAddFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class ItemLocAddFactory
	{
		public IItemLocAdd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemLocAdd = new DataCollection.ItemLocAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLocAddExt = timerfactory.Create<DataCollection.IItemLocAdd>(_ItemLocAdd);
			
			return iItemLocAddExt;
		}
	}
}
