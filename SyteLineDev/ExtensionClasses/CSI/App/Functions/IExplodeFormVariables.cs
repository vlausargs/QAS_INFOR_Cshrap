//PROJECT NAME: Data
//CLASS NAME: IExplodeFormVariables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IExplodeFormVariables
	{
		string ExplodeFormVariablesFn(
			int? FormID,
			string Text,
			int? CalledFrom);
	}
}

