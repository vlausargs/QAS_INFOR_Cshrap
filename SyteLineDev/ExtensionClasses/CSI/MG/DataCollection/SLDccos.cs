//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDccos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
    [IDOExtensionClass("SLDccos")]
    public class SLDccos : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DccoDSp(string Status,
		                   string TransType,
		                   decimal? FromTransNum,
		                   decimal? ToTransNum,
		                   DateTime? FromTransDate,
		                   DateTime? ToTransDate,
		                   ref string Infobar,
		                   [Optional] short? StartingTransDateOffset,
		                   [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDccoDExt = new DccoDFactory().Create(appDb);
				
				var result = iDccoDExt.DccoDSp(Status,
				                               TransType,
				                               FromTransNum,
				                               ToTransNum,
				                               FromTransDate,
				                               ToTransDate,
				                               Infobar,
				                               StartingTransDateOffset,
				                               EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeEDICustomerOrders([Optional] string optexBegEdiCo_Num,
		[Optional] string optexEndEdiCo_Num,
		[Optional] DateTime? optexBegOrder_date,
		[Optional] DateTime? optexEndOrder_date,
		[Optional] string optexBegCust_num,
		[Optional] string optexEndCust_num,
		[Optional] string optexBegTrx_code,
		[Optional] string optexEndTrx_code,
		[Optional] short? TrxDateStartingOffset,
		[Optional] short? TrxDateEndingOffset,
		[Optional] ref string Message)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeEDICustomerOrdersExt = new PurgeEDICustomerOrdersFactory().Create(appDb);
				
				var result = iPurgeEDICustomerOrdersExt.PurgeEDICustomerOrdersSp(optexBegEdiCo_Num,
				optexEndEdiCo_Num,
				optexBegOrder_date,
				optexEndOrder_date,
				optexBegCust_num,
				optexEndCust_num,
				optexBegTrx_code,
				optexEndTrx_code,
				TrxDateStartingOffset,
				TrxDateEndingOffset,
				Message);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcACoshipSp(string PTermId,
		int? PTransType,
		string PEmpNum,
		DateTime? TTransDate,
		string PCoNum,
		int? PCoLine,
		int? PCoRel,
		string TItem,
		decimal? Qty,
		string TUm,
		string PLoc,
		string PLot,
		string PCurWhse,
		string PReasonCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcACoshipExt = new DcACoshipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcACoshipExt.DcACoshipSp(PTermId,
				PTransType,
				PEmpNum,
				TTransDate,
				PCoNum,
				PCoLine,
				PCoRel,
				TItem,
				Qty,
				TUm,
				PLoc,
				PLot,
				PCurWhse,
				PReasonCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DccoLogErrorSp(int? PTransNum,
		string ErrorMsg)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDccoLogErrorExt = new DccoLogErrorFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDccoLogErrorExt.DccoLogErrorSp(PTransNum,
				ErrorMsg);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DccoPSp([Optional, DefaultParameterValue(0)] int? FromEdi,
		[Optional] decimal? ProcessId,
		[Optional] DateTime? PostDate,
		[Optional] ref string Infobar,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDccoPExt = new DccoPFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDccoPExt.DccoPSp(FromEdi,
				ProcessId,
				PostDate,
				Infobar,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcCoValidateEmpNumSp(int? Connected,
		ref string EmpNum,
		ref string EmpName,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcCoValidateEmpNumExt = new DcCoValidateEmpNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcCoValidateEmpNumExt.DcCoValidateEmpNumSp(Connected,
				EmpNum,
				EmpName,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				EmpNum = result.EmpNum;
				EmpName = result.EmpName;
				Infobar = result.Infobar;
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDcparmAutopostEscFlagSp(string AutoPostFieldName,
		ref int? AutoPostFlag,
		ref string EscFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDcparmAutopostEscFlagExt = new GetDcparmAutopostEscFlagFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDcparmAutopostEscFlagExt.GetDcparmAutopostEscFlagSp(AutoPostFieldName,
				AutoPostFlag,
				EscFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				AutoPostFlag = result.AutoPostFlag;
				EscFlag = result.EscFlag;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
