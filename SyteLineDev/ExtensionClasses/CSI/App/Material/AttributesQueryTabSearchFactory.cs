//PROJECT NAME: CSIMaterial
//CLASS NAME: AttributesQueryTabSearchFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AttributesQueryTabSearchFactory
    {
        public IAttributesQueryTabSearch Create(IApplicationDB appDB)
        {
            var _AttributesQueryTabSearch = new AttributesQueryTabSearch(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAttributesQueryTabSearchExt = timerfactory.Create<IAttributesQueryTabSearch>(_AttributesQueryTabSearch);

            return iAttributesQueryTabSearchExt;
        }
    }
}
