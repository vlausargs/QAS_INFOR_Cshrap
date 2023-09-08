//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcLineToBill.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcLineToBill : ISSSFSConInvSubCalcLineToBill
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCalcLineToBill(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSConInvSubCalcLineToBillSp(
			Guid? SessionId,
			string iContract,
			int? iContLine,
			DateTime? iBillingThruDate,
			string Infobar,
			string FSParmsContSurchargeAcct = null,
			string FSParmsContSurchargeAcctUnit1 = null,
			string FSParmsContSurchargeAcctUnit2 = null,
			string FSParmsContSurchargeAcctUnit3 = null,
			string FSParmsContSurchargeAcctUnit4 = null,
			int? ContractFound = null,
			DateTime? ContractRenewalMoDay = null,
			string CurrCode = null,
			int? CurrPlaces = null)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _iContract = iContract;
			FSContLineType _iContLine = iContLine;
			DateType _iBillingThruDate = iBillingThruDate;
			InfobarType _Infobar = Infobar;
			AcctType _FSParmsContSurchargeAcct = FSParmsContSurchargeAcct;
			UnitCode1Type _FSParmsContSurchargeAcctUnit1 = FSParmsContSurchargeAcctUnit1;
			UnitCode2Type _FSParmsContSurchargeAcctUnit2 = FSParmsContSurchargeAcctUnit2;
			UnitCode3Type _FSParmsContSurchargeAcctUnit3 = FSParmsContSurchargeAcctUnit3;
			UnitCode4Type _FSParmsContSurchargeAcctUnit4 = FSParmsContSurchargeAcctUnit4;
			ListYesNoType _ContractFound = ContractFound;
			DateType _ContractRenewalMoDay = ContractRenewalMoDay;
			CurrCodeType _CurrCode = CurrCode;
			DecimalPlacesType _CurrPlaces = CurrPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCalcLineToBillSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iContract", _iContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iContLine", _iContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillingThruDate", _iBillingThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FSParmsContSurchargeAcct", _FSParmsContSurchargeAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSParmsContSurchargeAcctUnit1", _FSParmsContSurchargeAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSParmsContSurchargeAcctUnit2", _FSParmsContSurchargeAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSParmsContSurchargeAcctUnit3", _FSParmsContSurchargeAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSParmsContSurchargeAcctUnit4", _FSParmsContSurchargeAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractFound", _ContractFound, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractRenewalMoDay", _ContractRenewalMoDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrPlaces", _CurrPlaces, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
