//PROJECT NAME: Data
//CLASS NAME: IEcnMassI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEcnMassI
	{
		(int? ReturnCode,
			string Infobar) EcnMassISp(
			int? CurEcnNum,
			int? CurEcnLine,
			string CurMatl,
			string SubMatl,
			decimal? SubQty,
			string SubUM,
			string Action,
			string UpdateType,
			DateTime? EffectDate,
			string EcnGroup,
			string EcnStat,
			Guid? JobmatlRP,
			Guid? JobRP,
			Guid? ItemRP,
			string Infobar);
	}
}

