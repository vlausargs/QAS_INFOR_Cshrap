using Mongoose.IDO;

namespace CSI.MG.MGCore
{
    public class MGApplicationEvent :  IApplicationEvent
    {
        private readonly ICSIExtensionClassBase _csiExtensionClassBase;

      public  MGApplicationEvent(ICSIExtensionClassBase csiExtensionClassBase)
        {
            _csiExtensionClassBase = csiExtensionClassBase;
        }

        public bool FireApplicationEvent(
            string eventName,
            bool synchronous,
            bool transactional,
            out string result,
            ref CSIApplicationEventParameter[] parameters)
        {

            return _csiExtensionClassBase.FireApplicationEvent(
                eventName,
                synchronous,
                transactional,
                out result,
                ref parameters);
        }
    }
}