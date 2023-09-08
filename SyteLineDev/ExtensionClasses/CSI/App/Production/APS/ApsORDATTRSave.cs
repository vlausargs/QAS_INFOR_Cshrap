//PROJECT NAME: Production
//CLASS NAME: ApsORDATTRSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsORDATTRSave : IApsORDATTRSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsORDATTRSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsORDATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string ORDERID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsAttribType _ATTID = ATTID;
			ApsAttvalType _ATTVALUE = ATTVALUE;
			ApsOrderType _ORDERID = ORDERID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsORDATTRSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ATTID", _ATTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ATTVALUE", _ATTVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
