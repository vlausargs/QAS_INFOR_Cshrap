//PROJECT NAME: Production
//CLASS NAME: IApsMATLPBOMSDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLPBOMSDel
	{
		int? ApsMATLPBOMSDelSp(int? AltNo,
		Guid? RowPointer);
	}
}

