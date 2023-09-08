

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITargetFileName
    {
        string GetTargetFileName(string appViewName, string site, int? totalTasks, int taskNum, string targetFileType);
    }

    public class TargetFileName : ITargetFileName
    {
        private readonly ISchemaLevelChecker _schemaLevelChecker;

        public TargetFileName(ISchemaLevelChecker schemaLevelChecker)
        {
            _schemaLevelChecker = schemaLevelChecker;
        }
        public string GetTargetFileName(string appViewName, string site, int? totalTasks, int taskNum, string targetFileType)
        {
            var dbLevel = _schemaLevelChecker.ReadSchemaLevel();
            switch(targetFileType)
            {
                case "C":
                    return $"{appViewName}-{site}-{dbLevel}-{totalTasks}-{taskNum}.csv";
                case "J":
                    return $"{appViewName}-{site}-{dbLevel}-{totalTasks}-{taskNum}.json";
                case "X":
                    return $"{appViewName}-{site}-{dbLevel}-{totalTasks}-{taskNum}.xml";
                default:
                    return $"{appViewName}-{site}-{dbLevel}-{totalTasks}-{taskNum}.csv";
            }
        }

    }
}
