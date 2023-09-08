//PROJECT NAME: Production
//CLASS NAME: IApsSHIFTEXDIDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSHIFTEXDIDel
	{
		int? ApsSHIFTEXDIDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

