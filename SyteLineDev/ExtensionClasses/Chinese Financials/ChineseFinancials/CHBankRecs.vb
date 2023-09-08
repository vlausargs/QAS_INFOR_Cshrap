Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Finance.Chinese
Imports CSI.MG
Imports System.Runtime.InteropServices

'// <Ref>System.Runtime.Serialization.Formatters.Soap.dll</Ref>
<IDOExtensionClass("CHBankRecs")> _
Public Class CHBankRecs

    Inherits ExtensionClassBase
    Public Function CHSLoadBankReconVb(ByVal sData As String, ByVal BankCode As String, ByVal Source As String, ByVal SessionId As String, ByRef Infobar As String) As Integer
        On Error GoTo ImportFailedErrHandler

        Dim intRetValue As InvokeResponseData
        Dim iCounter As Integer

        'destination array
        Dim arrInput(,) As Object
        Dim oXmlFormatter As SoapFormatter
        Dim oMemStream As MemoryStream
        Dim oWriter As StreamWriter

        intRetValue = Nothing

        'sData is an array that had been serialized using SOAPFormatter and passed to this method
        'Deserialize the string back to get the array

        oXmlFormatter = New SoapFormatter
        oMemStream = New MemoryStream
        oWriter = New StreamWriter(oMemStream)
        oWriter.Write(sData)
        oWriter.Flush()
        oMemStream.Seek(0, SeekOrigin.Begin)
        arrInput = CType(oXmlFormatter.Deserialize(oMemStream), Object(,))
        oXmlFormatter = Nothing
        oMemStream.Close()
        oWriter.Close()

        iCounter = 0
        Do While iCounter <= UBound(arrInput, 2)
            intRetValue = Me.Invoke("CHSLoadBankReconSp", BankCode, CDate(arrInput(0, iCounter)), arrInput(1, iCounter), CDec(arrInput(2, iCounter)), Source, SessionId, IDONull.Value)

            If intRetValue.IsReturnValueStdError Then
                Infobar = intRetValue.Parameters(6).Value
                GoTo ImportFailedErrHandler
            End If
            iCounter = iCounter + 1
        Loop

        Exit Function

ImportFailedErrHandler:
        CHSLoadBankReconVb = -1
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CHSCLM_ListBankReconSp(ByVal PSessionID As Guid?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As CSI.MG.IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iCHSCLM_ListBankReconExt As ICHSCLM_ListBankRecon = New CHSCLM_ListBankReconFactory().Create(appDb, bunchedLoadCollection)
            Dim dt As DataTable = iCHSCLM_ListBankReconExt.CHSCLM_ListBankReconSp(PSessionID)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CHSLoadBankReconSp(ByVal PBankCode As String, ByVal PDate As DateTime?, ByVal PDebitCredit As String, ByVal PAmount As Decimal?, ByVal PSource As String, ByVal PSessionID As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCHSLoadBankReconExt As ICHSLoadBankRecon = New CHSLoadBankReconFactory().Create(appDb)
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iCHSLoadBankReconExt.CHSLoadBankReconSp(PBankCode, PDate, PDebitCredit, PAmount, PSource, PSessionID, oInfobar)
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

End Class
