//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvPostSaveFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class RsvdInvPostSaveFactory
    {
        public IRsvdInvPostSave Create(IApplicationDB appDB)
        {
            var _RsvdInvPostSave = new RsvdInvPostSave(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRsvdInvPostSaveExt = timerfactory.Create<IRsvdInvPostSave>(_RsvdInvPostSave);

            return iRsvdInvPostSaveExt;
        }
    }
}
