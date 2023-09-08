//PROJECT NAME: Data
//CLASS NAME: App_OnInboundBodProcessed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_OnInboundBodProcessed : IApp_OnInboundBodProcessed
	{
		readonly IApplicationDB appDB;
		
		public App_OnInboundBodProcessed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? App_OnInboundBodProcessedSp(
			string bodNoun,
			string bodVerb,
			string bodXml,
			int? success,
			string failureMessage)
		{
			NameType _bodNoun = bodNoun;
			NameType _bodVerb = bodVerb;
			StringType _bodXml = bodXml;
			FlagNyType _success = success;
			InfobarType _failureMessage = failureMessage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_OnInboundBodProcessedSp";
				
				appDB.AddCommandParameter(cmd, "bodNoun", _bodNoun, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bodVerb", _bodVerb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bodXml", _bodXml, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "success", _success, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "failureMessage", _failureMessage, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
