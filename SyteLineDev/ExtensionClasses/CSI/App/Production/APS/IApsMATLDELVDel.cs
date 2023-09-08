//PROJECT NAME: Production
//CLASS NAME: IApsMATLDELVDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLDELVDel
	{
		int? ApsMATLDELVDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

