//PROJECT NAME: Production
//CLASS NAME: IValidateJobDemandId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobDemandId
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string Item,
		decimal? QtyReleased,
		DateTime? EndDate,
		string PSNum,
		string Ppjob) ValidateJobDemandIdSp(string PDemandType,
		string DemandID,
		string Job,
		int? Suffix,
		string Item,
		decimal? QtyReleased,
		DateTime? EndDate,
		string PSNum,
		string Ppjob);
	}
}

