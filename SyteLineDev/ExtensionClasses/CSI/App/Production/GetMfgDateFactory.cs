//PROJECT NAME: CSIProduct
//CLASS NAME: GetMfgDateFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GetMfgDateFactory
    {
        public IGetMfgDate Create(IApplicationDB appDB)
        {
            var _GetMfgDate = new GetMfgDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetMfgDateExt = timerfactory.Create<IGetMfgDate>(_GetMfgDate);

            return iGetMfgDateExt;
        }
    }
}
