//PROJECT NAME: CSICustomer
//CLASS NAME: RmaLineItemRmaLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRmaLineItemRmaLoad
	{
		int RmaLineItemRmaLoadSp(string RmaNum,
		                         ref DateTime? RDate,
		                         ref string RStatus,
		                         ref string RCustNum,
		                         ref string RCurrency,
		                         ref string RCustName,
		                         ref string RCurrAmountFormat,
		                         ref string RCurrCstPrcFormat,
		                         ref string TransNat,
		                         ref string TrnDesc,
		                         ref string TransNat2,
		                         ref string Trn2Desc,
		                         ref string Delterm,
		                         ref string DeltermDesc,
		                         ref string ProcessInd,
		                         ref string Pricecode,
		                         ref string Infobar);
	}
	
	public class RmaLineItemRmaLoad : IRmaLineItemRmaLoad
	{
		readonly IApplicationDB appDB;
		
		public RmaLineItemRmaLoad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RmaLineItemRmaLoadSp(string RmaNum,
		                                ref DateTime? RDate,
		                                ref string RStatus,
		                                ref string RCustNum,
		                                ref string RCurrency,
		                                ref string RCustName,
		                                ref string RCurrAmountFormat,
		                                ref string RCurrCstPrcFormat,
		                                ref string TransNat,
		                                ref string TrnDesc,
		                                ref string TransNat2,
		                                ref string Trn2Desc,
		                                ref string Delterm,
		                                ref string DeltermDesc,
		                                ref string ProcessInd,
		                                ref string Pricecode,
		                                ref string Infobar)
		{
			RmaNumType _RmaNum = RmaNum;
			DateType _RDate = RDate;
			RmaStatusType _RStatus = RStatus;
			CustNumType _RCustNum = RCustNum;
			CurrCodeType _RCurrency = RCurrency;
			NameType _RCustName = RCustName;
			InputMaskType _RCurrAmountFormat = RCurrAmountFormat;
			InputMaskType _RCurrCstPrcFormat = RCurrCstPrcFormat;
			TransNatType _TransNat = TransNat;
			DescriptionType _TrnDesc = TrnDesc;
			TransNatType _TransNat2 = TransNat2;
			DescriptionType _Trn2Desc = Trn2Desc;
			DeltermType _Delterm = Delterm;
			DescriptionType _DeltermDesc = DeltermDesc;
			ProcessIndType _ProcessInd = ProcessInd;
			PriceCodeType _Pricecode = Pricecode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaLineItemRmaLoadSp";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RDate", _RDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RStatus", _RStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCustNum", _RCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCurrency", _RCurrency, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCustName", _RCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCurrAmountFormat", _RCurrAmountFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCurrCstPrcFormat", _RCurrCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnDesc", _TrnDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Trn2Desc", _Trn2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeltermDesc", _DeltermDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RDate = _RDate;
				RStatus = _RStatus;
				RCustNum = _RCustNum;
				RCurrency = _RCurrency;
				RCustName = _RCustName;
				RCurrAmountFormat = _RCurrAmountFormat;
				RCurrCstPrcFormat = _RCurrCstPrcFormat;
				TransNat = _TransNat;
				TrnDesc = _TrnDesc;
				TransNat2 = _TransNat2;
				Trn2Desc = _Trn2Desc;
				Delterm = _Delterm;
				DeltermDesc = _DeltermDesc;
				ProcessInd = _ProcessInd;
				Pricecode = _Pricecode;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
