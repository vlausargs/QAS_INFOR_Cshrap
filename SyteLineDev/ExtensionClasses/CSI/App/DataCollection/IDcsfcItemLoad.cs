//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcItemLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcItemLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcsfcItemLoadSp(int? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string FilterString = null);
	}
}

