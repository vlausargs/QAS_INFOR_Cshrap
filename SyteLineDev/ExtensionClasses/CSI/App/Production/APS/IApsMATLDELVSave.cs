//PROJECT NAME: Production
//CLASS NAME: IApsMATLDELVSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLDELVSave
	{
		int? ApsMATLDELVSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string DESCR,
		DateTime? DELVDATE,
		string MATERIALID,
		string AMOUNT,
		int? CATEGORY,
		int? FLAGS,
		string CUSTOMER);
	}
}

