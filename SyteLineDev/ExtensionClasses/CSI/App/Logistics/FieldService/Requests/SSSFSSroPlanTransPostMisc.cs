//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroPlanTransPostMisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroPlanTransPostMisc : ISSSFSSroPlanTransPostMisc
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSroPlanTransPostMisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSroPlanTransPostMiscSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstQty,
		decimal? iMatlCost,
		decimal? iLbrCost,
		decimal? iFovhdCost,
		decimal? iVovhdCost,
		decimal? iOutCost,
		string UpdateStatus,
		string Infobar)
		{
			RowPointerType _iRowPointer = iRowPointer;
			StringType _iMode = iMode;
			FSPartnerType _iPartnerId = iPartnerId;
			DeptType _iDept = iDept;
			WhseType _iWhse = iWhse;
			DateType _iTransDate = iTransDate;
			DateType _iPostDate = iPostDate;
			QtyUnitType _iPstQty = iPstQty;
			CostPrcType _iMatlCost = iMatlCost;
			CostPrcType _iLbrCost = iLbrCost;
			CostPrcType _iFovhdCost = iFovhdCost;
			CostPrcType _iVovhdCost = iVovhdCost;
			CostPrcType _iOutCost = iOutCost;
			StringType _UpdateStatus = UpdateStatus;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroPlanTransPostMiscSp";
				
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPartnerId", _iPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDept", _iDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPostDate", _iPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPstQty", _iPstQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatlCost", _iMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLbrCost", _iLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFovhdCost", _iFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iVovhdCost", _iVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOutCost", _iOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateStatus", _UpdateStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
