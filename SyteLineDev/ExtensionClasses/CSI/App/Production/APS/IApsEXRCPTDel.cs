//PROJECT NAME: Production
//CLASS NAME: IApsEXRCPTDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsEXRCPTDel
	{
		int? ApsEXRCPTDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

