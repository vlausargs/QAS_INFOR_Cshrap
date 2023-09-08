//PROJECT NAME: Production
//CLASS NAME: ShiftSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ShiftSave : IShiftSave
	{
		readonly IApplicationDB appDB;
		
		
		public ShiftSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ShiftSaveSp(string ShiftId,
		string Descr,
		int? SDay,
		string STime,
		int? EDay,
		string ETime,
		string MustCompFg,
		string OverrunFg,
		int? UpdateFlag,
		Guid? RowPointer,
		int? AltNo)
		{
			ApsShiftType _ShiftId = ShiftId;
			ApsDescriptType _Descr = Descr;
			ApsDayOrdinalType _SDay = SDay;
			ApsTimeStrType _STime = STime;
			ApsDayOrdinalType _EDay = EDay;
			ApsTimeStrType _ETime = ETime;
			ApsFlagType _MustCompFg = MustCompFg;
			ApsFlagType _OverrunFg = OverrunFg;
			ListYesNoType _UpdateFlag = UpdateFlag;
			RowPointerType _RowPointer = RowPointer;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShiftSaveSp";
				
				appDB.AddCommandParameter(cmd, "ShiftId", _ShiftId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDay", _SDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STime", _STime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDay", _EDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETime", _ETime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MustCompFg", _MustCompFg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverrunFg", _OverrunFg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateFlag", _UpdateFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
