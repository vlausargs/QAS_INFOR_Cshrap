using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;


namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskDataCollectorCRUD
    {
        ICollectionLoadResponse ReadCommonTableData(int rowNumber, string tableName, string bookMark, List<string> primaryKeys, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantUDFData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantUserNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantSystemNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantSpecificNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantObjectNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantNoteHeadersData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantDocObjectData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
        ICollectionLoadResponse ReadRelevantDocObjectReferenceData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns);
    }

    public class TaskDataCollectorCRUD : ITaskDataCollectorCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;

        public TaskDataCollectorCRUD(IApplicationDB applicationDB, ICollectionLoadRequestFactory collectionLoadRequestFactory, IVariableUtil variableUtil)
        {
            _applicationDB = applicationDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
        }

        public ICollectionLoadResponse ReadCommonTableData(int rowNumber, string tableName, string bookMark, List<string> primaryKeys, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: tableName,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(bookMark),
                orderByClause: _collectionLoadRequestFactory.Clause(string.Join(",", primaryKeys)));

            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantUDFData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "UserDefinedFields",
                fromClause: _collectionLoadRequestFactory.Clause($"As ud INNER JOIN {tableName} t ON t.RowPointer = ud.RowId"),
                whereClause: _collectionLoadRequestFactory.Clause($"TableName = {_variableUtil.GetQuotedValue(tableName)} AND {bookMark}"));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantUserNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "UserNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"UserNoteToken IN (SELECT DISTINCT UserNoteToken FROM ObjectNotes INNER JOIN {tableName} As t ON t.RowPointer = ObjectNotes.RefRowPointer WHERE SpecificNoteToken IS NOT NULL AND {bookMark} )"));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantSystemNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "SystemNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"SystemNoteToken IN (SELECT DISTINCT SystemNoteToken FROM ObjectNotes INNER JOIN { tableName} AS t ON t.RowPointer = ObjectNotes.RefRowPointer WHERE SpecificNoteToken IS NOT NULL AND { bookMark} )"));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantSpecificNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "SpecificNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"SpecificNoteToken IN(SELECT DISTINCT SpecificNoteToken FROM ObjectNotes INNER JOIN {tableName} As t ON t.RowPointer = ObjectNotes.RefRowPointer WHERE SpecificNoteToken IS NOT NULL AND {bookMark})"));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantObjectNotesData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "ObjectNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"RefRowPointer IN (SELECT RowPointer FROM {tableName}) AND {bookMark}"));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantNoteHeadersData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "NoteHeaders",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"NoteHeaderToken IN (SELECT DISTINCT NoteHeaderToken FROM ObjectNotes INNER JOIN {tableName} As t ON t.RowPointer = ObjectNotes.RefRowPointer WHERE NoteHeaderToken IS NOT NULL AND {bookMark})"));
            return _applicationDB.Load(request);
        }
        public ICollectionLoadResponse ReadRelevantDocObjectData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "DocumentObject",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"RowPointer IN (SELECT DocumentObjectReference.DocumentObjectRowPointer FROM DocumentObjectReference INNER JOIN {tableName} As t ON TableRowPointer = t.RowPointer WHERE TableName = '{tableName}' AND { bookMark}) "));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse ReadRelevantDocObjectReferenceData(int rowNumber, string tableName, string bookMark, Dictionary<string, string> columns)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: columns,
                loadForChange: false,
                maximumRows: rowNumber,
                lockingType: LockingType.None,
                tableName: "DocumentObjectReference",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"TableRowPointer IN (SELECT RowPointer FROM {tableName} WHERE TableName = {_variableUtil.GetQuotedValue(tableName)}) AND {bookMark}"));
            return _applicationDB.Load(request);
        }
    }
}
