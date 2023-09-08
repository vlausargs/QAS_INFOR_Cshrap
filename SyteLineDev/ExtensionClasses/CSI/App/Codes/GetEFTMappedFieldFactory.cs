//PROJECT NAME: Codes
//CLASS NAME: GetEFTMappedFieldFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetEFTMappedFieldFactory
    {
        public IGetEFTMappedField Create(IApplicationDB appDB)
        {
            var _GetEFTMappedField = new Codes.GetEFTMappedField(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetEFTMappedFieldExt = timerfactory.Create<Codes.IGetEFTMappedField>(_GetEFTMappedField);

            return iGetEFTMappedFieldExt;
        }
    }
}
