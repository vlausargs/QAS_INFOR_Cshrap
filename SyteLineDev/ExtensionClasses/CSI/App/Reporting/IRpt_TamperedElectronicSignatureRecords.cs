//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TamperedElectronicSignatureRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TamperedElectronicSignatureRecords
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TamperedElectronicSignatureRecordsSp(Guid? SessionID = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? DisplayHeader = null,
		string LanguageId = null,
		string pSite = null);
	}
}

