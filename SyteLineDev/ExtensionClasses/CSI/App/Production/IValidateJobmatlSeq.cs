//PROJECT NAME: Production
//CLASS NAME: IValidateJobmatlSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobmatlSeq
	{
		(int? ReturnCode, string UM,
		string Item,
		string Infobar) ValidateJobmatlSeqSp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string UM = null,
		string Item = null,
		string Infobar = null);
	}
}

