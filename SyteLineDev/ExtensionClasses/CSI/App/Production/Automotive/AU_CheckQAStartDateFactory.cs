//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CheckQAStartDateFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_CheckQAStartDateFactory
    {
        public IAU_CheckQAStartDate Create(IApplicationDB appDB)
        {
            var _AU_CheckQAStartDate = new AU_CheckQAStartDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_CheckQAStartDateExt = timerfactory.Create<IAU_CheckQAStartDate>(_AU_CheckQAStartDate);

            return iAU_CheckQAStartDateExt;
        }
    }
}

