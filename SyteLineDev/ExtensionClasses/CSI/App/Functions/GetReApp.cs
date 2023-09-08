//PROJECT NAME: Data
//CLASS NAME: GetReApp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetReApp : IGetReApp
	{
		readonly IApplicationDB appDB;
		
		public GetReApp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PReApp,
			string POpenType) GetReAppSp(
			string PCustNum,
			int? PCheckNum,
			int? PReApp,
			string POpenType)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			FlagNyType _PReApp = PReApp;
			LongListType _POpenType = POpenType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetReAppSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReApp", _PReApp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReApp = _PReApp;
				POpenType = _POpenType;
				
				return (Severity, PReApp, POpenType);
			}
		}
	}
}
