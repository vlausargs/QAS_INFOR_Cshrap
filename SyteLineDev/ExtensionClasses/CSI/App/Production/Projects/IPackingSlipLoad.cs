//PROJECT NAME: Production
//CLASS NAME: IPackingSlipLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IPackingSlipLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PackingSlipLoadSp(string TPckCall,
		string ProjNum,
		string CustNum,
		int? FromTaskNum,
		int? ToTaskNum,
		int? FromSeq,
		int? ToSeq,
		string FilterString);
	}
}

