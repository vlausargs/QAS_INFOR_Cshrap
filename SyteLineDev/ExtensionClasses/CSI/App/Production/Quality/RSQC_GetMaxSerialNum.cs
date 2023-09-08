//PROJECT NAME: Production
//CLASS NAME: RSQC_GetMaxSerialNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetMaxSerialNum : IRSQC_GetMaxSerialNum
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetMaxSerialNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SerNum) RSQC_GetMaxSerialNumSp(string SerNumPrefix,
		string Site = null,
		string SerNum = null)
		{
			SerialPrefixType _SerNumPrefix = SerNumPrefix;
			SiteType _Site = Site;
			SerNumType _SerNum = SerNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetMaxSerialNumSp";
				
				appDB.AddCommandParameter(cmd, "SerNumPrefix", _SerNumPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerNum = _SerNum;
				
				return (Severity, SerNum);
			}
		}
	}
}
