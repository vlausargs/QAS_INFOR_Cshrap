//PROJECT NAME: Production
//CLASS NAME: IMO_NextAlternateSuffix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_NextAlternateSuffix
	{
		(int? ReturnCode, int? Suffix) MO_NextAlternateSuffixSp(string Item,
		int? Suffix);
	}
}

