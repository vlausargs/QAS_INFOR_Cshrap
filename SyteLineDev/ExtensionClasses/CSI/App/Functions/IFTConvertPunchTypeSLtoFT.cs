//PROJECT NAME: Data
//CLASS NAME: IFTConvertPunchTypeSLtoFT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTConvertPunchTypeSLtoFT
	{
		int? FTConvertPunchTypeSLtoFTFn(
			int? PunchType = null);
	}
}

