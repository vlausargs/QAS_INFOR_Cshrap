//PROJECT NAME: Production
//CLASS NAME: IJrtRgrpUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJrtRgrpUpd
	{
		int? JrtRgrpUpdSp(Guid? Rowp,
		string job,
		int? suffix,
		int? oper_num,
		string rgid,
		int? qty_resources,
		string resactn,
		int? sequence);
	}
}

