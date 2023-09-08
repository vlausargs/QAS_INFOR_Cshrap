using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
	public class EventMessageChoicesFactory : IEventMessageChoicesFactory
	{
		public IEventMessageChoices Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IBunchedLoadCollection bunchedLoadCollection,
		IParameterProvider parameterProvider,
		IDataTableUtil dataTableUtil,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EventMessageChoices = new MGCore.EventMessageChoices(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);


			return _EventMessageChoices;
		}
	}
}
