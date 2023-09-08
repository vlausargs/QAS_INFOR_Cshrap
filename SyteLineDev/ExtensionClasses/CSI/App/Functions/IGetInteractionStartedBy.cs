//PROJECT NAME: Data
//CLASS NAME: IGetInteractionStartedBy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetInteractionStartedBy
	{
		string GetInteractionStartedByFn(
			decimal? InteractionId);
	}
}

