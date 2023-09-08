//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDrpLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSDrpLoad
	{
		(int? ReturnCode, string Infobar) SSSFSDrpLoadSp(string iWhseStarting,
		string iWhseEnding,
		string iItemStarting,
		string iItemEnding,
		int? iDaysToPlan,
		byte? iInclPurchased,
		byte? iInclTransferred,
		string Infobar,
		string iBuyer = null,
		string iPlannerCode = null);
	}
	
	public class SSSFSDrpLoad : ISSSFSDrpLoad
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDrpLoad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSDrpLoadSp(string iWhseStarting,
		string iWhseEnding,
		string iItemStarting,
		string iItemEnding,
		int? iDaysToPlan,
		byte? iInclPurchased,
		byte? iInclTransferred,
		string Infobar,
		string iBuyer = null,
		string iPlannerCode = null)
		{
			WhseType _iWhseStarting = iWhseStarting;
			WhseType _iWhseEnding = iWhseEnding;
			ItemType _iItemStarting = iItemStarting;
			ItemType _iItemEnding = iItemEnding;
			IntType _iDaysToPlan = iDaysToPlan;
			ListYesNoType _iInclPurchased = iInclPurchased;
			ListYesNoType _iInclTransferred = iInclTransferred;
			Infobar _Infobar = Infobar;
			UsernameType _iBuyer = iBuyer;
			UserCodeType _iPlannerCode = iPlannerCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpLoadSp";
				
				appDB.AddCommandParameter(cmd, "iWhseStarting", _iWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhseEnding", _iWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItemStarting", _iItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItemEnding", _iItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDaysToPlan", _iDaysToPlan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iInclPurchased", _iInclPurchased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iInclTransferred", _iInclTransferred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iBuyer", _iBuyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPlannerCode", _iPlannerCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
