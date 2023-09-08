//PROJECT NAME: Finance
//CLASS NAME: IApActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApActive
	{
		(int? ReturnCode,
			string Infobar) ApActiveSp(
			string PVendNum,
			int? PVoucher,
			string PParmsCurrCode,
			int? PCurrPlaces,
			string PApParmsInvDue,
			string PNonApOption,
			int? PNewValueFlag,
			int? PRetrieveMsgs = 0,
			string Infobar = null,
			int? BufferUpdates = 0);
	}
}

