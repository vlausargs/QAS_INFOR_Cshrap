//PROJECT NAME: Data
//CLASS NAME: ISubstute.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISubstute
	{
		(int? ReturnCode,
			string POut) SubstuteSp(
			string PFmt,
			string PArgs,
			string POut,
			int? ConvertBlank = 0);
	}
}

