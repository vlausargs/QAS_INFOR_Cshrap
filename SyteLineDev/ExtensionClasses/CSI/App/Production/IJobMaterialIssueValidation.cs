//PROJECT NAME: Production
//CLASS NAME: IJobMaterialIssueValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobMaterialIssueValidation
	{
		(int? ReturnCode, string Infobar) JobMaterialIssueValidationSp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Item,
		string Infobar = null);
	}
}

