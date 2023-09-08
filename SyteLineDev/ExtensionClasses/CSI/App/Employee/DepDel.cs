//PROJECT NAME: CSIEmployee
//CLASS NAME: DepDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IDepDel
	{
		(int? ReturnCode, string Infobar) DepDelSp(DateTime? ExEndTransDate,
		byte? ExOptdfDeleteTape = (byte)0,
		string ExOptdfEmplType = null,
		string Infobar = null,
		short? EndTransDateOffset = null);
	}
	
	public class DepDel : IDepDel
	{
		readonly IApplicationDB appDB;
		
		public DepDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DepDelSp(DateTime? ExEndTransDate,
		byte? ExOptdfDeleteTape = (byte)0,
		string ExOptdfEmplType = null,
		string Infobar = null,
		short? EndTransDateOffset = null)
		{
			DateType _ExEndTransDate = ExEndTransDate;
			FlagNyType _ExOptdfDeleteTape = ExOptdfDeleteTape;
			LongStringType _ExOptdfEmplType = ExOptdfEmplType;
			InfobarType _Infobar = Infobar;
			DateOffsetType _EndTransDateOffset = EndTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DepDelSp";
				
				appDB.AddCommandParameter(cmd, "ExEndTransDate", _ExEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfDeleteTape", _ExOptdfDeleteTape, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndTransDateOffset", _EndTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
