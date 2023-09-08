//PROJECT NAME: Data
//CLASS NAME: Getmthd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Getmthd : IGetmthd
	{
		readonly IApplicationDB appDB;
		
		public Getmthd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PSortMethod) GetmthdSp(
			string PSort,
			int? PSortMethod,
			string pSite = null)
		{
			LongListType _PSort = PSort;
			SortMethodType _PSortMethod = PSortMethod;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetmthdSp";
				
				appDB.AddCommandParameter(cmd, "PSort", _PSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortMethod", _PSortMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSortMethod = _PSortMethod;
				
				return (Severity, PSortMethod);
			}
		}
	}
}
