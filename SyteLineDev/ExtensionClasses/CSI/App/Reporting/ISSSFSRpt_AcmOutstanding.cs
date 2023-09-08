//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_AcmOutstanding.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_AcmOutstanding
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSRpt_AcmOutstandingSp(string ExOptBegCust_num = null,
		string ExOptEndCust_num = null,
		string ExOptBegRef_num = null,
		string ExOptEndRef_num = null,
		string ExOptBegInv_num = null,
		string ExOptEndInv_num = null,
		string ExOptBegAcct_num = null,
		string ExOptEndAcct_num = null,
		string ACMStatus = null,
		string Infobar = null,
		string pSite = null,
		string ReportOption = null);
	}
}

