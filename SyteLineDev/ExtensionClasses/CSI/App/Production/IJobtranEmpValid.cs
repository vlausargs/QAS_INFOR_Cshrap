//PROJECT NAME: Production
//CLASS NAME: IJobtranEmpValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranEmpValid
	{
		(int? ReturnCode, string OutShift,
		string OutEmpName,
		decimal? OutPrRate,
		decimal? OutJobRate,
		string PromptMsg,
		string PromptButtons) JobtranEmpValidSp(string EmpNum,
		string PayRate,
		DateTime? TransDate,
		string OutShift,
		string OutEmpName,
		decimal? OutPrRate,
		decimal? OutJobRate,
		string PromptMsg,
		string PromptButtons);
	}
}

