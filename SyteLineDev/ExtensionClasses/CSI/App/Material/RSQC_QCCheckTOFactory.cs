//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_QCCheckTOFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RSQC_QCCheckTOFactory
    {
        public IRSQC_QCCheckTO Create(IApplicationDB appDB)
        {
            var _RSQC_QCCheckTO = new RSQC_QCCheckTO(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_QCCheckTOExt = timerfactory.Create<IRSQC_QCCheckTO>(_RSQC_QCCheckTO);

            return iRSQC_QCCheckTOExt;
        }
    }
}
