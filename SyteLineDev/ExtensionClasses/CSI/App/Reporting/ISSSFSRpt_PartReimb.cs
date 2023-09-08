//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_PartReimb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_PartReimb
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_PartReimbSp(string _iPartnerStart,
		string _iPartnerEnd,
		string _iSroNumStart,
		string _iSroNumEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		int? _iTransDateStart_OffSET = null,
		int? _iTransDateEnd_OffSET = null,
		string _iReimbStat = null,
		string _iBatchNum = null,
		string _iReimbMethod = null,
		string pSite = null);
	}
}

