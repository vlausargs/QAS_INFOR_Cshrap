//PROJECT NAME: Production
//CLASS NAME: PSVal3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSVal3
	{
		(int? ReturnCode, string Whse, string Wc, int? OperNum, string PSItemJob, short? PSItemSuffix, string Infobar) PSVal3Sp(string PSNum,
		string PSItem,
		byte? Cmpl = (byte)0,
		string Whse = null,
		string Wc = null,
		int? OperNum = null,
		string PSItemJob = null,
		short? PSItemSuffix = null,
		string Infobar = null);
	}
	
	public class PSVal3 : IPSVal3
	{
		readonly IApplicationDB appDB;
		
		public PSVal3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Whse, string Wc, int? OperNum, string PSItemJob, short? PSItemSuffix, string Infobar) PSVal3Sp(string PSNum,
		string PSItem,
		byte? Cmpl = (byte)0,
		string Whse = null,
		string Wc = null,
		int? OperNum = null,
		string PSItemJob = null,
		short? PSItemSuffix = null,
		string Infobar = null)
		{
			PsNumType _PSNum = PSNum;
			ItemType _PSItem = PSItem;
			FlagNyType _Cmpl = Cmpl;
			WhseType _Whse = Whse;
			WcType _Wc = Wc;
			OperNumType _OperNum = OperNum;
			JobType _PSItemJob = PSItemJob;
			SuffixType _PSItemSuffix = PSItemSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSVal3Sp";
				
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSItem", _PSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cmpl", _Cmpl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSItemJob", _PSItemJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSItemSuffix", _PSItemSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Whse = _Whse;
				Wc = _Wc;
				OperNum = _OperNum;
				PSItemJob = _PSItemJob;
				PSItemSuffix = _PSItemSuffix;
				Infobar = _Infobar;
				
				return (Severity, Whse, Wc, OperNum, PSItemJob, PSItemSuffix, Infobar);
			}
		}
	}
}
