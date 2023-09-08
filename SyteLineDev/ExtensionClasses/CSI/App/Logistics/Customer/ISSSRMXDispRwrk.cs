//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispRwrk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispRwrk
	{
		(int? ReturnCode,
			string Infobar) SSSRMXDispRwrkSp(
			Guid? DispRowPointer,
			string iSroCopyTransFrom,
			string iTemplateSroNum,
			int? iTemplateSROLine,
			string iSelectedOpers,
			string iBillMgr,
			string iSRODesc,
			string iLeadPartner,
			string iCompItem,
			decimal? iCompQtyOrd,
			int? RewSROCreatedAlready,
			string RewSroNum,
			int? RewSroLine,
			int? RewSroOper,
			string Infobar);
	}
}

