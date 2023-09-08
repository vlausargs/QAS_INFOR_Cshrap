//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateItemForReplenPOBlnFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ValidateItemForReplenPOBlnFactory
    {
        public IValidateItemForReplenPOBln Create(IApplicationDB appDB)
        {
            var _ValidateItemForReplenPOBln = new ValidateItemForReplenPOBln(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateItemForReplenPOBlnExt = timerfactory.Create<IValidateItemForReplenPOBln>(_ValidateItemForReplenPOBln);

            return iValidateItemForReplenPOBlnExt;
        }
    }
}
