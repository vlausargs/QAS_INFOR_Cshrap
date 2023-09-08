using CSI.MXLOC.Interfaces;
using System;
using System.Data;

namespace CSI.MXLOC
{
    public interface ICFDIReceiptCRUD
    {
        (int Count, string Infobar) UpdateDatabaseValue(IMXElectronicPaymentReceipt mXElectronicPaymentReceipt, string cFDIReceiptXmlFileName);
        (int Count, string Infobar) UpdateDetailDatabaseValue(IMXElectronicPaymentReceiptDetail mXElectronicPaymentReceiptDetail, string cFDIReceiptXmlFileName);
        DataTable GetStatus(string BeginArCheckNum = null, string EndArCheckNum = null, DateTime? BeginPaymentDate = null, DateTime? EndPaymentDate = null);
        string GetProFormaInvNumByStamp(string IdDocumentApprovalStamp);
        string GetWorkstationID(string Username);

    }
}