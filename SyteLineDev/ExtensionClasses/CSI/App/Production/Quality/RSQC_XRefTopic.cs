//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefTopic.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefTopic : IRSQC_XRefTopic
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_XRefTopic(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_topic_num) RSQC_XRefTopicSp(string i_topic,
		int? i_priority,
		int? o_topic_num)
		{
			StringType _i_topic = i_topic;
			QCIntegerType _i_priority = i_priority;
			QCRcvrNumType _o_topic_num = o_topic_num;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_XRefTopicSp";
				
				appDB.AddCommandParameter(cmd, "i_topic", _i_topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_priority", _i_priority, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_topic_num", _o_topic_num, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_topic_num = _o_topic_num;
				
				return (Severity, o_topic_num);
			}
		}
	}
}
