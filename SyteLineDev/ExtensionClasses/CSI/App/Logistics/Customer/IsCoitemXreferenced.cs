//PROJECT NAME: Logistics
//CLASS NAME: IsCoitemXreferenced.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCoitemXreferenced : IIsCoitemXreferenced
	{
		readonly IApplicationDB appDB;
		
		
		public IsCoitemXreferenced(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PXreferenced) IsCoitemXreferencedSp(string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PXreferenced)
		{
			RefTypeIJKPRTType _PRefType = PRefType;
			JobPoProjReqTrnNumType _PRefNum = PRefNum;
			SuffixPoLineProjTaskReqTrnLineType _PRefLineSuf = PRefLineSuf;
			OperNumPoReleaseType _PRefRelease = PRefRelease;
			FlagNyType _PXreferenced = PXreferenced;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCoitemXreferencedSp";
				
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXreferenced", _PXreferenced, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PXreferenced = _PXreferenced;
				
				return (Severity, PXreferenced);
			}
		}
	}
}
