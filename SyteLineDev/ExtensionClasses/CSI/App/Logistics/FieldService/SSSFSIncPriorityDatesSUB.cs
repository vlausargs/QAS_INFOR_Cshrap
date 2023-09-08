//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncPriorityDatesSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncPriorityDatesSub : ISSSFSIncPriorityDatesSub
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncPriorityDatesSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? CalcDateTime,
			string Infobar) SSSFSIncPriorityDatesSubSp(
			DateTime? IncDateTime,
			int? ParmDays,
			decimal? ParmHrs,
			string DateBasis,
			string CustNum,
			string SerNum,
			string Item,
			DateTime? CalcDateTime,
			string Infobar)
		{
			DateTimeType _IncDateTime = IncDateTime;
			FSDurationType _ParmDays = ParmDays;
			MachineHourType _ParmHrs = ParmHrs;
			FSPriorDateBasisType _DateBasis = DateBasis;
			CustNumType _CustNum = CustNum;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			DateTimeType _CalcDateTime = CalcDateTime;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncPriorityDatesSubSp";
				
				appDB.AddCommandParameter(cmd, "IncDateTime", _IncDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmDays", _ParmDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmHrs", _ParmHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateBasis", _DateBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcDateTime", _CalcDateTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CalcDateTime = _CalcDateTime;
				Infobar = _Infobar;
				
				return (Severity, CalcDateTime, Infobar);
			}
		}
	}
}
