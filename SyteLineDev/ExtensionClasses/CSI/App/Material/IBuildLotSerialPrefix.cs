//PROJECT NAME: Material
//CLASS NAME: IBuildLotSerialPrefix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IBuildLotSerialPrefix
	{
		string BuildLotSerialPrefixFn(
			string ItemPrefix,
			string ParmsPrefix,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Site);
	}
}

