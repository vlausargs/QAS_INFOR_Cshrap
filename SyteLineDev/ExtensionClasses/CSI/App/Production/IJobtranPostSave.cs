//PROJECT NAME: Production
//CLASS NAME: IJobtranPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranPostSave
	{
		int? JobtranPostSaveSp(string Job,
		int? Suffix,
		int? OperNum,
		string Wc);
	}
}

