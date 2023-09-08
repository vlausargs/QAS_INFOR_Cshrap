//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncEscalUtilGenToAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncEscalUtilGenToAddress
	{
		(int? ReturnCode,
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
			string oCCAddrs);
	}
}

