//PROJECT NAME: CSIVendor
//CLASS NAME: EftPostCreateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IEftPostCreateTT
	{
		DataTable EftPostCreateTTSp(string PBegVendNum,
		                            string PEndVendNum,
		                            string PBegName,
		                            string PEndName,
		                            string EFTFormat,
		                            string PBankCode,
		                            string PAppmtPayType,
		                            DateTime? PPayDateStarting,
		                            DateTime? PPayDateEnding,
		                            Guid? PSessionID);
	}
	
	public class EftPostCreateTT : IEftPostCreateTT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public EftPostCreateTT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable EftPostCreateTTSp(string PBegVendNum,
		                                   string PEndVendNum,
		                                   string PBegName,
		                                   string PEndName,
		                                   string EFTFormat,
		                                   string PBankCode,
		                                   string PAppmtPayType,
		                                   DateTime? PPayDateStarting,
		                                   DateTime? PPayDateEnding,
		                                   Guid? PSessionID)
		{
			VendNumType _PBegVendNum = PBegVendNum;
			VendNumType _PEndVendNum = PEndVendNum;
			NameType _PBegName = PBegName;
			NameType _PEndName = PEndName;
			EFTFormatType _EFTFormat = EFTFormat;
			BankCodeType _PBankCode = PBankCode;
			AppmtPayTypeType _PAppmtPayType = PAppmtPayType;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EftPostCreateTTSp";
				
				appDB.AddCommandParameter(cmd, "PBegVendNum", _PBegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndVendNum", _PEndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegName", _PBegName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndName", _PEndName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTFormat", _EFTFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtPayType", _PAppmtPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
