//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContLineGetContractInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineGetContractInfo : ISSSFSContLineGetContractInfo
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSContLineGetContractInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BillingType,
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
		int? CustSeq = 0)
		{
			FSContractType _Contract = Contract;
			FSContBillTypeType _BillingType = BillingType;
			FSContBillFreqType _BillingFreq = BillingFreq;
			FSContStatType _ContractStatus = ContractStatus;
			ListYesNoType _ContractClosed = ContractClosed;
			FSContServTypeType _ServiceType = ServiceType;
			WhseType _ContractWhse = ContractWhse;
			ListYesNoType _ContractProrate = ContractProrate;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			Infobar _Infobar = Infobar;
			CustPoType _CustPo = CustPo;
			InputMaskType _CurAmtFormat = CurAmtFormat;
			InputMaskType _CurCstPrcFormat = CurCstPrcFormat;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContLineGetContractInfoSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingType", _BillingType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillingFreq", _BillingFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractStatus", _ContractStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractClosed", _ContractClosed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ServiceType", _ServiceType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractWhse", _ContractWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContractProrate", _ContractProrate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurAmtFormat", _CurAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurCstPrcFormat", _CurCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillingType = _BillingType;
				BillingFreq = _BillingFreq;
				ContractStatus = _ContractStatus;
				ContractClosed = _ContractClosed;
				ServiceType = _ServiceType;
				ContractWhse = _ContractWhse;
				ContractProrate = _ContractProrate;
				StartDate = _StartDate;
				EndDate = _EndDate;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				Infobar = _Infobar;
				CustPo = _CustPo;
				CurAmtFormat = _CurAmtFormat;
				CurCstPrcFormat = _CurCstPrcFormat;
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				
				return (Severity, BillingType, BillingFreq, ContractStatus, ContractClosed, ServiceType, ContractWhse, ContractProrate, StartDate, EndDate, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, Infobar, CustPo, CurAmtFormat, CurCstPrcFormat, CustNum, CustSeq);
			}
		}
	}
}
