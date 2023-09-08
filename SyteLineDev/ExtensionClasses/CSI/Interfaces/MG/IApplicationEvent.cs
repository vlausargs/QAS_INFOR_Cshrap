namespace CSI.MG
{
    public interface IApplicationEvent
    {
        bool FireApplicationEvent(
            string eventName,
            bool synchronous,
            bool transactional,
            out string result,
            ref CSIApplicationEventParameter[] parameters);
    }

    public struct CSIApplicationEventParameter
    {
        public string Name;
        public string Value;
        public bool Output; 
    }
}