//PROJECT NAME: Logistics
//CLASS NAME: EFTImportEFTArpmntd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EFTImportEFTArpmntd : IEFTImportEFTArpmntd
	{
		readonly IApplicationDB appDB;
		
		
		public EFTImportEFTArpmntd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string AppToCustomer,
		decimal? ArpmtdForAmtApplied,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdExchRate,
		int? LineNumber,
		string Site,
		Guid? RefRowPointer,
		string Infobar) EFTImportEFTArpmntdSp(decimal? BatchId,
		int? HeaderNumber,
		string InvNum,
		decimal? DetailAmount,
		DateTime? EffectiveDate,
		string AppToCustomer,
		decimal? ArpmtdForAmtApplied,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdExchRate,
		int? LineNumber,
		string Site,
		Guid? RefRowPointer,
		string Infobar)
		{
			ARImportBatchIdType _BatchId = BatchId;
			ARImportHeaderNumType _HeaderNumber = HeaderNumber;
			InvNumType _InvNum = InvNum;
			AmountType _DetailAmount = DetailAmount;
			DateType _EffectiveDate = EffectiveDate;
			CustNumType _AppToCustomer = AppToCustomer;
			AmountType _ArpmtdForAmtApplied = ArpmtdForAmtApplied;
			AmountType _ArpmtdForDiscAmt = ArpmtdForDiscAmt;
			AmountType _ArpmtdDomAmtApplied = ArpmtdDomAmtApplied;
			AmountType _ArpmtdDomDiscAmt = ArpmtdDomDiscAmt;
			AmountType _ArpmtdExchRate = ArpmtdExchRate;
			ARImportLineNumType _LineNumber = LineNumber;
			SiteType _Site = Site;
			RowPointerType _RefRowPointer = RefRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportEFTArpmntdSp";
				
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HeaderNumber", _HeaderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailAmount", _DetailAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppToCustomer", _AppToCustomer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdForAmtApplied", _ArpmtdForAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdForDiscAmt", _ArpmtdForDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdDomAmtApplied", _ArpmtdDomAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdDomDiscAmt", _ArpmtdDomDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdExchRate", _ArpmtdExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AppToCustomer = _AppToCustomer;
				ArpmtdForAmtApplied = _ArpmtdForAmtApplied;
				ArpmtdForDiscAmt = _ArpmtdForDiscAmt;
				ArpmtdDomAmtApplied = _ArpmtdDomAmtApplied;
				ArpmtdDomDiscAmt = _ArpmtdDomDiscAmt;
				ArpmtdExchRate = _ArpmtdExchRate;
				LineNumber = _LineNumber;
				Site = _Site;
				RefRowPointer = _RefRowPointer;
				Infobar = _Infobar;
				
				return (Severity, AppToCustomer, ArpmtdForAmtApplied, ArpmtdForDiscAmt, ArpmtdDomAmtApplied, ArpmtdDomDiscAmt, ArpmtdExchRate, LineNumber, Site, RefRowPointer, Infobar);
			}
		}
	}
}
