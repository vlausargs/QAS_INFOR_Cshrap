//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBEUSalesLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBEUSalesLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBEUSalesLineSp(string SiteGroup,
		int? CalendarQuarter,
		DateTime? StartTaxPeriod,
		DateTime? EndTaxPeriod,
		string StartCust,
		string EndCust,
		string StartEcCode,
		string EndEcCode,
		string StartProcessInd,
		string EndProcessInd);
	}
}

