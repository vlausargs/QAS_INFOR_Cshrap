//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcLocValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcLocValidFactory
    {
        public IDcsfcLocValid Create(IApplicationDB appDB)
        {
            var _DcsfcLocValid = new DcsfcLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcLocValidExt = timerfactory.Create<IDcsfcLocValid>(_DcsfcLocValid);

            return iDcsfcLocValidExt;
        }
    }
}

