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
	public class SplitStringFactory : ISplitStringFactory
	{
		public ISplitString Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IBunchedLoadCollection bunchedLoadCollection,
		IParameterProvider parameterProvider,
		IDataTableUtil dataTableUtil,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SplitString = new MGCore.SplitString(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);


			return _SplitString;
		}
	}
}
