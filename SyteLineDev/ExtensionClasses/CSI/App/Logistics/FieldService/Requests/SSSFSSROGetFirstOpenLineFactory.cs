//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROGetFirstOpenLineFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROGetFirstOpenLineFactory
    {
        public ISSSFSSROGetFirstOpenLine Create(IApplicationDB appDB)
        {
            var _SSSFSSROGetFirstOpenLine = new SSSFSSROGetFirstOpenLine(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROGetFirstOpenLineExt = timerfactory.Create<ISSSFSSROGetFirstOpenLine>(_SSSFSSROGetFirstOpenLine);

            return iSSSFSSROGetFirstOpenLineExt;
        }
    }
}

