using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDataCollector
    {
        List<Dictionary<string, string>> GetTaskData(string appViewName, int taskSize, string tableName, string taskBookMark);
    }

    public class DataCollector : IDataCollector
    {

        private readonly ICommonTaskTableData _commonTaskTableData;
        private readonly IRelevantDocObject _relevantDocObject;
        private readonly IRelevantDocObjectReference _relevantDocObjectReference;
        private readonly IRelevantNoteHeader _relevantNoteHeader;
        private readonly IRelevantObjectNotes _relevantObjectNotes;
        private readonly IRelevantSpecificNotes _relevantSpecificNotes;
        private readonly IRelevantSystemNotes _relevantSystemNotes;
        private readonly IRelevantUDF _relevantUDF;
        private readonly IRelevantUserNotes _relevantUserNotes;

        public DataCollector(ICommonTaskTableData commonTaskTableData, IRelevantDocObject relevantDocObject, IRelevantDocObjectReference relevantDocObjectReference, IRelevantNoteHeader relevantNoteHeader, IRelevantObjectNotes relevantObjectNotes, IRelevantSpecificNotes relevantSpecificNotes, IRelevantUDF relevantUDF, IRelevantUserNotes relevantUserNotes, IRelevantSystemNotes relevantSystemNotes)
        {
            _commonTaskTableData = commonTaskTableData;
            _relevantDocObject = relevantDocObject;
            _relevantDocObjectReference = relevantDocObjectReference;
            _relevantNoteHeader = relevantNoteHeader;
            _relevantObjectNotes = relevantObjectNotes;
            _relevantSpecificNotes = relevantSpecificNotes;
            _relevantUDF = relevantUDF;
            _relevantUserNotes = relevantUserNotes;
            _relevantSystemNotes = relevantSystemNotes;
        }

        public List<Dictionary<string, string>> GetTaskData(string appViewName, int taskSize, string tableName, string taskBookMark)
        {

            switch (tableName)
            {
                case nameof(MGTableName.DocumentObjectReference):
                    return _relevantDocObjectReference.ReadRelevantDocObjectReferenceData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.DocumentObject):
                    return _relevantDocObject.ReadRelevantDocObjectData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.NoteHeaders):
                    return _relevantNoteHeader.ReadRelevantNoteHeadersData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.ObjectNotes):
                    return _relevantObjectNotes.ReadRelevantObjectNotesData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.SpecificNotes):
                    return _relevantSpecificNotes.ReadRelevantSpecificNotesData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.SystemNotes):
                    return _relevantSystemNotes.ReadRelevantSystemNotesData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.UserNotes):
                    return _relevantUserNotes.ReadRelevantUserNotesData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                case nameof(MGTableName.UserDefinedFields):
                    return _relevantUDF.ReadRelevantUDFData(
                        appViewName,
                        taskSize,
                        taskBookMark
                        );
                default:
                    return _commonTaskTableData.ReadCommonTaskTableData(
                        appViewName,
                        taskSize,
                        tableName,
                        taskBookMark
                        );
            }
        }
    }
}
