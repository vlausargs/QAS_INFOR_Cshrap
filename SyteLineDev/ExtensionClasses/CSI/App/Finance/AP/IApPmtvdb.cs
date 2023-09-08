//PROJECT NAME: Finance
//CLASS NAME: IApPmtvdb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApPmtvdb
	{
		(int? ReturnCode,
			string Infobar) ApPmtvdbSp(
			string PFromSite,
			string PToSite,
			Guid? PAppmtdRowPointer,
			string Infobar);
	}
}

