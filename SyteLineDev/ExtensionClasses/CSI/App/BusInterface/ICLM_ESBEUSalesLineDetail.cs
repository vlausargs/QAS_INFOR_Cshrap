//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBEUSalesLineDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBEUSalesLineDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBEUSalesLineDetailSp(string SiteGroup,
		string DeclarationID,
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

