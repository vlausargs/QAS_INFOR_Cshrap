//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CalculateProjectedDateFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_CalculateProjectedDateFactory
    {
        public IAU_CalculateProjectedDate Create(IApplicationDB appDB)
        {
            var _AU_CalculateProjectedDate = new AU_CalculateProjectedDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_CalculateProjectedDateExt = timerfactory.Create<IAU_CalculateProjectedDate>(_AU_CalculateProjectedDate);

            return iAU_CalculateProjectedDateExt;
        }
    }
}

