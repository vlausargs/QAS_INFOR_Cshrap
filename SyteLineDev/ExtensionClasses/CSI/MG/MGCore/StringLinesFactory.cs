using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data;

namespace CSI.MG.MGCore
{
	public class StringLinesFactory : IStringLinesFactory
	{
		public IStringLines Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IBunchedLoadCollection bunchedLoadCollection,
		IParameterProvider parameterProvider,
		IDataTableUtil dataTableUtil,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _StringLines = new MGCore.StringLines(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);


			return _StringLines;
		}
	}
}
