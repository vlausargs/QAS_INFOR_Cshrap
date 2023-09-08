//PROJECT NAME: Logistics
//CLASS NAME: ISchedUpdatePartner.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedUpdatePartner
	{
		(int? ReturnCode, string Infobar) SchedUpdatePartnerSp(Guid? RowPointer,
		Guid? NewRowPointer,
		string PartnerId,
		DateTime? StartDate,
		int? View,
		string Infobar);
	}
}

