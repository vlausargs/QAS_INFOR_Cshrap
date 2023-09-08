//PROJECT NAME: Data
//CLASS NAME: IApplyFeatTemplSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApplyFeatTempl
	{
		string ApplyFeatTemplSp(
			string FeatStr,
			string FeatTempl);
	}
}

