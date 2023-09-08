//PROJECT NAME: Production
//CLASS NAME: IEngWBCopyJobRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEngWBCopyJobRef
	{
		int? EngWBCopyJobRefSp(Guid? OldRowpointer,
		Guid? NewRowpointer);
	}
}

