//PROJECT NAME: Production
//CLASS NAME: IApsDelAPSOPTIONS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsDelAPSOPTIONS
	{
		int? ApsDelAPSOPTIONSSp(Guid? Rowp,
		int? AltNo);
	}
}

