//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncEscalUtilGenToAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncEscalUtilGenToAddress : ISSSFSIncEscalUtilGenToAddress
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncEscalUtilGenToAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oToAddrs,
			string oCCAddrs) SSSFSIncEscalUtilGenToAddressSp(
			int? iSendToSlsman,
			int? iSendToSSR,
			int? iSendToSSRSup,
			int? iSendToOwner,
			int? iSendToOwnerSup,
			int? iSendToContact,
			int? iSendToOther,
			string iOwner,
			string iSSR,
			string iIncNum,
			string iPriorCode,
			string iSlsman,
			string iBasis,
			string iFreq,
			int? iDuration,
			string iDurationType,
			string iIncEmailAddr,
			string iEmailOtherAddr,
			string iEmailContent,
			string iEmailTxt,
			string oToAddrs,
			string oCCAddrs)
		{
			ListYesNoType _iSendToSlsman = iSendToSlsman;
			ListYesNoType _iSendToSSR = iSendToSSR;
			ListYesNoType _iSendToSSRSup = iSendToSSRSup;
			ListYesNoType _iSendToOwner = iSendToOwner;
			ListYesNoType _iSendToOwnerSup = iSendToOwnerSup;
			ListYesNoType _iSendToContact = iSendToContact;
			ListYesNoType _iSendToOther = iSendToOther;
			FSPartnerType _iOwner = iOwner;
			FSPartnerType _iSSR = iSSR;
			FSIncNumType _iIncNum = iIncNum;
			FSIncPriorCodeType _iPriorCode = iPriorCode;
			SlsmanType _iSlsman = iSlsman;
			FSEscalBasisType _iBasis = iBasis;
			FSEscalFreqType _iFreq = iFreq;
			FSDurationType _iDuration = iDuration;
			FSDurationTypeType _iDurationType = iDurationType;
			EmailType _iIncEmailAddr = iIncEmailAddr;
			EmailType _iEmailOtherAddr = iEmailOtherAddr;
			InfobarType _iEmailContent = iEmailContent;
			StringType _iEmailTxt = iEmailTxt;
			InfobarType _oToAddrs = oToAddrs;
			LongDescType _oCCAddrs = oCCAddrs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncEscalUtilGenToAddressSp";
				
				appDB.AddCommandParameter(cmd, "iSendToSlsman", _iSendToSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToSSR", _iSendToSSR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToSSRSup", _iSendToSSRSup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToOwner", _iSendToOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToOwnerSup", _iSendToOwnerSup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToContact", _iSendToContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSendToOther", _iSendToOther, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOwner", _iOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSSR", _iSSR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iIncNum", _iIncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPriorCode", _iPriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSlsman", _iSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBasis", _iBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFreq", _iFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDuration", _iDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDurationType", _iDurationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iIncEmailAddr", _iIncEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEmailOtherAddr", _iEmailOtherAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEmailContent", _iEmailContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEmailTxt", _iEmailTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oToAddrs", _oToAddrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oCCAddrs", _oCCAddrs, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oToAddrs = _oToAddrs;
				oCCAddrs = _oCCAddrs;
				
				return (Severity, oToAddrs, oCCAddrs);
			}
		}
	}
}
