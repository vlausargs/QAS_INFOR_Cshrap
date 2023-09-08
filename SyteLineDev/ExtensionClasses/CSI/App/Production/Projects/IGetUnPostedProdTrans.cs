//PROJECT NAME: Production
//CLASS NAME: IGetUnPostedProdTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IGetUnPostedProdTrans
	{
		(int? ReturnCode, int? UnpostedDCSFC,
		int? UnpostedDCJM,
		int? UnpostedDCJMRcpt,
		int? UnpostedJobLaborTrans,
		int? UnpostedDCJIT,
		int? UnpostedDCPS,
		int? UnpostedDCPSScrap,
		int? UnpostedJobMatlTrans,
		int? UnpostedDCSFCWCLabor,
		int? UnpostedDCSFCWCMachine,
		int? UnpostedDCWC) GetUnPostedProdTransSp(int? UnpostedDCSFC,
		int? UnpostedDCJM,
		int? UnpostedDCJMRcpt,
		int? UnpostedJobLaborTrans,
		int? UnpostedDCJIT,
		int? UnpostedDCPS,
		int? UnpostedDCPSScrap,
		int? UnpostedJobMatlTrans,
		int? UnpostedDCSFCWCLabor,
		int? UnpostedDCSFCWCMachine,
		int? UnpostedDCWC);
	}
}

