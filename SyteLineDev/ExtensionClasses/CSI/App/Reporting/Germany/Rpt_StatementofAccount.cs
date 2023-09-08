//PROJECT NAME: Reporting
//CLASS NAME: Rpt_StatementofAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.Germany
{
	public interface IRpt_StatementofAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_StatementofAccountSp(byte? PrintResponseLetter = (byte)0,
		byte? PrintZeroBalCustVend = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? ShowDetail = (byte)0,
		DateTime? CutOffDate = null,
		short? CutOffDateOffset = null,
		byte? VendorSelected = (byte)0,
		string FromVendNum = null,
		string ToVendNum = null,
		byte? CustomerSelected = (byte)0,
		string FromCustNum = null,
		string ToCustNum = null,
		string Infobar = null,
		string pSite = null);
	}
	
	public class Rpt_StatementofAccount : IRpt_StatementofAccount
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_StatementofAccount(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_StatementofAccountSp(byte? PrintResponseLetter = (byte)0,
		byte? PrintZeroBalCustVend = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? ShowDetail = (byte)0,
		DateTime? CutOffDate = null,
		short? CutOffDateOffset = null,
		byte? VendorSelected = (byte)0,
		string FromVendNum = null,
		string ToVendNum = null,
		byte? CustomerSelected = (byte)0,
		string FromCustNum = null,
		string ToCustNum = null,
		string Infobar = null,
		string pSite = null)
		{
			FlagNyType _PrintResponseLetter = PrintResponseLetter;
			FlagNyType _PrintZeroBalCustVend = PrintZeroBalCustVend;
			FlagNyType _DisplayHeader = DisplayHeader;
			FlagNyType _ShowDetail = ShowDetail;
			DateType _CutOffDate = CutOffDate;
			DateOffsetType _CutOffDateOffset = CutOffDateOffset;
			FlagNyType _VendorSelected = VendorSelected;
			VendNumType _FromVendNum = FromVendNum;
			VendNumType _ToVendNum = ToVendNum;
			FlagNyType _CustomerSelected = CustomerSelected;
			CustNumType _FromCustNum = FromCustNum;
			CustNumType _ToCustNum = ToCustNum;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_StatementofAccountSp";
				
				appDB.AddCommandParameter(cmd, "PrintResponseLetter", _PrintResponseLetter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintZeroBalCustVend", _PrintZeroBalCustVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDateOffset", _CutOffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorSelected", _VendorSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromVendNum", _FromVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToVendNum", _ToVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerSelected", _CustomerSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCustNum", _FromCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCustNum", _ToCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
