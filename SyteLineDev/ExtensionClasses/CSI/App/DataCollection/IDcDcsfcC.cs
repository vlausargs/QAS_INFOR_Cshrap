//PROJECT NAME: DataCollection
//CLASS NAME: IDcDcsfcC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcDcsfcC
	{
		int? DcDcsfcCSp(Guid? JobtranRowPointer);
	}
}

