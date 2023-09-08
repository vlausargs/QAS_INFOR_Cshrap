//PROJECT NAME: Production
//CLASS NAME: IAsRulesCmpCstI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IAsRulesCmpCstI
	{
		(int? ReturnCode,
			string Infobar) AsRulesCmpCstISp(
			string JobType,
			Guid? RowPointer,
			string Infobar);
	}
}

