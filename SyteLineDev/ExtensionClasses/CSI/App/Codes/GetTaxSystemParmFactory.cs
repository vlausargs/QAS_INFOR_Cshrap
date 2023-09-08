//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxSystemParmFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetTaxSystemParmFactory
    {
        public IGetTaxSystemParm Create(IApplicationDB appDB)
        {
            var _GetTaxSystemParm = new Codes.GetTaxSystemParm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTaxSystemParmExt = timerfactory.Create<Codes.IGetTaxSystemParm>(_GetTaxSystemParm);

            return iGetTaxSystemParmExt;
        }
    }
}
