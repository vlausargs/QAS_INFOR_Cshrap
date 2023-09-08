//PROJECT NAME: Production
//CLASS NAME: IGetProjMat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IGetProjMat
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetProjMatSp(string ProjNum,
		int? TaskNum);
	}
}

