//PROJECT NAME: MG
//CLASS NAME: SLArEftImportArpmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLArEftImportArpmts")]
	public class SLArEftImportArpmts : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetCoNumSp(string CustNum,
			string BankRouting,
			string BankAccount)
		{
			var iCLM_GetCoNumExt = this.GetService<ICLM_GetCoNum>();
			
			var result = iCLM_GetCoNumExt.CLM_GetCoNumSp(CustNum,
				BankRouting,
				BankAccount);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustNumValidateSp(string CustNum,
			string BankRouting,
			string BankAccount,
			ref string Infobar)
		{
			var iCustNumValidateExt = new CustNumValidateFactory().Create(this, true);

			var result = iCustNumValidateExt.CustNumValidateSp(CustNum,
				BankRouting,
				BankAccount,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
	}
}
