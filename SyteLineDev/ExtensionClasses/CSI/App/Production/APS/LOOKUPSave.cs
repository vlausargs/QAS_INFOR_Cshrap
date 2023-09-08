//PROJECT NAME: Production
//CLASS NAME: LOOKUPSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class LOOKUPSave : ILOOKUPSave
	{
		readonly IApplicationDB appDB;
		
		
		public LOOKUPSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LOOKUPSaveSp(int? InsertFlag,
		int? AltNo,
		string TABID,
		string INDEX1,
		string INDEX2,
		decimal? VAL)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsLtableType _TABID = TABID;
			ApsLtabvalType _INDEX1 = INDEX1;
			ApsLtabvalType _INDEX2 = INDEX2;
			ApsFloatType _VAL = VAL;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LOOKUPSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TABID", _TABID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INDEX1", _INDEX1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "INDEX2", _INDEX2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VAL", _VAL, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
