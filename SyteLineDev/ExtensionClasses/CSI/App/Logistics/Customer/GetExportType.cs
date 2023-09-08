//PROJECT NAME: CSICustomer
//CLASS NAME: GetExportType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetExportType
	{
		(int? ReturnCode, string ExportType, string LangCode, string Slsman) GetExportTypeSp(string CustNum,
		string ExportType,
		string LangCode,
		string Slsman,
		string PSite = null);
	}
	
	public class GetExportType : IGetExportType
	{
		readonly IApplicationDB appDB;
		
		public GetExportType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ExportType, string LangCode, string Slsman) GetExportTypeSp(string CustNum,
		string ExportType,
		string LangCode,
		string Slsman,
		string PSite = null)
		{
			CustNumType _CustNum = CustNum;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			LangCodeType _LangCode = LangCode;
			SlsmanType _Slsman = Slsman;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetExportTypeSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExportType = _ExportType;
				LangCode = _LangCode;
				Slsman = _Slsman;
				
				return (Severity, ExportType, LangCode, Slsman);
			}
		}
	}
}
