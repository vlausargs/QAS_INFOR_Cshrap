//PROJECT NAME: Production
//CLASS NAME: IPmfGetFMSpecType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetFMSpecType
	{
		Guid? PmfGetFMSpecTypeFn(
			Guid? FmRp,
			int? RevType,
			int? SpecificRev);
	}
}

