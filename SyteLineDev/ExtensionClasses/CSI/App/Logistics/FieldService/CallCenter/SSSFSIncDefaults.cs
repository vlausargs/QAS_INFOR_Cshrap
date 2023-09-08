//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncDefaults
	{
		(int? ReturnCode, string PriorCode, string PriorCodeDesc, string StatCode, string StatCodeDesc, string SSR, string SSRName, byte? UseConsumer, string Infobar, byte? ToBeScheduled, string Dept) SSSFSIncDefaultsSp(string PriorCode,
		string PriorCodeDesc,
		string StatCode,
		string StatCodeDesc,
		string SSR,
		string SSRName,
		byte? UseConsumer,
		string Infobar,
		byte? ToBeScheduled = (byte)0,
		string Dept = null);
	}
	
	public class SSSFSIncDefaults : ISSSFSIncDefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PriorCode, string PriorCodeDesc, string StatCode, string StatCodeDesc, string SSR, string SSRName, byte? UseConsumer, string Infobar, byte? ToBeScheduled, string Dept) SSSFSIncDefaultsSp(string PriorCode,
		string PriorCodeDesc,
		string StatCode,
		string StatCodeDesc,
		string SSR,
		string SSRName,
		byte? UseConsumer,
		string Infobar,
		byte? ToBeScheduled = (byte)0,
		string Dept = null)
		{
			FSIncPriorCodeType _PriorCode = PriorCode;
			DescriptionType _PriorCodeDesc = PriorCodeDesc;
			FSStatCodeType _StatCode = StatCode;
			DescriptionType _StatCodeDesc = StatCodeDesc;
			FSPartnerType _SSR = SSR;
			NameType _SSRName = SSRName;
			ListYesNoType _UseConsumer = UseConsumer;
			Infobar _Infobar = Infobar;
			ListYesNoType _ToBeScheduled = ToBeScheduled;
			DeptType _Dept = Dept;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCodeDesc", _PriorCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StatCodeDesc", _StatCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SSR", _SSR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SSRName", _SSRName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseConsumer", _UseConsumer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToBeScheduled", _ToBeScheduled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriorCode = _PriorCode;
				PriorCodeDesc = _PriorCodeDesc;
				StatCode = _StatCode;
				StatCodeDesc = _StatCodeDesc;
				SSR = _SSR;
				SSRName = _SSRName;
				UseConsumer = _UseConsumer;
				Infobar = _Infobar;
				ToBeScheduled = _ToBeScheduled;
				Dept = _Dept;
				
				return (Severity, PriorCode, PriorCodeDesc, StatCode, StatCodeDesc, SSR, SSRName, UseConsumer, Infobar, ToBeScheduled, Dept);
			}
		}
	}
}
