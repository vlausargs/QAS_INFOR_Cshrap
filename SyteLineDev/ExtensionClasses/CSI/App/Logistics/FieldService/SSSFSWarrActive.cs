//PROJECT NAME: Logistics
//CLASS NAME: SSSFSWarrActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSWarrActive : ISSSFSWarrActive
	{
		readonly IApplicationDB appDB;
		
		public SSSFSWarrActive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OActive,
			string Infobar) SSSFSWarrActiveSp(
			int? ICompId,
			string IWarrCode,
			DateTime? IDate,
			int? IMeter,
			int? OActive,
			string Infobar)
		{
			FSCompIdType _ICompId = ICompId;
			FSWarrCodeType _IWarrCode = IWarrCode;
			CurrentDateType _IDate = IDate;
			GenericNoType _IMeter = IMeter;
			FlagNyType _OActive = OActive;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSWarrActiveSp";
				
				appDB.AddCommandParameter(cmd, "ICompId", _ICompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IWarrCode", _IWarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IDate", _IDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IMeter", _IMeter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OActive", _OActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OActive = _OActive;
				Infobar = _Infobar;
				
				return (Severity, OActive, Infobar);
			}
		}
	}
}
