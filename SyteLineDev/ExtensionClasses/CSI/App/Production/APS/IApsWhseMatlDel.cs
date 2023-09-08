//PROJECT NAME: Production
//CLASS NAME: IApsWhseMatlDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseMatlDel
	{
		int? ApsWhseMatlDelSp(Guid? Rowp,
		int? AltNo);
	}
}

