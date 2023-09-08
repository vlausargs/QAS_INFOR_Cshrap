//PROJECT NAME: Production
//CLASS NAME: RSQC_CalcCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CalcCost : IRSQC_CalcCost
	{
		readonly IApplicationDB appDB;
		
		public RSQC_CalcCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_CalcCostSp(
			string i_DocNum,
			string i_DocType)
		{
			QCDocNumType _i_DocNum = i_DocNum;
			QCDocType _i_DocType = i_DocType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CalcCostSp";
				
				appDB.AddCommandParameter(cmd, "i_DocNum", _i_DocNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_DocType", _i_DocType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
