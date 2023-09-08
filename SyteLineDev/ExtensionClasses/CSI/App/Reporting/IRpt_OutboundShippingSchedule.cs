//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OutboundShippingSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OutboundShippingSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OutboundShippingScheduleSp(string Begvendnum = null,
		string Endvendnum = null,
		string Begponum = null,
		string Endponum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		int? BegorderdateOffset = null,
		int? EndorderdateOffset = null,
		string Begplancode = null,
		string Endplancode = null,
		string BegItem = null,
		string Enditem = null,
		string ExOptprPostedEmp = null,
		int? ExOptszShowDetail = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintNoteEdiPo = 1,
		int? PrintNoteEdiPoItem = 1,
		int? PrintNoteEdiPoBln = 1,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

