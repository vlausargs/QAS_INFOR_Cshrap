//PROJECT NAME: Production
//CLASS NAME: IJobDelPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobDelPostSave
	{
		(int? ReturnCode,
		string Infobar) JobDelPostSaveSp(
			string Infobar);
	}
}

