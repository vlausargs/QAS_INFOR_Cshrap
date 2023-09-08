//PROJECT NAME: Production
//CLASS NAME: IPutAltSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPutAltSched
	{
		int? PutAltSchedSp(int? pAltNo,
		DateTime? pStartDate,
		DateTime? pEndDate);
	}
}

