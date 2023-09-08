//PROJECT NAME: Data
//CLASS NAME: InitDuePeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitDuePeriod : IInitDuePeriod
	{
		readonly IApplicationDB appDB;
		
		public InitDuePeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PDuePeriod) InitDuePeriodSp(
			string PItem,
			string PCustNum,
			string PSite,
			int? PDuePeriod,
			string CustItem)
		{
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			SiteType _PSite = PSite;
			IntType _PDuePeriod = PDuePeriod;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitDuePeriodSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDuePeriod", _PDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDuePeriod = _PDuePeriod;
				
				return (Severity, PDuePeriod);
			}
		}
	}
}
