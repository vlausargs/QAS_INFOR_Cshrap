//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_GetContainerContentFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AU_GetContainerContentFactory
    {
        public IAU_GetContainerContent Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _AU_GetContainerContent = new AU_GetContainerContent(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_GetContainerContentExt = timerfactory.Create<IAU_GetContainerContent>(_AU_GetContainerContent);

            return iAU_GetContainerContentExt;
        }
    }
}
