//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_AcmTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_AcmTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_AcmTransSp(string ExOptBegCust_num = null,
		string ExOptEndCust_num = null,
		string ExOptBegRef_num = null,
		string ExOptEndRef_num = null,
		string ExOptBegInv_num = null,
		string ExOptEndInv_num = null,
		string ExOptBegAcct_num = null,
		string ExOptEndAcct_num = null,
		int? Period = null,
		int? Year = null,
		string pSite = null,
		string ReportOption = null);
	}
}

