//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubLoadTTContToBill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubLoadTTContToBill
	{
		int? SSSFSConInvSubLoadTTContToBillSp(
			Guid? SessionId,
			string Contract,
			int? ContLine,
			DateTime? RenewByDate,
			string CalledFromForm = null);
	}
}

