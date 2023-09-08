//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBPersonnelViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBPersonnelViews")]
	public class ESBPersonnelViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBPersonnelSp(string EmpNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBPersonnelExt = new CLM_ESBPersonnelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBPersonnelExt.CLM_ESBPersonnelSp(EmpNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBPersonnelSp([Optional] string ActionExpression,
		[Optional] string EmpNum,
		[Optional] string Fname,
		[Optional] string Nickname,
		[Optional] string Mi,
		[Optional] string Lname,
		[Optional] string Sname,
		[Optional] string GenderCode,
		[Optional] string MaritalStatusCode,
		[Optional] DateTime? BirthDate,
		[Optional] string Nationality,
		[Optional] string CitizenshipCountry,
		[Optional] string Addr1,
		[Optional] string Addr2,
		[Optional] string Addr3,
		[Optional] string Addr4,
		[Optional] string City,
		[Optional] string State,
		[Optional] string ISOCountryCode,
		[Optional] string Zip,
		[Optional] string Phone,
		[Optional] DateTime? HireDate,
		[Optional] string Status,
		[Optional] string CostCenterCode,
		[Optional] string PosJobTitle,
		[Optional] string EmpposJobId,
		[Optional] DateTime? EmpAssignDate,
		[Optional] string Extension,
		[Optional] string EmailAddress,
		[Optional] string Shift,
		[Optional] string PayFreq,
		[Optional] string BankName,
		[Optional] string AccountID,
		[Optional] string AccountType,
		[Optional] string MilitaryDesc,
		[Optional] string Military,
		[Optional] string EthnicId,
		[Optional] string Handicap,
		[Optional] string Supervisor,
		[Optional] decimal? DepAmount,
		[Optional] decimal? DepPct,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadESBPersonnelExt = new LoadESBPersonnelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadESBPersonnelExt.LoadESBPersonnelSp(ActionExpression,
				EmpNum,
				Fname,
				Nickname,
				Mi,
				Lname,
				Sname,
				GenderCode,
				MaritalStatusCode,
				BirthDate,
				Nationality,
				CitizenshipCountry,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				City,
				State,
				ISOCountryCode,
				Zip,
				Phone,
				HireDate,
				Status,
				CostCenterCode,
				PosJobTitle,
				EmpposJobId,
				EmpAssignDate,
				Extension,
				EmailAddress,
				Shift,
				PayFreq,
				BankName,
				AccountID,
				AccountType,
				MilitaryDesc,
				Military,
				EthnicId,
				Handicap,
				Supervisor,
				DepAmount,
				DepPct,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
