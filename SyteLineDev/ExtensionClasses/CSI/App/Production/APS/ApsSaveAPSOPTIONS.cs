//PROJECT NAME: Production
//CLASS NAME: ApsSaveAPSOPTIONS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSaveAPSOPTIONS : IApsSaveAPSOPTIONS
	{
		readonly IApplicationDB appDB;
		
		
		public ApsSaveAPSOPTIONS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSaveAPSOPTIONSSp(int? InsertFlag,
		int? AltNo,
		string PARAM,
		string VALUE)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsFieldType _PARAM = PARAM;
			ApsOrderType _VALUE = VALUE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSaveAPSOPTIONSSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PARAM", _PARAM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VALUE", _VALUE, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
