//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateSiteMoveFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ValidateSiteMoveFactory
    {
        public IValidateSiteMove Create(IApplicationDB appDB)
        {
            var _ValidateSiteMove = new ValidateSiteMove(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateSiteMoveExt = timerfactory.Create<IValidateSiteMove>(_ValidateSiteMove);

            return iValidateSiteMoveExt;
        }
    }
}
