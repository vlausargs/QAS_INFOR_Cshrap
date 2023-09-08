//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTInitialize.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTTInitialize
	{
		int FTTTInitializeSp(string ERPString,
		                     ref Guid? ReturnSessionID,
		                     ref int? ReturnHeaderRowCount,
		                     ref string Infobar);
	}
	
	public class FTTTInitialize : IFTTTInitialize
	{
		readonly IApplicationDB appDB;
		
		public FTTTInitialize(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTTInitializeSp(string ERPString,
		                            ref Guid? ReturnSessionID,
		                            ref int? ReturnHeaderRowCount,
		                            ref string Infobar)
		{
			StringType _ERPString = ERPString;
			RowPointerType _ReturnSessionID = ReturnSessionID;
			IntType _ReturnHeaderRowCount = ReturnHeaderRowCount;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTTInitializeSp";
				
				appDB.AddCommandParameter(cmd, "ERPString", _ERPString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnSessionID", _ReturnSessionID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnHeaderRowCount", _ReturnHeaderRowCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReturnSessionID = _ReturnSessionID;
				ReturnHeaderRowCount = _ReturnHeaderRowCount;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
