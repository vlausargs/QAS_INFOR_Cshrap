//PROJECT NAME: CSICustomer
//CLASS NAME: GenerateRefNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GenerateRefNumFactory
    {
        public IGenerateRefNum Create(IApplicationDB appDB)
        {
            var _GenerateRefNum = new GenerateRefNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenerateRefNumExt = timerfactory.Create<IGenerateRefNum>(_GenerateRefNum);

            return iGenerateRefNumExt;
        }
    }
}
