//PROJECT NAME: Data
//CLASS NAME: QueueSetUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class QueueSetUp : IQueueSetUp
	{
		readonly IApplicationDB appDB;
		
		public QueueSetUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? QueueSetUpSP(
			string Class,
			string QueueType,
			string strCategory)
		{
			StringType _Class = Class;
			StringType _QueueType = QueueType;
			StringType _strCategory = strCategory;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "QueueSetUpSP";
				
				appDB.AddCommandParameter(cmd, "Class", _Class, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueueType", _QueueType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "strCategory", _strCategory, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
