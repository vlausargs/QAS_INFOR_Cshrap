//PROJECT NAME: Production
//CLASS NAME: IExpandValidateRJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IExpandValidateRJob
	{
		(int? ReturnCode, string Item,
		string Infobar) ExpandValidateRJobSp(string Job,
		int? Suffix,
		int? PostMatlIssues,
		string Item,
		string Infobar);
	}
}

