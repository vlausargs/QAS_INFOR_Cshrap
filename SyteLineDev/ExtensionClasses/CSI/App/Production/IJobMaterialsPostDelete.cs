//PROJECT NAME: Production
//CLASS NAME: IJobMaterialsPostDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobMaterialsPostDelete
	{
		(int? ReturnCode, string Infobar) JobMaterialsPostDeleteSp(string Job,
		int? Suffix,
		string Infobar);
	}
}

