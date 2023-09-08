//PROJECT NAME: Production
//CLASS NAME: IJobOrdersValidateItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOrdersValidateItem
	{
		(int? ReturnCode, string Infobar) JobOrdersValidateItemSp(string PItem,
		string PJob,
		int? PSuffix,
		string PJobType,
		int? PCoProductMix,
		string Infobar);
	}
}

