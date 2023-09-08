//PROJECT NAME: Material
//CLASS NAME: ecniMatlItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IecniMatlItem
	{
		(int? ReturnCode, string InItem, byte? OutValidItm, byte? OutSerial, string OutMatlStat, string OutSeq, string OutDescription, string OutMatlType, string OutUM, byte? OutStocked, string OutPmtCode, byte? OutPreqJob, string OutMatlCost, string OutLbrCost, string OutFovhdCost, string OutVovhdCost, string OutOutCost, string OutCost, string Infobar) ecniMatlItemSp(string InItem,
		string InJob,
		string InSuffix,
		string InOperNum,
		byte? OutValidItm,
		byte? OutSerial,
		string OutMatlStat,
		string OutSeq,
		string OutDescription,
		string OutMatlType,
		string OutUM,
		byte? OutStocked,
		string OutPmtCode,
		byte? OutPreqJob,
		string OutMatlCost,
		string OutLbrCost,
		string OutFovhdCost,
		string OutVovhdCost,
		string OutOutCost,
		string OutCost,
		string Infobar);
	}
	
	public class ecniMatlItem : IecniMatlItem
	{
		readonly IApplicationDB appDB;
		
		public ecniMatlItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InItem, byte? OutValidItm, byte? OutSerial, string OutMatlStat, string OutSeq, string OutDescription, string OutMatlType, string OutUM, byte? OutStocked, string OutPmtCode, byte? OutPreqJob, string OutMatlCost, string OutLbrCost, string OutFovhdCost, string OutVovhdCost, string OutOutCost, string OutCost, string Infobar) ecniMatlItemSp(string InItem,
		string InJob,
		string InSuffix,
		string InOperNum,
		byte? OutValidItm,
		byte? OutSerial,
		string OutMatlStat,
		string OutSeq,
		string OutDescription,
		string OutMatlType,
		string OutUM,
		byte? OutStocked,
		string OutPmtCode,
		byte? OutPreqJob,
		string OutMatlCost,
		string OutLbrCost,
		string OutFovhdCost,
		string OutVovhdCost,
		string OutOutCost,
		string OutCost,
		string Infobar)
		{
			ItemType _InItem = InItem;
			LongListType _InJob = InJob;
			LongListType _InSuffix = InSuffix;
			LongListType _InOperNum = InOperNum;
			FlagNyType _OutValidItm = OutValidItm;
			FlagNyType _OutSerial = OutSerial;
			LongListType _OutMatlStat = OutMatlStat;
			LongListType _OutSeq = OutSeq;
			LongListType _OutDescription = OutDescription;
			LongListType _OutMatlType = OutMatlType;
			LongListType _OutUM = OutUM;
			FlagNyType _OutStocked = OutStocked;
			LongListType _OutPmtCode = OutPmtCode;
			FlagNyType _OutPreqJob = OutPreqJob;
			LongListType _OutMatlCost = OutMatlCost;
			LongListType _OutLbrCost = OutLbrCost;
			LongListType _OutFovhdCost = OutFovhdCost;
			LongListType _OutVovhdCost = OutVovhdCost;
			LongListType _OutOutCost = OutOutCost;
			LongListType _OutCost = OutCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ecniMatlItemSp";
				
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InOperNum", _InOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutValidItm", _OutValidItm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutSerial", _OutSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutMatlStat", _OutMatlStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutSeq", _OutSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutDescription", _OutDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutMatlType", _OutMatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutUM", _OutUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutStocked", _OutStocked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutPmtCode", _OutPmtCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutPreqJob", _OutPreqJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutMatlCost", _OutMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutLbrCost", _OutLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutFovhdCost", _OutFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutVovhdCost", _OutVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutOutCost", _OutOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InItem = _InItem;
				OutValidItm = _OutValidItm;
				OutSerial = _OutSerial;
				OutMatlStat = _OutMatlStat;
				OutSeq = _OutSeq;
				OutDescription = _OutDescription;
				OutMatlType = _OutMatlType;
				OutUM = _OutUM;
				OutStocked = _OutStocked;
				OutPmtCode = _OutPmtCode;
				OutPreqJob = _OutPreqJob;
				OutMatlCost = _OutMatlCost;
				OutLbrCost = _OutLbrCost;
				OutFovhdCost = _OutFovhdCost;
				OutVovhdCost = _OutVovhdCost;
				OutOutCost = _OutOutCost;
				OutCost = _OutCost;
				Infobar = _Infobar;
				
				return (Severity, InItem, OutValidItm, OutSerial, OutMatlStat, OutSeq, OutDescription, OutMatlType, OutUM, OutStocked, OutPmtCode, OutPreqJob, OutMatlCost, OutLbrCost, OutFovhdCost, OutVovhdCost, OutOutCost, OutCost, Infobar);
			}
		}
	}
}
