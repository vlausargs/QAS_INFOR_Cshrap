//PROJECT NAME: Finance
//CLASS NAME: IArpmtpbl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtpbl
	{
		(int? ReturnCode,
			string Infobar) ArpmtpblSp(
			string PCustNum,
			DateTime? PRecptDate,
			string Infobar);
	}
}

