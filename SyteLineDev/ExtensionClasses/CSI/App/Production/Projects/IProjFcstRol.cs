//PROJECT NAME: Production
//CLASS NAME: IProjFcstRol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjFcstRol
	{
		(int? ReturnCode,
			string Infobar) ProjFcstRolSp(
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

