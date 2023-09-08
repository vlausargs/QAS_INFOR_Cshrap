//PROJECT NAME: Production
//CLASS NAME: IProjcostdetailFcstRol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjcostdetailFcstRol
	{
		(int? ReturnCode,
			string Infobar) ProjcostdetailFcstRolSp(
			string PProjNum,
			int? PTaskNum,
			int? PMatlSeq,
			string PCostCode,
			string PIUDFlag,
			decimal? CostChange,
			DateTime? PDueDate,
			string PCostCodeType,
			string Infobar);
	}
}

