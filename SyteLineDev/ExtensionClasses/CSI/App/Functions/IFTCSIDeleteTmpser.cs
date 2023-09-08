//PROJECT NAME: Data
//CLASS NAME: IFTCSIDeleteTmpser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTCSIDeleteTmpser
	{
		(int? ReturnCode,
			string Infobar) FTCSIDeleteTmpserSp(
			long? TimeBeforePurgeThrough,
			string Infobar);
	}
}

