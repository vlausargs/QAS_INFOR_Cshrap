//PROJECT NAME: Production
//CLASS NAME: IJobtranPreSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranPreSave
	{
		(int? ReturnCode, string Infobar) JobtranPreSaveSp(string Job,
		int? Suffix,
		int? OperNum,
		string Infobar);
	}
}

