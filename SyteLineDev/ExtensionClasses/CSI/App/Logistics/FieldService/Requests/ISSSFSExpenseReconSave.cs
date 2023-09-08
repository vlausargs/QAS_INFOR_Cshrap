//PROJECT NAME: Logistics
//CLASS NAME: SSSFSExpenseReconSave.cs

using System;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSExpenseReconSave
    {
        int? SSSFSExpenseReconSaveSp(Guid? RowPointer, int? Selected);
    }
}