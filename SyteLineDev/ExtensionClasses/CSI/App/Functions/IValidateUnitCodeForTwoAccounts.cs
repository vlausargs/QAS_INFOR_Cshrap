//PROJECT NAME: Data
//CLASS NAME: IValidateUnitCodeForTwoAccounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateUnitCodeForTwoAccounts
	{
		(int? ReturnCode,
			string Unit1Msg,
			string Unit2Msg,
			string Unit3Msg,
			string Unit4Msg,
			int? Unit1Flag,
			int? Unit2Flag,
			int? Unit3Flag,
			int? Unit4Flag) ValidateUnitCodeForTwoAccountsSp(
			string TargetAccount,
			string CompareAccount,
			string Unit1Msg,
			string Unit2Msg,
			string Unit3Msg,
			string Unit4Msg,
			int? Unit1Flag,
			int? Unit2Flag,
			int? Unit3Flag,
			int? Unit4Flag);
	}
}

