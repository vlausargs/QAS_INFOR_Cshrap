//PROJECT NAME: Data
//CLASS NAME: QueueSetDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class QueueSetDel : IQueueSetDel
	{
		readonly IApplicationDB appDB;
		
		public QueueSetDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? QueueSetDelSP(
			string Class,
			string strCategory)
		{
			StringType _Class = Class;
			StringType _strCategory = strCategory;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "QueueSetDelSP";
				
				appDB.AddCommandParameter(cmd, "Class", _Class, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "strCategory", _strCategory, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
