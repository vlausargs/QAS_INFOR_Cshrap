Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Xml

Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.Logistics.Customer
Imports CSI.MG
Imports System.Runtime.InteropServices
Imports CSI.Logistics.Vendor
Imports CSI.Data.RecordSets
Imports CSI.Data.CRUD

<IDOExtensionClass("SLDoHdrs")> _
Public Class SLDoHdrs
    Inherits CSIExtensionClassBase

    Private mFaultString As String

    <IDOMethod(MethodFlags.None)> _
    Public Function UKExportInterface(ByVal vDoNum As String, ByVal lszDoHdrInfo As String, ByVal lszDoLineInfo As String) As Integer

        Dim lboLinesExist As Boolean
        Dim linFile As Integer
        Dim linIndex As Integer
        Dim linNoteStep As Integer
        Dim linNoteIdx As Integer
        Dim linNoteIdx2 As Integer
        Dim lszFileName As String = ""
        'Dim lszDoHdrInfo As String = ""
        'Dim lszDoLineInfo As String = ""
        Dim lszExpDocDir As String = ""
        Dim lszExpDocPrefix As String = ""
        Dim lszExpDocExt As String = ""
        Dim lszDoNum As String = ""
        Dim lszInvNum As String = ""
        Dim lvaHeader As String()
        Dim lvaLines As String()
        Dim lvaDetail As String()
        Dim lvaNotes(9) As String
        'Dim lobIDO As Object
        'Dim lobjXML As New XmlDocument
        Dim oInvokeResponseData As InvokeResponseData

        'Dim oSchema As IDOBJECTLib.IIDOCollectionSchema
        'Dim oTxn As IDOBJECTLib.IDOTransaction

        'Header Array Positions:
        '(0)  - Invoice Reference
        '(1)  - Invoice Number
        '(2)  - Customer Number
        '(3)  - Consignee Name
        '(4)  - Consignee Address 1
        '(5)  - Consignee Address 2
        '(6)  - Consignee Address 3
        '(7)  - Consignee Address 4
        '(8)  - Consignee Address 5
        '(9)  - Buyer Name
        '(10) - Buyer Address 1
        '(11) - Buyer Address 2
        '(12) - Buyer Address 3
        '(13) - Buyer Address 4
        '(14) - Buyer Address 5
        '(15) - Buyer Country Code
        '(16) - Buyer VAT Number
        '(17) - Invoice Date
        '(18) - Currency Code
        '(19) - Currency Description
        '(20) - Misc. Charges
        '(21) - Sales Tax
        '(22) - Freight
        '(23) - Sales Tax 2

        'Detail Array Positions:
        '(0)  - Invoice Reference
        '(1)  - Item Number
        '(2)  - Product Code
        '(3)  - Product Description 1
        '(4)  - Product Description 2
        '(5)  - Product Description 3
        '(6)  - Extended Description 1
        '(7)  - Extended Description 2
        '(8)  - Extended Description 3
        '(9)  - Extended Description 4
        '(10) - Extended Description 5
        '(11) - Extended Description 6
        '(12) - Tariff Code
        '(13) - Reference Number
        '(14) - Customer PO Number
        '(15) - Selling UM
        '(16) - Quantity
        '(17) - Unit Price
        '(18) - Ext Value
        '(19) - Customer Part Number
        '(20) - Country of Origin
        '(21) - Item Description
        '(22) - ExpDocItem Flag

        Try
            oInvokeResponseData = Me.Invoke("ExtInterfaceParmsSp", lszExpDocDir, lszExpDocPrefix, lszExpDocExt, IDONull.Value)

            lszExpDocDir = oInvokeResponseData.Parameters(0).Value
            lszExpDocPrefix = oInvokeResponseData.Parameters(1).Value
            lszExpDocExt = oInvokeResponseData.Parameters(2).Value
            oInvokeResponseData = Nothing

            If Len(lszInvNum) = 0 Then
                lszInvNum = String.Empty
            End If


            'oInvokeResponseData = Me.Invoke("ExtInterfaceDoInfoSp", vDoNum, lszInvNum, 0, lszDoHdrInfo, lszDoLineInfo)

            'lszDoHdrInfo = oInvokeResponseData.Parameters(0).Value
            'lszDoLineInfo = oInvokeResponseData.Parameters(1).Value
            'oInvokeResponseData = Nothing

            lvaHeader = Split(lszDoHdrInfo, "/~")

            If InStr(1, lszDoLineInfo, "//~~") > 0 Then
                lboLinesExist = True
                lvaLines = Split(lszDoLineInfo, "//~~")
            Else
                lvaLines = Nothing
                lboLinesExist = False
            End If

            lszFileName = lszExpDocDir
            If Right(lszFileName, 1) <> "\" Then lszFileName = lszFileName & "\"
            lszFileName = lszFileName & lszExpDocPrefix & vDoNum & "." & lszExpDocExt

            linFile = FreeFile()

            FileOpen(linFile, lszFileName, OpenMode.Output)
            Print(linFile, "Record Type                  :Invoice Header")
            Print(linFile, "Invoice Reference            :" & Left(lvaHeader(0), 30))

            If Len(lvaHeader(1)) > 0 Then
                Print(linFile, "Invoice Number               :" & Trim(Left(lvaHeader(1), 12)))
            End If

            Print(linFile, "Customer Account Number      :" & Trim(Left(lvaHeader(2), 12)))
            Print(linFile, "Consignee Name               :" & Left(lvaHeader(3), 40))
            Print(linFile, "Consignee Address 1          :" & Left(lvaHeader(4), 40))
            Print(linFile, "Consignee Address 2          :" & Left(lvaHeader(5), 40))
            Print(linFile, "Consignee Address 3          :" & Left(lvaHeader(6), 40))
            Print(linFile, "Consignee Address 4          :" & Left(lvaHeader(7), 40))
            Print(linFile, "Consignee Address 5          :" & Left(lvaHeader(8), 40))
            Print(linFile, "Buyer Name                   :" & Left(lvaHeader(9), 40))
            Print(linFile, "Buyer Address 1              :" & Left(lvaHeader(10), 40))
            Print(linFile, "Buyer Address 2              :" & Left(lvaHeader(11), 40))
            Print(linFile, "Buyer Address 3              :" & Left(lvaHeader(12), 40))
            Print(linFile, "Buyer Address 4              :" & Left(lvaHeader(13), 40))
            Print(linFile, "Buyer Address 5              :" & Left(lvaHeader(14), 40))
            Print(linFile, "Buyer Country Code           :" & Left(lvaHeader(15), 4))
            Print(linFile, "Buyer VAT No                 :" & Left(lvaHeader(16), 20))
            If Len(lvaHeader(1)) > 0 Then
                Print(linFile, "Invoice Date                 :" & Format(lvaHeader(17)))
            End If
            Print(linFile, "Currency Code                :" & Left(lvaHeader(18), 4))
            Print(linFile, "Currency Description         :" & Left(lvaHeader(19), 20))

            If lboLinesExist Then
                For linIndex = 0 To UBound(lvaLines) - 1
                    lvaDetail = Split(lvaLines(linIndex), "/~")

                    If Len(lvaHeader(1)) = 0 Or Trim(lvaDetail(22)) <> "1" Then

                        linNoteStep = 3
                        For linNoteIdx = 0 To 8
                            If Len(lvaDetail(linNoteStep)) > 35 Then
                                If InStr(1, lvaDetail(linNoteStep), " ") > 35 Then
                                    lvaNotes(linNoteIdx) = lvaDetail(linNoteStep)
                                    lvaDetail(linNoteStep) = Mid(lvaDetail(linNoteStep), 36)
                                Else
                                    For linNoteIdx2 = 36 To 0 Step -1
                                        If Mid(lvaDetail(linNoteStep), linNoteIdx2, 1) = " " Then Exit For
                                    Next
                                    lvaNotes(linNoteIdx) = Left(lvaDetail(linNoteStep), linNoteIdx2 - 1)
                                    lvaDetail(linNoteStep) = Mid(lvaDetail(linNoteStep), linNoteIdx2 + 1)
                                End If
                            Else
                                lvaNotes(linNoteIdx) = lvaDetail(linNoteStep)
                                linNoteStep = linNoteStep + 1
                            End If
                        Next

                        Print(linFile, "Record Type                  :LineItem")
                        Print(linFile, "Invoice Reference            :" & Left(lvaDetail(0), 30))
                        Print(linFile, "Item Number                  :" & Trim(Left(lvaDetail(1), 10)))
                        Print(linFile, "Product Code                 :" & Left(lvaDetail(2), 14))
                        Print(linFile, "Product Description 1        :" & Left(lvaNotes(0), 35))
                        Print(linFile, "Product Description 2        :" & Left(lvaNotes(1), 35))
                        Print(linFile, "Product Description 3        :" & Left(lvaNotes(2), 35))
                        Print(linFile, "Extended Description 1       :" & Left(lvaNotes(3), 35))
                        Print(linFile, "Extended Description 2       :" & Left(lvaNotes(4), 35))
                        Print(linFile, "Extended Description 3       :" & Left(lvaNotes(5), 35))
                        Print(linFile, "Extended Description 4       :" & Left(lvaNotes(6), 35))
                        Print(linFile, "Extended Description 5       :" & Left(lvaNotes(7), 35))
                        Print(linFile, "Extended Description 6       :" & Left(lvaNotes(8), 35))
                        Print(linFile, "Tariff Code                  :" & Left(lvaDetail(12), 8))
                        Print(linFile, "Our Reference                :" & Trim(Left(lvaDetail(13), 10)))
                        Print(linFile, "Your Reference               :" & Left(lvaDetail(14), 20))
                        Print(linFile, "Selling Unit                 :" & Left(lvaDetail(15), 10))
                        Print(linFile, "Quantity                     :" & Trim(lvaDetail(16)))

                        If IsNumeric(lvaDetail(17)) And IsNumeric(lvaDetail(18)) Then
                            Print(linFile, "Unit Price                   :" & Trim((lvaDetail(17))))
                            Print(linFile, "Extended Value               :" & Trim((lvaDetail(18))))
                        Else
                            Print(linFile, "Unit Price                   :" & Trim(lvaDetail(17)))
                            Print(linFile, "Extended Value               :" & Trim(lvaDetail(18)))
                        End If

                        Print(linFile, "Customer Part No             :" & lvaDetail(19))
                        Print(linFile, "Manufacturer Code            :")
                        Print(linFile, "Country Of Origin            :" & lvaDetail(20))
                    Else
                        Print(linFile, "Record Type                  :Invoice Charges")
                        Print(linFile, "Charges/Disc Description     :" & lvaDetail(21))

                        If IsNumeric(lvaDetail(18)) Then
                            Print(linFile, "Charges/Disc Value           :" & Trim(lvaDetail(18)))
                        Else
                            Print(linFile, "Charges/Disc Value           :" & Trim(lvaDetail(18)))
                        End If
                    End If
                Next
            End If

            If Len(lvaHeader(1)) > 0 Then
                If IsNumeric(lvaHeader(20)) Then
                    If CDec(lvaHeader(20)) > 0 Then
                        Print(linFile, "Record Type                  :Invoice Charges")
                        Print(linFile, "Charges/Disc Description     :Misc. Charges")
                        Print(linFile, "Charges/Disc Value           :" & Trim(lvaHeader(20)))
                    End If
                End If

                If IsNumeric(lvaHeader(21)) Then
                    If CDec(lvaHeader(21)) > 0 Then
                        Print(linFile, "Record Type                  :Invoice Charges")
                        Print(linFile, "Charges/Disc Description     :Sales Tax")
                        Print(linFile, "Charges/Disc Value           :" & Trim(lvaHeader(21)))
                    End If
                End If

                If IsNumeric(lvaHeader(22)) Then
                    If CDec(lvaHeader(22)) > 0 Then
                        Print(linFile, "Record Type                  :Invoice Charges")
                        Print(linFile, "Charges/Disc Description     :Freight")
                        Print(linFile, "Charges/Disc Value           :" & Trim(lvaHeader(22)))
                    End If
                End If

                If IsNumeric(lvaHeader(23)) Then
                    If CDec(lvaHeader(23)) > 0 Then
                        Print(linFile, "Record Type                  :Invoice Charges")
                        Print(linFile, "Charges/Disc Description     :Sales Tax 2")
                        Print(linFile, "Charges/Disc Value           :" & Trim(lvaHeader(23)))
                    End If
                End If
            End If

            FileClose(linFile)
            'lobjXML = Nothing

            Return 0

        Catch ex As Exception
            FileClose(linFile)
            'lobjXML = Nothing
            mFaultString = ex.ToString()
            Return 16
        End Try


    End Function

    Public ReadOnly Property FaultString() As String
        Get
            FaultString = mFaultString
        End Get

    End Property

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ChgDoBolStatSp(ByVal PText As String, ByVal IOldDoStat As String, ByVal INewDoStat As String, ByVal SDoBolNum As String, ByVal EDoBolNum As String, ByVal SCustNum As String, ByVal ECustNum As String, ByVal SShipToNum As Integer?, ByVal EShipToNum As Integer?, ByVal SPickupDate As DateTime?, ByVal EPickupDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingPickupDateOffset As Short?,
<[Optional]> ByVal EndingPickupDateOffset As Short?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))

            Dim iChgDoBolStatExt As IChgDoBolStat = New ChgDoBolStatFactory().Create(appDb, bunchedLoadCollection)

            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iChgDoBolStatExt.ChgDoBolStatSp(PText, IOldDoStat, INewDoStat, SDoBolNum, EDoBolNum, SCustNum, ECustNum, SShipToNum, EShipToNum, SPickupDate, EPickupDate, Infobar, StartingPickupDateOffset, EndingPickupDateOffset)

            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar

            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CpDoSp(ByVal FromDoNum As String, ByVal CopyLines As String, ByVal StartLineNum As Integer?, ByVal EndLineNum As Integer?, ByRef ToDoNum As String, ByVal CopyOption As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCpDoExt As ICpDo = New CpDoFactory().Create(appDb)

            Dim Severity As Integer = iCpDoExt.CpDoSp(FromDoNum, CopyLines, StartLineNum, EndLineNum, ToDoNum, CopyOption, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DelDoSp(ByVal stat As String, ByVal do_num_start As String, ByVal do_num_end As String, ByVal cust_num_start As String, ByVal cust_num_end As String, ByVal cust_seq_start As Integer?, ByVal cust_seq_end As Integer?, ByVal pu_date_start As DateTime?, ByVal pu_date_end As DateTime?, ByVal pu_date_null As Integer?, ByRef Infobar As String,
<[Optional]> ByVal StartingPUDateOffset As Short?,
<[Optional]> ByVal EndingPUDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDelDoExt As IDelDo = New DelDoFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDelDoExt.DelDoSp(stat, do_num_start, do_num_end, cust_num_start, cust_num_end, cust_seq_start, cust_seq_end, pu_date_start, pu_date_end, pu_date_null, Infobar, StartingPUDateOffset, EndingPUDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtInterfaceDeliveryOrderSp(ByVal StartingDo As String, ByVal EndingDo As String, ByVal PrPickupDate As Byte?, ByVal PrDoSeqText As Byte?, ByVal PrDoLineText As Byte?, ByVal PrDoText As Byte?, ByVal PageByDoLine As Byte?, ByVal PrSerialNumbers As Byte?, ByVal StatingCust As String, ByVal EndingCust As String, ByVal StatingShipTo As Integer?, ByVal EndingShipTo As Integer?, ByVal StatingPickupDate As DateTime?, ByVal EndingPickupDate As DateTime?, ByVal StatingPickupDateOffset As Short?, ByVal EndingPickupDateOffset As Short?, ByVal ShowInternal As Byte?, ByVal ShowExternal As Byte?, ByVal DisplayHeader As Byte?, ByVal TaskId As Integer?, ByRef DoHdrList As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iExtInterfaceDeliveryOrderExt As IExtInterfaceDeliveryOrder = New ExtInterfaceDeliveryOrderFactory().Create(appDb)

            Dim Severity As Integer = iExtInterfaceDeliveryOrderExt.ExtInterfaceDeliveryOrderSp(StartingDo, EndingDo, PrPickupDate, PrDoSeqText, PrDoLineText, PrDoText, PageByDoLine, PrSerialNumbers, StatingCust, EndingCust, StatingShipTo, EndingShipTo, StatingPickupDate, EndingPickupDate, StatingPickupDateOffset, EndingPickupDateOffset, ShowInternal, ShowExternal, DisplayHeader, TaskId, DoHdrList)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtInterfaceParmsSp(ByRef ExpDocDir As String, ByRef ExpDocPrefix As String, ByRef ExpDocExt As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iExtInterfaceParmsExt As IExtInterfaceParms = New ExtInterfaceParmsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ExpDocDir As String, ExpDocPrefix As String, ExpDocExt As String, Infobar As String) = iExtInterfaceParmsExt.ExtInterfaceParmsSp(ExpDocDir, ExpDocPrefix, ExpDocExt, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ExpDocDir = result.ExpDocDir
            ExpDocPrefix = result.ExpDocPrefix
            ExpDocExt = result.ExpDocExt
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function ProfileBillofLadingSp(
<[Optional]> ByVal DOStarting As String,
<[Optional]> ByVal DOEnding As String,
<[Optional]> ByVal CustomerStarting As String,
<[Optional]> ByVal CustomerEnding As String,
<[Optional]> ByVal CustSeqStarting As Integer?,
<[Optional]> ByVal CustSeqEnding As Integer?,
<[Optional]> ByVal PickupDateStarting As DateTime?,
<[Optional]> ByVal PickupDateEnding As DateTime?,
<[Optional]> ByVal PickupDateStartingOffset As Short?,
<[Optional]> ByVal PickupDateEndingOffset As Short?,
<[Optional]> ByVal DisplayHeader As Byte?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iProfileBillofLadingExt As IProfileBillofLading = New ProfileBillofLadingFactory().Create(appDb, bunchedLoadCollection)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iProfileBillofLadingExt.ProfileBillofLadingSp(DOStarting, DOEnding, CustomerStarting, CustomerEnding, CustSeqStarting, CustSeqEnding, PickupDateStarting, PickupDateEnding, PickupDateStartingOffset, PickupDateEndingOffset, DisplayHeader)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateFromDoNumForCopySp(ByVal FROMDoNum As String, ByRef CopyLines As String, ByRef StartLineNum As Integer?, ByRef EndLineNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateFromDoNumForCopyExt As IValidateFromDoNumForCopy = New ValidateFromDoNumForCopyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CopyLines As String, StartLineNum As Integer?, EndLineNum As Integer?, Infobar As String) = iValidateFromDoNumForCopyExt.ValidateFromDoNumForCopySp(FROMDoNum, CopyLines, StartLineNum, EndLineNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CopyLines = result.CopyLines
            StartLineNum = result.StartLineNum
            EndLineNum = result.EndLineNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ValidateToDoNumForCopySp(ByVal FROMDoNum As String, ByVal ToDoNum As String, ByRef CopyLines As String, ByRef CopyOption As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iValidateToDoNumForCopyExt As IValidateToDoNumForCopy = New ValidateToDoNumForCopyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CopyLines As String, CopyOption As String, Infobar As String) = iValidateToDoNumForCopyExt.ValidateToDoNumForCopySp(FROMDoNum, ToDoNum, CopyLines, CopyOption, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CopyLines = result.CopyLines
            CopyOption = result.CopyOption
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ExtInterfaceDoInfoSp(ByVal DoNum As String, ByVal InvNum As String, ByVal InvSeq As Integer?, ByRef DoHdrInfo As String, ByRef DoLineInfo As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iExtInterfaceDoInfoExt As IExtInterfaceDoInfo = New ExtInterfaceDoInfoFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DoHdrInfo As String, DoLineInfo As String) = iExtInterfaceDoInfoExt.ExtInterfaceDoInfoSp(DoNum, InvNum, InvSeq, DoHdrInfo, DoLineInfo)
            Dim Severity As Integer = result.ReturnCode.Value
            DoHdrInfo = result.DoHdrInfo
            DoLineInfo = result.DoLineInfo
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function InsertDoLineSp(ByVal DoNum As String, ByRef DoLine As Integer?, ByRef ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iInsertDoLineExt As IInsertDoLine = New InsertDoLineFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DoLine As Integer?, ErrorMsg As String) = iInsertDoLineExt.InsertDoLineSp(DoNum, DoLine, ErrorMsg)
            Dim Severity As Integer = result.ReturnCode.Value
            DoLine = result.DoLine
            ErrorMsg = result.ErrorMsg
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_DomesticCurrencySp(ByVal CurrCode As String,
<[Optional], DefaultParameterValue(0)> ByVal UseBuyRate As Integer?,
<[Optional]> ByVal TRate As Decimal?,
<[Optional]> ByVal PossibleDate As DateTime?,
<[Optional]> ByVal Amount1 As Decimal?,
<[Optional]> ByVal Amount2 As Decimal?,
<[Optional]> ByVal Amount3 As Decimal?,
<[Optional]> ByVal Amount4 As Decimal?,
<[Optional]> ByVal Amount5 As Decimal?,
<[Optional]> ByVal Amount6 As Decimal?,
<[Optional]> ByVal Amount7 As Decimal?,
<[Optional]> ByVal Amount8 As Decimal?,
<[Optional]> ByVal Amount9 As Decimal?,
<[Optional]> ByVal Amount10 As Decimal?,
<[Optional]> ByVal Amount11 As Decimal?,
<[Optional]> ByVal Amount12 As Decimal?,
<[Optional]> ByVal Amount13 As Decimal?,
<[Optional]> ByVal Amount14 As Decimal?,
<[Optional]> ByVal Amount15 As Decimal?,
<[Optional]> ByVal Amount16 As Decimal?,
<[Optional]> ByVal Amount17 As Decimal?,
<[Optional]> ByVal Amount18 As Decimal?,
<[Optional]> ByVal Amount19 As Decimal?,
<[Optional]> ByVal Amount20 As Decimal?,
<[Optional]> ByVal Amount21 As Decimal?,
<[Optional]> ByVal Amount22 As Decimal?,
<[Optional]> ByVal Amount23 As Decimal?,
<[Optional]> ByVal Amount24 As Decimal?,
<[Optional]> ByVal Amount25 As Decimal?,
<[Optional]> ByVal Amount26 As Decimal?,
<[Optional]> ByVal Amount27 As Decimal?,
<[Optional]> ByVal Amount28 As Decimal?,
<[Optional]> ByVal Amount29 As Decimal?,
<[Optional]> ByVal Amount30 As Decimal?,
<[Optional]> ByVal Amount31 As Decimal?,
<[Optional]> ByVal Amount32 As Decimal?,
<[Optional]> ByVal Amount33 As Decimal?,
<[Optional]> ByVal Amount34 As Decimal?,
<[Optional]> ByVal Amount35 As Decimal?,
<[Optional]> ByVal Amount36 As Decimal?,
<[Optional]> ByVal Amount37 As Decimal?,
<[Optional]> ByVal Amount38 As Decimal?,
<[Optional]> ByVal Amount39 As Decimal?,
<[Optional]> ByVal Amount40 As Decimal?) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iCLM_DomesticCurrencyExt As CSI.Logistics.Customer.ICLM_DomesticCurrency = New CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(Me, True)
            Dim result As (Data As ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode, UseBuyRate, TRate, PossibleDate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Amount16, Amount17, Amount18, Amount19, Amount20, Amount21, Amount22, Amount23, Amount24, Amount25, Amount26, Amount27, Amount28, Amount29, Amount30, Amount31, Amount32, Amount33, Amount34, Amount35, Amount36, Amount37, Amount38, Amount39, Amount40)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PurgeEDIAdvanceShippingNotices(
    <[Optional]> ByVal CustomerStarting As String,
    <[Optional]> ByVal CustomerEnding As String,
    <[Optional]> ByVal CDateStarting As DateTime?,
    <[Optional]> ByVal CDateEnding As DateTime?,
    <[Optional]> ByVal ExOptprPostedEmp As String,
    <[Optional]> ByVal CDateStartingOffset As Short?,
    <[Optional]> ByVal CDateEndingOffset As Short?,
    <[Optional]> ByRef Message As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPurgeEDIASNExt As IPurgeEDIASN = New PurgeEDIASNFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Message As String) = iPurgeEDIASNExt.PurgeEDIASNSp(CustomerStarting, CustomerEnding, CDateStarting, CDateEnding, ExOptprPostedEmp, CDateStartingOffset, CDateEndingOffset, Message)
            Dim Severity As Integer = result.ReturnCode.Value
            Message = result.Message
            Return Severity
        End Using
    End Function
End Class
