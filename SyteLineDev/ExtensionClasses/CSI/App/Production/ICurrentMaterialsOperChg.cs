//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsOperChg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsOperChg
	{
		(int? ReturnCode,
		int? MOShared,
		decimal? MOSecondsPerCycle,
		decimal? MOFormulaMatlWeight,
		string MOFormulaMatlWeightUnits,
		string InfoBar) CurrentMaterialsOperChgSp(
			string Job,
			int? Suffix,
			int? OperNum,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits,
			string InfoBar);
	}
}

