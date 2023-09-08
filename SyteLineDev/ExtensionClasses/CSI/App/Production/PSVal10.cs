//PROJECT NAME: Production
//CLASS NAME: PSVal10.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSVal10
	{
		(int? ReturnCode, string PSNum, string UM, byte? LotTracked, byte? SerTracked, string Whse, string Wc, int? OperNum, string PSItemJob, short? PSItemSuffix, string Infobar) PSVal10Sp(string PSItem,
		byte? Cmpl = (byte)0,
		string PSNum = null,
		string UM = null,
		byte? LotTracked = null,
		byte? SerTracked = null,
		string Whse = null,
		string Wc = null,
		int? OperNum = null,
		string PSItemJob = null,
		short? PSItemSuffix = null,
		string Infobar = null);
	}
	
	public class PSVal10 : IPSVal10
	{
		readonly IApplicationDB appDB;
		
		public PSVal10(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PSNum, string UM, byte? LotTracked, byte? SerTracked, string Whse, string Wc, int? OperNum, string PSItemJob, short? PSItemSuffix, string Infobar) PSVal10Sp(string PSItem,
		byte? Cmpl = (byte)0,
		string PSNum = null,
		string UM = null,
		byte? LotTracked = null,
		byte? SerTracked = null,
		string Whse = null,
		string Wc = null,
		int? OperNum = null,
		string PSItemJob = null,
		short? PSItemSuffix = null,
		string Infobar = null)
		{
			ItemType _PSItem = PSItem;
			FlagNyType _Cmpl = Cmpl;
			PsNumType _PSNum = PSNum;
			UMType _UM = UM;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerTracked = SerTracked;
			WhseType _Whse = Whse;
			WcType _Wc = Wc;
			OperNumType _OperNum = OperNum;
			JobType _PSItemJob = PSItemJob;
			SuffixType _PSItemSuffix = PSItemSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSVal10Sp";
				
				appDB.AddCommandParameter(cmd, "PSItem", _PSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cmpl", _Cmpl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerTracked", _SerTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSItemJob", _PSItemJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSItemSuffix", _PSItemSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSNum = _PSNum;
				UM = _UM;
				LotTracked = _LotTracked;
				SerTracked = _SerTracked;
				Whse = _Whse;
				Wc = _Wc;
				OperNum = _OperNum;
				PSItemJob = _PSItemJob;
				PSItemSuffix = _PSItemSuffix;
				Infobar = _Infobar;
				
				return (Severity, PSNum, UM, LotTracked, SerTracked, Whse, Wc, OperNum, PSItemJob, PSItemSuffix, Infobar);
			}
		}
	}
}
