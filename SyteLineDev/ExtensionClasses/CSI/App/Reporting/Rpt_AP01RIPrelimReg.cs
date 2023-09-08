//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AP01RIPrelimReg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_AP01RIPrelimReg
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_AP01RIPrelimRegSP(string PSessionIDChar,
		string PPayCode,
		string PBankCode,
		string PSortNameNum,
		byte? PDistDetail = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		string pSite = null);
	}
	
	public class Rpt_AP01RIPrelimReg : IRpt_AP01RIPrelimReg
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_AP01RIPrelimReg(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AP01RIPrelimRegSP(string PSessionIDChar,
		string PPayCode,
		string PBankCode,
		string PSortNameNum,
		byte? PDistDetail = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		string pSite = null)
		{
			LongStringType _PSessionIDChar = PSessionIDChar;
			AppmtPayTypeType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			LongDescType _PSortNameNum = PSortNameNum;
			ListYesNoType _PDistDetail = PDistDetail;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_AP01RIPrelimRegSP";
				
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDetail", _PDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
