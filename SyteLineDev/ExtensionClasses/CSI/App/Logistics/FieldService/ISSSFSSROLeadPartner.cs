//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROLeadPartner.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROLeadPartner
	{
		string SSSFSSROLeadPartnerFn(
			string iPartner = null,
			string iIncNum = null,
			string iCustNum = null,
			int? iCustSeq = null,
			string iSroType = null,
			string iSerNum = null,
			string iItem = null);
	}
}

