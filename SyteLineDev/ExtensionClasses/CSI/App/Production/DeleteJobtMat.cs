//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteJobtMat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IDeleteJobtMat
	{
		(int? ReturnCode, int? CounterItem, string Infobar) DeleteJobtMatSp(string TransClass,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromJob,
		string ToJob,
		short? FromSuffix,
		short? ToSuffix,
		string FromItem,
		string ToItem,
		string FromEmpNum,
		string ToEmpNum,
		string FromLoc,
		string ToLoc,
		int? CounterItem,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DeleteJobtMat : IDeleteJobtMat
	{
		readonly IApplicationDB appDB;
		
		public DeleteJobtMat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CounterItem, string Infobar) DeleteJobtMatSp(string TransClass,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromJob,
		string ToJob,
		short? FromSuffix,
		short? ToSuffix,
		string FromItem,
		string ToItem,
		string FromEmpNum,
		string ToEmpNum,
		string FromLoc,
		string ToLoc,
		int? CounterItem,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			StringType _TransClass = TransClass;
			HugeTransNumType _FromTransNum = FromTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			DateType _FromTransDate = FromTransDate;
			DateType _ToTransDate = ToTransDate;
			JobType _FromJob = FromJob;
			JobType _ToJob = ToJob;
			SuffixType _FromSuffix = FromSuffix;
			SuffixType _ToSuffix = ToSuffix;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			EmpNumType _FromEmpNum = FromEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			IntType _CounterItem = CounterItem;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteJobtMatSp";
				
				appDB.AddCommandParameter(cmd, "TransClass", _TransClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CounterItem = _CounterItem;
				Infobar = _Infobar;
				
				return (Severity, CounterItem, Infobar);
			}
		}
	}
}
