//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTDeleteTmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTDeleteTmpser
	{
		(int? ReturnCode, string Infobar) FTDeleteTmpserSp(Guid? SessionID,
		string Infobar);
	}
	
	public class FTDeleteTmpser : IFTDeleteTmpser
	{
		readonly IApplicationDB appDB;
		
		public FTDeleteTmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTDeleteTmpserSp(Guid? SessionID,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTDeleteTmpserSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
