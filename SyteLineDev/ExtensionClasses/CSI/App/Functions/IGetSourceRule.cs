//PROJECT NAME: Data
//CLASS NAME: IGetSourceRule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSourceRule
	{
		string GetSourceRuleFn(
			string Item,
			DateTime? EffDate);
	}
}

