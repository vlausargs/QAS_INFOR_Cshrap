//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToC
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToCSp(
			string pCorpSite,
			string pMode,
			string Infobar);
	}
}

