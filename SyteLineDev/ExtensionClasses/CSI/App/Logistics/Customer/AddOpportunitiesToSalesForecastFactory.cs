//PROJECT NAME: CSICustomer
//CLASS NAME: AddOpportunitiesToSalesForecastFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class AddOpportunitiesToSalesForecastFactory
    {
        public IAddOpportunitiesToSalesForecast Create(IApplicationDB appDB)
        {
            var _AddOpportunitiesToSalesForecast = new Logistics.Customer.AddOpportunitiesToSalesForecast(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAddOpportunitiesToSalesForecastExt = timerfactory.Create<Logistics.Customer.IAddOpportunitiesToSalesForecast>(_AddOpportunitiesToSalesForecast);

            return iAddOpportunitiesToSalesForecastExt;
        }
    }
}
