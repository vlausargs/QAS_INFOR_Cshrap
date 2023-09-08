//PROJECT NAME: Data
//CLASS NAME: IQueryRuntimeIDODefinition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IQueryRuntimeIDODefinition
	{
		int? QueryRuntimeIDODefinitionSp(
			string Name);
	}
}

