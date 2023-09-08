//PROJECT NAME: Production
//CLASS NAME: IValidateJobmatlReference.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobmatlReference
	{
		(int? ReturnCode, string Infobar) ValidateJobmatlReferenceSp(string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		string PJob,
		int? PSuffix,
		string Infobar);
	}
}

