//PROJECT NAME: Production
//CLASS NAME: ValidateMfgDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateMfgDate : IValidateMfgDate
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateMfgDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PStartDateOut,
		DateTime? PEndDateOut,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar) ValidateMfgDateSp(DateTime? PStartDateIn,
		DateTime? PEndDateIn,
		string PItem,
		decimal? PQtyReleased,
		DateTime? PStartDateOut,
		DateTime? PEndDateOut,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar,
		decimal? HrsPerDay = null)
		{
			DateType _PStartDateIn = PStartDateIn;
			DateType _PEndDateIn = PEndDateIn;
			ItemType _PItem = PItem;
			QtyUnitType _PQtyReleased = PQtyReleased;
			DateType _PStartDateOut = PStartDateOut;
			DateType _PEndDateOut = PEndDateOut;
			TicksType _PStartTick = PStartTick;
			TicksType _PEndTick = PEndTick;
			InfobarType _Infobar = Infobar;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateMfgDateSp";
				
				appDB.AddCommandParameter(cmd, "PStartDateIn", _PStartDateIn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDateIn", _PEndDateIn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReleased", _PQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDateOut", _PStartDateOut, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDateOut", _PEndDateOut, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartTick", _PStartTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndTick", _PEndTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartDateOut = _PStartDateOut;
				PEndDateOut = _PEndDateOut;
				PStartTick = _PStartTick;
				PEndTick = _PEndTick;
				Infobar = _Infobar;
				
				return (Severity, PStartDateOut, PEndDateOut, PStartTick, PEndTick, Infobar);
			}
		}
	}
}
