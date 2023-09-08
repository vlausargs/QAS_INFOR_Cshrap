//PROJECT NAME: Production
//CLASS NAME: ApsMATLATTRSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLATTRSave : IApsMATLATTRSave
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMATLATTRSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMATLATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string MATERIALID)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			ApsAltNoType _AltNo = AltNo;
			ApsAttribType _ATTID = ATTID;
			ApsAttvalType _ATTVALUE = ATTVALUE;
			ApsMaterialType _MATERIALID = MATERIALID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMATLATTRSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ATTID", _ATTID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ATTVALUE", _ATTVALUE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MATERIALID", _MATERIALID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
