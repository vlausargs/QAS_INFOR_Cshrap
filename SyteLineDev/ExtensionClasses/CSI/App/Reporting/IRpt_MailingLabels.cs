//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MailingLabels.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MailingLabels
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MailingLabelsSp(string GenerateLabelFor = null,
		string CEVType = null,
		int? SortByPostCode = null,
		int? PrintCountry = null,
		string PrintWhichCustomerContact = null,
		string NameStarting = null,
		string NameEnding = null,
		string CEVStarting = null,
		string CEVEnding = null,
		string ProvinceStateStarting = null,
		string ProvinceStateEnding = null,
		string PostalZipStarting = null,
		string PostalZipEnding = null,
		string pSite = null);
	}
}

