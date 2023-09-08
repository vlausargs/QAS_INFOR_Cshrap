//PROJECT NAME: Material
//CLASS NAME: IEcniDeleteGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IEcniDeleteGroup
	{
		int? EcniDeleteGroupSp(string InGroup,
		string InDelStd,
		string InDelJob,
		string InDelEst);
	}
}

