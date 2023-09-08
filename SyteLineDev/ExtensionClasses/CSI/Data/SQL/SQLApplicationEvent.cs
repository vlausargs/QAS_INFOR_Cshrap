using CSI.MG;

namespace CSI.Data.SQL
{
    public class SQLApplicationEvent : IApplicationEvent
    {
        public bool FireApplicationEvent(
            string eventName,
            bool synchronous,
            bool transactional,
            out string result,
            ref CSIApplicationEventParameter[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}