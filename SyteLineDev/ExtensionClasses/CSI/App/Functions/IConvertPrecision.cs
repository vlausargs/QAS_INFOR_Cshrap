//PROJECT NAME: Data
//CLASS NAME: IConvertPrecision.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertPrecision
	{
		int? ConvertPrecisionFn(
			string ProgressFormat,
			int? IsCharacter,
			int? Decimals);
	}
}

