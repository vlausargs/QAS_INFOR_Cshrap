//PROJECT NAME: Logistics
//CLASS NAME: SaveOpportunitiesToSalesForecastFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SaveOpportunitiesToSalesForecastFactory
	{
		public ISaveOpportunitiesToSalesForecast Create(IApplicationDB appDB)
		{
			var _SaveOpportunitiesToSalesForecast = new Logistics.Customer.SaveOpportunitiesToSalesForecast(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveOpportunitiesToSalesForecastExt = timerfactory.Create<Logistics.Customer.ISaveOpportunitiesToSalesForecast>(_SaveOpportunitiesToSalesForecast);
			
			return iSaveOpportunitiesToSalesForecastExt;
		}
	}
}
