//PROJECT NAME: Data
//CLASS NAME: IGetRequirementDescription.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetRequirementDescription
	{
		string GetRequirementDescriptionFn(
			string ReqType,
			string Requirement);
	}
}

