//PROJECT NAME: Production
//CLASS NAME: IRecalculateObligations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRecalculateObligations
	{
		(int? ReturnCode, string Infobar) RecalculateObligationsSp(string Infobar);
	}
}

