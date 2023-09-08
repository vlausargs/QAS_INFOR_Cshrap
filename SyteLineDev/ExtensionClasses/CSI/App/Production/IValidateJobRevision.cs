//PROJECT NAME: Production
//CLASS NAME: IValidateJobRevision.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobRevision
	{
		(int? ReturnCode, string PRevision,
		string Infobar) ValidateJobRevisionSp(string PItem,
		string PRevision,
		string Infobar);
	}
}

