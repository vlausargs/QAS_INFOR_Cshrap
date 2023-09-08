//PROJECT NAME: MG
//CLASS NAME: DD_FSSROLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("DD_FSSROLines")]
	public class DD_FSSROLines : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROGetItemInfoSp(string SRONum,
		string Item,
		ref string Description,
		ref string ItemUM,
		ref byte? ItemExists,
		ref string Contract,
		ref int? ContLine,
		ref string PromptMsgNI,
		ref string Infobar,
		[Optional] ref string CustItem,
		[Optional, DefaultParameterValue((byte)0)] ref byte? IsOpenNonInvForm,
		[Optional] ref string BillCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROGetItemInfoExt = new SSSFSSROGetItemInfoFactory().Create(appDb);
				
				var result = iSSSFSSROGetItemInfoExt.SSSFSSROGetItemInfoSp(SRONum,
				Item,
				Description,
				ItemUM,
				ItemExists,
				Contract,
				ContLine,
				PromptMsgNI,
				Infobar,
				CustItem,
				IsOpenNonInvForm,
				BillCode);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				ItemUM = result.ItemUM;
				ItemExists = result.ItemExists;
				Contract = result.Contract;
				ContLine = result.ContLine;
				PromptMsgNI = result.PromptMsgNI;
				Infobar = result.Infobar;
				CustItem = result.CustItem;
				IsOpenNonInvForm = result.IsOpenNonInvForm;
				BillCode = result.BillCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROLineGetUnitInfoSp(string SRONum,
		int? SROLine,
		string SerNum,
		ref string Item,
		ref string Description,
		ref string ItemUM,
		ref byte? UnitExists,
		ref string UnitCustNum,
		ref int? UnitCustSeq,
		ref byte? ItemExists,
		ref string Contract,
		ref int? ContLine,
		ref string BillCode,
		ref string PromptMsgBadCust,
		ref string PromptMsgNoUnit,
		ref string Infobar,
		[Optional] ref string CustItem,
		[Optional] ref string UnitUsrNum,
		[Optional] ref int? UnitUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROLineGetUnitInfoExt = new SSSFSSROLineGetUnitInfoFactory().Create(appDb);
				
				var result = iSSSFSSROLineGetUnitInfoExt.SSSFSSROLineGetUnitInfoSp(SRONum,
				SROLine,
				SerNum,
				Item,
				Description,
				ItemUM,
				UnitExists,
				UnitCustNum,
				UnitCustSeq,
				ItemExists,
				Contract,
				ContLine,
				BillCode,
				PromptMsgBadCust,
				PromptMsgNoUnit,
				Infobar,
				CustItem,
				UnitUsrNum,
				UnitUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Description = result.Description;
				ItemUM = result.ItemUM;
				UnitExists = result.UnitExists;
				UnitCustNum = result.UnitCustNum;
				UnitCustSeq = result.UnitCustSeq;
				ItemExists = result.ItemExists;
				Contract = result.Contract;
				ContLine = result.ContLine;
				BillCode = result.BillCode;
				PromptMsgBadCust = result.PromptMsgBadCust;
				PromptMsgNoUnit = result.PromptMsgNoUnit;
				Infobar = result.Infobar;
				CustItem = result.CustItem;
				UnitUsrNum = result.UnitUsrNum;
				UnitUsrSeq = result.UnitUsrSeq;
				return Severity;
			}
		}
	}
}
