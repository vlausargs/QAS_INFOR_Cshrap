//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigCreate
	{
		(int? ReturnCode, string Infobar) SSSFSUnitConfigCreateSP(string InSerNum,
		byte? InSubUnit,
		byte? InAppend = (byte)0,
		byte? InBatch = (byte)0,
		string InCopyFrom = null,
		string InCpySerNum = null,
		string InCopyItem = null,
		string InJob = null,
		short? InSuffix = null,
		string InItem = null,
		int? InParentID = null,
		DateTime? InInstallDate = null,
		byte? InCopyWarr = (byte)1,
		string Infobar = null,
		string InCustNum = null,
		int? InCustSeq = null,
		string InUsrNum = null,
		int? InUsrSeq = null);
	}
	
	public class SSSFSUnitConfigCreate : ISSSFSUnitConfigCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitConfigCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSUnitConfigCreateSP(string InSerNum,
		byte? InSubUnit,
		byte? InAppend = (byte)0,
		byte? InBatch = (byte)0,
		string InCopyFrom = null,
		string InCpySerNum = null,
		string InCopyItem = null,
		string InJob = null,
		short? InSuffix = null,
		string InItem = null,
		int? InParentID = null,
		DateTime? InInstallDate = null,
		byte? InCopyWarr = (byte)1,
		string Infobar = null,
		string InCustNum = null,
		int? InCustSeq = null,
		string InUsrNum = null,
		int? InUsrSeq = null)
		{
			SerNumType _InSerNum = InSerNum;
			ListYesNoType _InSubUnit = InSubUnit;
			ListYesNoType _InAppend = InAppend;
			ListYesNoType _InBatch = InBatch;
			StringType _InCopyFrom = InCopyFrom;
			SerNumType _InCpySerNum = InCpySerNum;
			ItemType _InCopyItem = InCopyItem;
			JobType _InJob = InJob;
			SuffixType _InSuffix = InSuffix;
			ItemType _InItem = InItem;
			FSCompIdType _InParentID = InParentID;
			DateTimeType _InInstallDate = InInstallDate;
			FlagNyType _InCopyWarr = InCopyWarr;
			InfobarType _Infobar = Infobar;
			CustNumType _InCustNum = InCustNum;
			CustSeqType _InCustSeq = InCustSeq;
			FSUsrNumType _InUsrNum = InUsrNum;
			FSUsrSeqType _InUsrSeq = InUsrSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigCreateSP";
				
				appDB.AddCommandParameter(cmd, "InSerNum", _InSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSubUnit", _InSubUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAppend", _InAppend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InBatch", _InBatch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCopyFrom", _InCopyFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCpySerNum", _InCpySerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCopyItem", _InCopyItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InParentID", _InParentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InInstallDate", _InInstallDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCopyWarr", _InCopyWarr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InCustNum", _InCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCustSeq", _InCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InUsrNum", _InUsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InUsrSeq", _InUsrSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
