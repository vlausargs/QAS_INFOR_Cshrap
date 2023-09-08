//PROJECT NAME: Data
//CLASS NAME: IFTConvertPunchTypeFTtoSL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTConvertPunchTypeFTtoSL
	{
		int? FTConvertPunchTypeFTtoSLFn(
			int? PunchType = null);
	}
}

