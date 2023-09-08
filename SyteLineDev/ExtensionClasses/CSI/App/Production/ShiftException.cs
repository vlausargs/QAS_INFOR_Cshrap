//PROJECT NAME: Production
//CLASS NAME: ShiftException.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ShiftException : IShiftException
	{
		readonly IApplicationDB appDB;
		
		
		public ShiftException(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CounterItem,
		string Infobar) ShiftExceptionSp(string FromResourceGroup,
		string ToResourceGroup,
		string ExceptionDescr,
		DateTime? StartDate,
		DateTime? EndDate,
		string Work,
		string Shift,
		int? AltNo,
		int? CounterItem,
		string Infobar)
		{
			ApsResgroupType _FromResourceGroup = FromResourceGroup;
			ApsResgroupType _ToResourceGroup = ToResourceGroup;
			ApsDescriptType _ExceptionDescr = ExceptionDescr;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			ApsFlagType _Work = Work;
			ApsShiftType _Shift = Shift;
			ApsAltNoType _AltNo = AltNo;
			IntType _CounterItem = CounterItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShiftExceptionSp";
				
				appDB.AddCommandParameter(cmd, "FromResourceGroup", _FromResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToResourceGroup", _ToResourceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionDescr", _ExceptionDescr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Work", _Work, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CounterItem = _CounterItem;
				Infobar = _Infobar;
				
				return (Severity, CounterItem, Infobar);
			}
		}
	}
}
