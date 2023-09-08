//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_MiscExp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_MiscExp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_MiscExpSp(string _iPartnerStart,
		string _iPartnerEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		int? _iTransDateStart_OffSET = null,
		int? _iTransDateEnd_OffSET = null,
		string _iSroNumStart = null,
		string _iSroNumEnd = null,
		int? _iSROLineStart = null,
		int? _iSROLineEnd = null,
		int? _iSroOperStart = null,
		int? _iSroOperEnd = null,
		string _iPayTypeStart = null,
		string _iPayTypeEnd = null,
		string _iMiscCodeStart = null,
		string _iMiscCodeEnd = null,
		string _iShowStat = null,
		string pSite = null);
	}
}

