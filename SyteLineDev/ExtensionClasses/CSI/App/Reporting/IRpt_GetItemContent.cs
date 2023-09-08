//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GetItemContent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GetItemContent
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetItemContentSp(string Item = null,
			string RefType = null,
			string RefNum = null,
			int? RefLine = null,
			int? RefRelease = null,
			string pSite = null,
			string InvNum = null,
			int? InvLine = null,
			int? InvSeq = null);
	}
}

