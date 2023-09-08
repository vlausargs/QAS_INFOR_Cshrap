//PROJECT NAME: Data
//CLASS NAME: DepPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DepPost : IDepPost
	{
		readonly IApplicationDB appDB;
		
		public DepPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DepPostSp(
			DateTime? pCreateDate,
			int? pCreateSeq,
			DateTime? pSTransDate,
			DateTime? pETransDate)
		{
			CurrentDateType _pCreateDate = pCreateDate;
			GenericNoType _pCreateSeq = pCreateSeq;
			CurrentDateType _pSTransDate = pSTransDate;
			CurrentDateType _pETransDate = pETransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DepPostSp";
				
				appDB.AddCommandParameter(cmd, "pCreateDate", _pCreateDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateSeq", _pCreateSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSTransDate", _pSTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pETransDate", _pETransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
