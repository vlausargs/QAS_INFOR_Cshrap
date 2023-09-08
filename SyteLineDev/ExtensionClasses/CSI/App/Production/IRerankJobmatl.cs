//PROJECT NAME: Production
//CLASS NAME: IRerankJobmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRerankJobmatl
	{
		(int? ReturnCode, string Infobar) RerankJobmatlSp(string Job,
		int? Suffix,
		int? OperNum,
		int? AltGroup,
		string Infobar);
	}
}

