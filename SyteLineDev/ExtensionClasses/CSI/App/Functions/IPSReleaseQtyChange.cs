//PROJECT NAME: Data
//CLASS NAME: IPSReleaseQtyChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPSReleaseQtyChange
	{
		(int? ReturnCode,
			string Infobar) PSReleaseQtyChangeSp(
			string RJob,
			int? RSuffix,
			string Infobar);
	}
}

