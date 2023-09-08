//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRecalcReimb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSRecalcReimb
	{
		int? SSSFSRecalcReimbSp(string PartnerID,
		string CurrCode);
	}
}

