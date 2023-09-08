//PROJECT NAME: Production
//CLASS NAME: IApsWhseDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseDel
	{
		int? ApsWhseDelSp(Guid? Rowp,
		int? AltNo);
	}
}

