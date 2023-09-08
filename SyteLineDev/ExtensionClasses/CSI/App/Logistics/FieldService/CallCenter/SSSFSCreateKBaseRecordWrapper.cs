//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCreateKBaseRecordWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSCreateKBaseRecordWrapper
	{
		(int? ReturnCode, int? NewKnowNum,
		string Infobar) SSSFSCreateKBaseRecordWrapperSp(string Keywords,
		string Desc,
		string Resolution,
		string Summary,
		Guid? RowPtr,
		int? NewKnowNum,
		string Infobar);
	}
	
	public class SSSFSCreateKBaseRecordWrapper : ISSSFSCreateKBaseRecordWrapper
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCreateKBaseRecordWrapper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NewKnowNum,
		string Infobar) SSSFSCreateKBaseRecordWrapperSp(string Keywords,
		string Desc,
		string Resolution,
		string Summary,
		Guid? RowPtr,
		int? NewKnowNum,
		string Infobar)
		{
			FSKBKeywordType _Keywords = Keywords;
			FSKBTextType _Desc = Desc;
			FSKBTextType _Resolution = Resolution;
			LicenseCheckSumType _Summary = Summary;
			RowPointerType _RowPtr = RowPtr;
			FSKnowNumType _NewKnowNum = NewKnowNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCreateKBaseRecordWrapperSp";
				
				appDB.AddCommandParameter(cmd, "Keywords", _Keywords, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Resolution", _Resolution, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Summary", _Summary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPtr", _RowPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewKnowNum", _NewKnowNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewKnowNum = _NewKnowNum;
				Infobar = _Infobar;
				
				return (Severity, NewKnowNum, Infobar);
			}
		}
	}
}
