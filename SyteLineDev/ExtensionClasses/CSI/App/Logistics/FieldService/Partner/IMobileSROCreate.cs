//PROJECT NAME: Logistics
//CLASS NAME: IMobileSROCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface IMobileSROCreate
	{
		(int? ReturnCode, string Infobar) MobileSROCreateSp(Guid? RowPointer,
		string Description = null,
		string CustNum = null,
		int? CustSeq = null,
		string PartnerId = null,
		string Contact = null,
		string Email = null,
		string Phone = null,
		string SroStat = null,
		string StatCode = null,
		string PriorCode = null,
		string BillCode = null,
		string BillType = null,
		DateTime? OpenDate = null,
		DateTime? CloseDate = null,
		string Infobar = null);
	}
}

