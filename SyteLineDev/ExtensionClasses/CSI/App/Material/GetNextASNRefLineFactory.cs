//PROJECT NAME: CSIMaterial
//CLASS NAME: GetNextASNRefLineFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetNextASNRefLineFactory
    {
        public IGetNextASNRefLine Create(IApplicationDB appDB)
        {
            var _GetNextASNRefLine = new GetNextASNRefLine(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetNextASNRefLineExt = timerfactory.Create<IGetNextASNRefLine>(_GetNextASNRefLine);

            return iGetNextASNRefLineExt;
        }
    }
}
