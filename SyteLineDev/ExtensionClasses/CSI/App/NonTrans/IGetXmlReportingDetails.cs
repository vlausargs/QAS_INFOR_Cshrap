//PROJECT NAME: NonTrans
//CLASS NAME: IGetXmlReportingDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.NonTrans
{
	public interface IGetXmlReportingDetails
	{
		(int? ReturnCode, string IntranetName,
		string XMLReportingURL,
		string XMLReportingFolder,
		string XMLReportingDatasetURL,
		string Infobar) GetXmlReportingDetailsSp(string SiteID,
		string IntranetName,
		string XMLReportingURL,
		string XMLReportingFolder,
		string XMLReportingDatasetURL,
		string Infobar);
	}
}

