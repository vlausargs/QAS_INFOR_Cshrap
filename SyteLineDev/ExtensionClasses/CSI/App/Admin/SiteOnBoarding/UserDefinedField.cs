namespace CSI.Admin.SiteOnBoarding
{
    public interface IUserDefinedField
    {
        bool CreateTaskList(string appViewName, string site, int taskSize);
    }

    public class UserDefinedField : IUserDefinedField
    {
        private readonly IUserDefinedFieldCRUD _userDefinedFieldCRUD;
        private readonly IUserDefinedFieldCreateTaskWithWhereClause _userDefinedFieldCreateTaskWithWhereClause;


        public UserDefinedField(IUserDefinedFieldCRUD userDefinedFieldCRUD,
            IUserDefinedFieldCreateTaskWithWhereClause userDefinedFieldCreateTaskWithWhereClause)
        {
            _userDefinedFieldCRUD = userDefinedFieldCRUD;
            _userDefinedFieldCreateTaskWithWhereClause = userDefinedFieldCreateTaskWithWhereClause;
        }

        public bool CreateTaskList(
            string appViewName,
            string site,
            int taskSize)
        {
            var tableRowsCount = _userDefinedFieldCRUD.ReadRelevantUDFCount(appViewName);

            // No record means we needn't process this relevant table
            if (tableRowsCount <= 0) return true;

            _userDefinedFieldCreateTaskWithWhereClause.CreateUserDefinedFieldTasks(appViewName, site, taskSize, tableRowsCount);
            
            return true;
        }
    }
}
