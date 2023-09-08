//PROJECT NAME: Production
//CLASS NAME: IJobMaterialsPreDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobMaterialsPreDelete
	{
		(int? ReturnCode, string Infobar) JobMaterialsPreDeleteSp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Infobar);
	}
}

