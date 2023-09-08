//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroMiscRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroMiscRate : ISSSFSSroMiscRate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSroMiscRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? oUnitPrice,
		string Infobar) SSSFSSroMiscRateSp(string iTransType,
		string iSroNum,
		int? iSroLine,
		int? iSroOper,
		string iBillCode,
		DateTime? iTransDate,
		string iPartner,
		string iMiscCode,
		decimal? iUnitCost,
		decimal? iQty,
		decimal? oUnitPrice,
		string Infobar)
		{
			StringType _iTransType = iTransType;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			FSSROBillCodeType _iBillCode = iBillCode;
			DateType _iTransDate = iTransDate;
			FSPartnerType _iPartner = iPartner;
			FSMiscCodeType _iMiscCode = iMiscCode;
			CostPrcType _iUnitCost = iUnitCost;
			QtyUnitType _iQty = iQty;
			CostPrcType _oUnitPrice = oUnitPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroMiscRateSp";
				
				appDB.AddCommandParameter(cmd, "iTransType", _iTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillCode", _iBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPartner", _iPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMiscCode", _iMiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUnitCost", _iUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oUnitPrice", _oUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oUnitPrice = _oUnitPrice;
				Infobar = _Infobar;
				
				return (Severity, oUnitPrice, Infobar);
			}
		}
	}
}
