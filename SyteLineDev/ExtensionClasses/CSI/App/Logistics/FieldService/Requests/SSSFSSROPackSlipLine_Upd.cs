//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLine_Upd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipLine_Upd
	{
		(int? ReturnCode, string Infobar) SSSFSSROPackSlipLine_UpdSp(byte? DerSelected = (byte)0,
		Guid? RowPointer = null,
		int? PackNum = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		Guid? DerHdrRowPointer = null,
		string DocNum = null,
		string Infobar = null);
	}
	
	public class SSSFSSROPackSlipLine_Upd : ISSSFSSROPackSlipLine_Upd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROPackSlipLine_Upd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROPackSlipLine_UpdSp(byte? DerSelected = (byte)0,
		Guid? RowPointer = null,
		int? PackNum = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		Guid? DerHdrRowPointer = null,
		string DocNum = null,
		string Infobar = null)
		{
			ListYesNoType _DerSelected = DerSelected;
			RowPointerType _RowPointer = RowPointer;
			PackNumType _PackNum = PackNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			RowPointerType _DerHdrRowPointer = DerHdrRowPointer;
			DocumentNumType _DocNum = DocNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROPackSlipLine_UpdSp";
				
				appDB.AddCommandParameter(cmd, "DerSelected", _DerSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerHdrRowPointer", _DerHdrRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocNum", _DocNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
