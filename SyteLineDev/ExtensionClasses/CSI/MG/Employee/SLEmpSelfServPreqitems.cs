//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpSelfServPreqitems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
	[IDOExtensionClass("SLEmpSelfServPreqitems")]
	public class SLEmpSelfServPreqitems : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AlertPORequisitionSp(string RequestType,
			string EmpNum,
			string SupEmpNum,
			string RequesterName,
			string ApproverName,
			string ReqNum,
			int? ReqLine,
			string ReqCode,
			string ReqCodeDescription,
			string Item,
			string ItemDescription,
			ref string Inforbar)
        {
            var iAlertPORequisitionExt = new AlertPORequisitionFactory().Create(this, true);

            var result = iAlertPORequisitionExt.AlertPORequisitionSp(RequestType,
            EmpNum,
            SupEmpNum,
            RequesterName,
            ApproverName,
            ReqNum,
            ReqLine,
            ReqCode,
            ReqCodeDescription,
            Item,
            ItemDescription,
            Inforbar);

            Inforbar = result.Inforbar;

            return result.ReturnCode ?? 0;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PreqCreSp(string IItem,
		string IWhse,
		string IReqNum,
		decimal? IQtyOrdered,
		DateTime? IDueDate,
		string IRefType,
		string IRefNum,
		int? IRefLineSuf,
		int? IRefRelease,
		string IDesc,
		decimal? ICost,
		string IUM,
		string IVendNum,
		[Optional] string IManufacturerId,
		[Optional] string IManufacturerItem,
		ref int? I,
		ref string CurReqNum,
		ref int? CurReqLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreqCreExt = new PreqCreFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreqCreExt.PreqCreSp(IItem,
				IWhse,
				IReqNum,
				IQtyOrdered,
				IDueDate,
				IRefType,
				IRefNum,
				IRefLineSuf,
				IRefRelease,
				IDesc,
				ICost,
				IUM,
				IVendNum,
				IManufacturerId,
				IManufacturerItem,
				I,
				CurReqNum,
				CurReqLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				I = result.I;
				CurReqNum = result.CurReqNum;
				CurReqLine = result.CurReqLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
