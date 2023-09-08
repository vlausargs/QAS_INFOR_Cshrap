//PROJECT NAME: DataCollection
//CLASS NAME: IDcjitSfcV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjitSfcV
	{
		(int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjitSfcVSp(
			int? PTransNum,
			decimal? PJobtranTransNum,
			int? CanOverride,
			string Infobar);
	}
}

