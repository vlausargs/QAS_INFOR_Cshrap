using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IRelevantDataExporter
    {
        (bool isSuccess, string errorMsg) CreateTaskListForRelevantTable(string appViewName, string site, int taskSize);
    }

    public class RelevantDataExporter : IRelevantDataExporter
    {
        private readonly IDocumentObjectReference _documentObjectReference;
        private readonly IObjectNote _objectNote;
        private readonly IUserDefinedField _userDefinedField;

        public RelevantDataExporter(IDocumentObjectReference documentObjectReference,
            IObjectNote objectNote,
            IUserDefinedField userDefinedField)
        {
            _documentObjectReference = documentObjectReference;
            _objectNote = objectNote;
            _userDefinedField = userDefinedField;
        }

        public (bool isSuccess, string errorMsg) CreateTaskListForRelevantTable(
            string appViewName,
            string site,
            int taskSize)
        {
            var isSuccess = true;
            var errorMsg = string.Empty;

            try
            {
                _documentObjectReference.CreateTaskList(appViewName, site, taskSize);
                _objectNote.CreateTaskList(appViewName, site, taskSize);
                _userDefinedField.CreateTaskList(appViewName, site, taskSize);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                errorMsg = ex.Message;
            }

            return (isSuccess, errorMsg);
        }
    }
}
