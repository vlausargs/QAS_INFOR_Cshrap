//PROJECT NAME: Production
//CLASS NAME: IApsMATLPPSDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLPPSDel
	{
		int? ApsMATLPPSDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

