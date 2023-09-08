//PROJECT NAME: Production
//CLASS NAME: IPmfValidateSpec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfValidateSpec
	{
		int? PmfValidateSpecSp();
	}
}

