Module TransactionVariables

    'Public CouponApplied As Boolean = False

    Public DiscAppleid As Boolean = False
    Public SeniorDetailsID As String
    Public SeniorDetailsName As String
    Public DiscountName As String
    Public DiscountType As String = "N/A"

    Public DISCGUESTCOUNT As Integer = 0
    Public DISCIDCOUNT As Integer
    Public SeniorGCDiscount As Boolean = False

    Public PromoApplied As Boolean = False
    Public PromoName As String
    Public PromoDesc As String
    Public PromoLine As Integer = 10
    Public PromoTotal As Double
    Public PromoGCValue As Double
    Public PromoType As String = "N/A"

    Public TOTALDISCOUNT As Double = 0
    Public GROSSSALE As Double = 0
    Public VATEXEMPTSALES As Double = 0
    Public LESSVAT As Double = 0
    Public TOTALDISCOUNTEDAMOUNT As Double = 0
    Public TOTALAMOUNTDUE As Double = 0
    Public VATABLESALES As Double = 0
    Public VAT12PERCENT As Double = 0
    Public ZERORATEDSALES As Double = 0
    Public ZERORATEDNETSALES As Double = 0
    Public GETNOTDISCOUNTEDAMOUNT As Double = 0

    Public TRANSACTIONMODE As String = "Walk-In"
    'Public SENIORDETAILSBOOL As Boolean = False

    Public Sub ResetTransactionVariables()
        Try
            DiscAppleid = False
            SeniorDetailsID = ""
            SeniorDetailsName = ""
            DiscountName = ""
            DiscountType = "N/A"

            DISCGUESTCOUNT = 0
            DISCIDCOUNT = 0
            SeniorGCDiscount = False

            PromoApplied = False
            PromoName = ""
            PromoDesc = ""
            PromoLine = 10
            PromoTotal = 0
            PromoGCValue = 0
            PromoType = "N/A"

            TOTALDISCOUNT = 0
            GROSSSALE = 0
            VATEXEMPTSALES = 0
            LESSVAT = 0
            TOTALDISCOUNTEDAMOUNT = 0
            TOTALAMOUNTDUE = 0
            VATABLESALES = 0
            VAT12PERCENT = 0
            ZERORATEDSALES = 0
            ZERORATEDNETSALES = 0

            GETNOTDISCOUNTEDAMOUNT = 0
            SeniorDetails.COUPONNAME = ""
            SeniorDetails.COUPONVALUE = 0
            SeniorDetails.NOTDISCOUNTEDAMOUNT = 0

            TRANSACTIONMODE = "Walk-In"
        Catch ex As Exception
            SendErrorReport(ex.TargetSite)
        End Try
    End Sub


End Module
