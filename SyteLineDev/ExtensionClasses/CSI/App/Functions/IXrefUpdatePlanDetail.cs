//PROJECT NAME: Data
//CLASS NAME: IXrefUpdatePlanDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IXrefUpdatePlanDetail
	{
		int? XrefUpdatePlanDetailSp(
			Guid? PRowP);
	}
}

