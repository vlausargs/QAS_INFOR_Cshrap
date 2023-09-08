//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProcessLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSProcessLevel : ISSSFSProcessLevel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSProcessLevel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Seq,
			string Infobar) SSSFSProcessLevelSp(
			string SerNum,
			string SerItem,
			int? tlevel,
			int? level,
			int? compid,
			DateTime? t_date,
			int? t_inc_warr,
			int? Seq,
			string Infobar)
		{
			SerNumType _SerNum = SerNum;
			ItemType _SerItem = SerItem;
			GenericIntType _tlevel = tlevel;
			GenericIntType _level = level;
			FSCompIdType _compid = compid;
			DateType _t_date = t_date;
			ListYesNoType _t_inc_warr = t_inc_warr;
			GenericIntType _Seq = Seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSProcessLevelSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerItem", _SerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tlevel", _tlevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "level", _level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "compid", _compid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_date", _t_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "t_inc_warr", _t_inc_warr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Seq = _Seq;
				Infobar = _Infobar;
				
				return (Severity, Seq, Infobar);
			}
		}
	}
}
