using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteCRUD
    {
        long ReadRelevantObjectNotesCount(string tableName);
        ICollectionLoadResponse ReadRelevantObjectNotesBookmarkRowData(int origin, string tableName, string whereClause);
        bool ReadRelevantSpecificNotesData(string tableName, string bookMark, int taskSize);
        bool ReadRelevantSystemNotesData(string tableName, string bookMark, int taskSize);
        bool ReadRelevantUserNotesData(string tableName, string bookMark, int taskSize);
    }

    public class ObjectNoteCRUD : IObjectNoteCRUD
    {
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IApplicationDB _applicationDB;
        private readonly IExistsChecker _existsChecker;

        public ObjectNoteCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IApplicationDB applicationDB,
            IExistsChecker existsChecker)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _applicationDB = applicationDB;
            _existsChecker = existsChecker;
        }

        public long ReadRelevantObjectNotesCount(string tableName)
        {
            LongType objectNotesCount = 0;

            var request = _collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {objectNotesCount,"COUNT(1)"},
                },
                tableName: "ObjectNotes",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON t.RowPointer = ObjectNotes.RefRowPointer"),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            _applicationDB.Load(request);

            return objectNotesCount;
        }

        public ICollectionLoadResponse ReadRelevantObjectNotesBookmarkRowData(
                int origin,
                string tableName,
                string whereClause)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>
                    {
                        {"ObjectNoteToken", "ObjectNoteToken"}
                    },
                 loadForChange: false,
                 lockingType: LockingType.None,
                 tableName: "ObjectNotes",
                 fromClause: _collectionLoadRequestFactory.Clause($" INNER JOIN {tableName} t ON t.RowPointer = ObjectNotes.RefRowPointer"),
                 whereClause: _collectionLoadRequestFactory.Clause($"{whereClause}"),
                 orderByClause: _collectionLoadRequestFactory.Clause($"ObjectNoteToken OFFSET {origin} ROWS FETCH NEXT 1 ROWS ONLY"));
            return _applicationDB.Load(loadRequest);
        }

        public bool ReadRelevantSpecificNotesData(
            string tableName,
            string bookMark,
            int taskSize)
        {
            return _existsChecker.Exists(
                tableName: "SpecificNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"SpecificNoteToken IN (SELECT SpecificNoteToken
                    FROM ObjectNotes
                    INNER JOIN {tableName} t ON t.RowPointer = ObjectNotes.RefRowPointer
                    WHERE {bookMark} ORDER BY ObjectNoteToken OFFSET 0 ROWS FETCH NEXT {taskSize} ROWS ONLY)"));
        }

        public bool ReadRelevantSystemNotesData(
            string tableName,
            string bookMark,
            int taskSize)
        {
            return _existsChecker.Exists(
                tableName: "SystemNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"SystemNoteToken IN (SELECT SystemNoteToken
                    FROM ObjectNotes
                    INNER JOIN {tableName} t ON t.RowPointer = ObjectNotes.RefRowPointer
                    WHERE {bookMark} ORDER BY ObjectNoteToken OFFSET 0 ROWS FETCH NEXT {taskSize} ROWS ONLY)"));
        }

        public bool ReadRelevantUserNotesData(
            string tableName,
            string bookMark,
            int taskSize)
        {
            return _existsChecker.Exists(
                tableName: "UserNotes",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"UserNoteToken IN (SELECT UserNoteToken
                    FROM ObjectNotes
                    INNER JOIN {tableName} t ON t.RowPointer = ObjectNotes.RefRowPointer
                    WHERE {bookMark} ORDER BY ObjectNoteToken OFFSET 0 ROWS FETCH NEXT {taskSize} ROWS ONLY)"));
        }

    }
}

