//PROJECT NAME: Production
//CLASS NAME: IEngWBPsSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEngWBPsSave
	{
		int? EngWBPsSaveSp(int? InsertFlag,
		string PsNum,
		string PsStatus,
		string PsDescription,
		string Item,
		string Whse,
		string Revision);
	}
}

