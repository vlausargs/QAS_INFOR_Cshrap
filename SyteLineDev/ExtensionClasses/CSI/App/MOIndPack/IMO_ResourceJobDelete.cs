//PROJECT NAME: MOIndPack
//CLASS NAME: IMO_ResourceJobDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMO_ResourceJobDelete
	{
		int? MO_ResourceJobDeleteSp(int? DeleteFlag,
		string RESID);
	}
}

