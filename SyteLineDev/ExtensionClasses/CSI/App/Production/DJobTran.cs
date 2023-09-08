//PROJECT NAME: CSIProduct
//CLASS NAME: DJobTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IDJobTran
	{
		(ICollectionLoadResponse Data, int? ReturnCode, int? CounterItem, string Infobar) DJobTranSP(string Delete = "P",
		DateTime? FromDate = null,
		DateTime? ToDate = null,
		decimal? FromTraxNum = null,
		decimal? ToTraxNum = null,
		string FromJobNum = null,
		string ToJobNum = null,
		short? FromJobSuf = null,
		short? ToJobSuf = null,
		string FromEmpNum = null,
		string ToEmpNum = null,
		string TransType = "SRCMIQD",
		string JobType = null,
		int? CounterItem = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DJobTran : IDJobTran
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public DJobTran(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, int? CounterItem, string Infobar) DJobTranSP(string Delete = "P",
		DateTime? FromDate = null,
		DateTime? ToDate = null,
		decimal? FromTraxNum = null,
		decimal? ToTraxNum = null,
		string FromJobNum = null,
		string ToJobNum = null,
		short? FromJobSuf = null,
		short? ToJobSuf = null,
		string FromEmpNum = null,
		string ToEmpNum = null,
		string TransType = "SRCMIQD",
		string JobType = null,
		int? CounterItem = null,
		string Infobar = null,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			LongListType _Delete = Delete;
			DateType _FromDate = FromDate;
			DateType _ToDate = ToDate;
			HugeTransNumType _FromTraxNum = FromTraxNum;
			HugeTransNumType _ToTraxNum = ToTraxNum;
			JobType _FromJobNum = FromJobNum;
			JobType _ToJobNum = ToJobNum;
			SuffixType _FromJobSuf = FromJobSuf;
			SuffixType _ToJobSuf = ToJobSuf;
			EmpNumType _FromEmpNum = FromEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			StringType _TransType = TransType;
			JobTypeType _JobType = JobType;
			IntType _CounterItem = CounterItem;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DJobTranSP";
				
				appDB.AddCommandParameter(cmd, "Delete", _Delete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDate", _FromDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDate", _ToDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTraxNum", _FromTraxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTraxNum", _ToTraxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobNum", _FromJobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobNum", _ToJobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobSuf", _FromJobSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobSuf", _ToJobSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CounterItem", _CounterItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                CounterItem = _CounterItem;
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, CounterItem, Infobar);
			}
		}
	}
}
