//PROJECT NAME: Production
//CLASS NAME: IValidateJobOrderWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobOrderWhse
	{
		(int? ReturnCode, string Infobar) ValidateJobOrderWhseSp(string PItem,
		string PWhse,
		int? PMultiWhse,
		string PDefWhse,
		string Infobar);
	}
}

