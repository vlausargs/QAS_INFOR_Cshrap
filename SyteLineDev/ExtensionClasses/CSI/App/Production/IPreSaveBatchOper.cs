//PROJECT NAME: Production
//CLASS NAME: IPreSaveBatchOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPreSaveBatchOper
	{
		(int? ReturnCode, int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar) PreSaveBatchOperSp(string Batch,
		int? OperNum,
		string Wc,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

