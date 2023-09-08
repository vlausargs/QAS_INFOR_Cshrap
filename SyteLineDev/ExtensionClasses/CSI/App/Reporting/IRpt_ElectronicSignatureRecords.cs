//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ElectronicSignatureRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ElectronicSignatureRecords
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ElectronicSignatureRecordsSp(string EsigType,
		string EsigNumber = null,
		int? EsigLine = null,
		int? EsigRelease = null,
		string LanguageId = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

