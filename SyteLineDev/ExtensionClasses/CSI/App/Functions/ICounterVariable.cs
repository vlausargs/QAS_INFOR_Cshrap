//PROJECT NAME: Data
//CLASS NAME: ICounterVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICounterVariable
	{
		(int? ReturnCode,
			int? VariableValue) CounterVariableSp(
			string VariableName,
			int? VariableValue,
			int? Step = 1);
	}
}

