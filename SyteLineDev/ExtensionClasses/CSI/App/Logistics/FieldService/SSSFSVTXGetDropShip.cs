//PROJECT NAME: Logistics
//CLASS NAME: SSSFSVTXGetDropShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSVTXGetDropShip : ISSSFSVTXGetDropShip
	{
		readonly IApplicationDB appDB;
		
		public SSSFSVTXGetDropShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string DropType,
			string DropNum,
			int? DropSeq,
			string Infobar) SSSFSVTXGetDropShipSp(
			string Type,
			Guid? RowPtr,
			string DropType,
			string DropNum,
			int? DropSeq,
			string Infobar)
		{
			StringType _Type = Type;
			RowPointerType _RowPtr = RowPtr;
			FSDropShipTypeType _DropType = DropType;
			FSPartnerType _DropNum = DropNum;
			DropSeqType _DropSeq = DropSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSVTXGetDropShipSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPtr", _RowPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropType", _DropType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropNum", _DropNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DropType = _DropType;
				DropNum = _DropNum;
				DropSeq = _DropSeq;
				Infobar = _Infobar;
				
				return (Severity, DropType, DropNum, DropSeq, Infobar);
			}
		}
	}
}
