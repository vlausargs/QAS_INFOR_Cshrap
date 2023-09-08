using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.CRUD.Reporting
{
    public class Rpt_NotesCRUD : IRpt_NotesCRUD
    {
		readonly IApplicationDB _appDB;
		readonly ICollectionLoadStatementRequestFactory _collectionLoadStatementRequestFactory;
		readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;

        public Rpt_NotesCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            _appDB = appDB;
            _collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public ICollectionLoadResponse Load(Guid? pRefRowPointer = null, int? pShowExternal = 1, int? pShowInternal = 1)
        {
			var ReportNotesViewLoadRequest = _collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"value","value"},
				},
				selectStatement: _collectionLoadRequestFactory.Clause(@"SELECT CHAR(1) + @selectList  
					FROM ReportNotesView CROSS APPLY STRING_SPLIT (CAST (Note AS NVARCHAR (MAX)), char(10)) 
					WHERE RefRowPointer = {0}  
					      AND (({1}  = 1 
					            AND IsInternalNote = 0) 
					           OR ({2}  = 1 
					               AND IsInternalNote = 1))", pRefRowPointer, pShowExternal, pShowInternal));

			return _appDB.Load(ReportNotesViewLoadRequest);
		}
    }
}
