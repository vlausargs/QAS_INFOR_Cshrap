//PROJECT NAME: Production
//CLASS NAME: IApsGntDeleteSelection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGntDeleteSelection
	{
		int? ApsGntDeleteSelectionSp(string PUsername,
		string PSelection,
		int? PMbrsOnly);
	}
}

