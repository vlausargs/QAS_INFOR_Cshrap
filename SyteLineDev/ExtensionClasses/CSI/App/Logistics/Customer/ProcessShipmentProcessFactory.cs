//PROJECT NAME: Logistics.Customer
//CLASS NAME: ProcessShipmentProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class ProcessShipmentProcessFactory
    {
        public IProcessShipmentProcess Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _ProcessShipmentProcess = new Logistics.Customer.ProcessShipmentProcess(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProcessShipmentProcessExt = timerfactory.Create<Logistics.Customer.IProcessShipmentProcess>(_ProcessShipmentProcess);

            return iProcessShipmentProcessExt;
        }
    }
}
