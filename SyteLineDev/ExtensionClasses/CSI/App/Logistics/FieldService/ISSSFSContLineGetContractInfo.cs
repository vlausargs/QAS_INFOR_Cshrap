//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContLineGetContractInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContLineGetContractInfo
	{
		(int? ReturnCode, string BillingType,
		string BillingFreq,
		string ContractStatus,
		int? ContractClosed,
		string ServiceType,
		string ContractWhse,
		int? ContractProrate,
		DateTime? StartDate,
		DateTime? EndDate,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string Infobar,
		string CustPo,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string CustNum,
		int? CustSeq) SSSFSContLineGetContractInfoSp(string Contract,
		string BillingType,
		string BillingFreq,
		string ContractStatus,
		int? ContractClosed,
		string ServiceType,
		string ContractWhse,
		int? ContractProrate,
		DateTime? StartDate,
		DateTime? EndDate,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		string Infobar,
		string CustPo = null,
		string CurAmtFormat = null,
		string CurCstPrcFormat = null,
		string CustNum = null,
		int? CustSeq = 0);
	}
}

