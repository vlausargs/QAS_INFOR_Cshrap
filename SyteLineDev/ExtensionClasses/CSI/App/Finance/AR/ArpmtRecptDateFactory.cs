//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtRecptDateFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtRecptDateFactory
    {
        public IArpmtRecptDate Create(IApplicationDB appDB)
        {
            var _ArpmtRecptDate = new ArpmtRecptDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtRecptDateExt = timerfactory.Create<IArpmtRecptDate>(_ArpmtRecptDate);

            return iArpmtRecptDateExt;
        }
    }
}
