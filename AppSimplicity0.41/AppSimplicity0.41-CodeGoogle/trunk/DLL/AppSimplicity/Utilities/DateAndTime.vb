Imports System.Threading

Namespace Utilities.DateAndTime

#Region "DateRange"
    <Serializable()> _
    Public Class DateRange

        Public Enum DateTemplates
            AllDates = 1
            JustToday = 2
            CurrentMonthTilToday = 3
            CurrentYearTilToday = 4
            AllDatesBeforeToday = 5
            AllDatesAfterToday = 6
            LastWeek = 7
            LastMonth = 8
        End Enum

        Private _InitDate As New System.Nullable(Of DateTime)
        Public Property InitDate() As System.Nullable(Of DateTime)
            Get
                Return _InitDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _InitDate = value
            End Set
        End Property

        Private _EndDate As New System.Nullable(Of DateTime)
        Public Property EndDate() As System.Nullable(Of DateTime)
            Get
                Return _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDate = value
            End Set
        End Property

        Public Sub New()
            _InitDate = Nothing
            _EndDate = Nothing
        End Sub

        Public Function GetDescription() As String
            Return DateFormatter.GetDateRangeDescription(Me)
        End Function

        Public Function IsToday(ByVal pDate As DateTime) As Boolean
            Dim lReturnValue As Boolean = False

            If (DateDiff(DateInterval.Day, Date.Now, pDate) = 0) Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function

        Public Function IsTodaySelected() As Boolean
            Dim lReturnValue As Boolean = False
            Dim lToday As New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day)

            If (Me.InitDate.HasValue) Then
                If (IsToday(Me.InitDate.Value)) Then
                    If (Me.EndDate.HasValue) Then
                        If (IsToday(Me.EndDate.Value)) Then
                            lReturnValue = True
                        End If
                    End If
                End If
            End If

            Return lReturnValue
        End Function

        Public Function InitDate_EndDate_IsTheSame() As Boolean
            Dim lReturnValue As Boolean = False

            If (DateDiff(DateInterval.Day, Me.InitDate.Value, Me.EndDate.Value) = 0) Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function

        Private Sub CalculateLastWeek()
            Dim lLastWeekDay As Date = Date.Now.AddDays(-7)

            Dim lADayLess As Integer = 0
            Dim lFindMonday As Boolean = False
            While (lFindMonday = False)
                Dim lDayBefore As Date = lLastWeekDay.AddDays(lADayLess)

                If (lDayBefore.DayOfWeek = 1) Then
                    Me.InitDate = lDayBefore
                    Me.EndDate = lDayBefore.AddDays(6)

                    lFindMonday = True
                End If

                lADayLess = lADayLess - 1
            End While
        End Sub

        Private Sub CalculateLastMonth()
            Dim lFirstDayOfLastMonth As Date
            Dim lLastDayOfLastMonth As Date

            '  Dim lLastMont As Integer = Date.Now.Month

            If (Date.Now.Month = 1) Then
                lFirstDayOfLastMonth = New Date(Date.Now.Year - 1, 12, 1)
            Else
                lFirstDayOfLastMonth = New Date(Date.Now.Year, Date.Now.Month - 1, 1)
            End If

            If (lFirstDayOfLastMonth.Month = 12) Then
                lLastDayOfLastMonth = New Date(lFirstDayOfLastMonth.Year + 1, 1, 1)
            Else
                lFirstDayOfLastMonth = New Date(lFirstDayOfLastMonth.Year, lFirstDayOfLastMonth.Month + 1, 1)
            End If

            lLastDayOfLastMonth = lLastDayOfLastMonth.AddDays(-1)

            Me.InitDate = lFirstDayOfLastMonth
            Me.EndDate = lLastDayOfLastMonth
        End Sub

        Public Sub SetTemplate(ByVal pTemplate As DateTemplates)
            Select Case (pTemplate)
                Case DateTemplates.JustToday
                    Me.InitDate = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day)
                    Me.EndDate = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day)

                Case DateTemplates.AllDates
                    Me.InitDate = Nothing
                    Me.EndDate = Nothing

                Case DateTemplates.AllDatesAfterToday
                    Me.InitDate = Date.Now
                    Me.EndDate = Nothing

                Case DateTemplates.AllDatesBeforeToday
                    Me.InitDate = Nothing
                    Me.EndDate = Date.Now

                Case DateTemplates.CurrentMonthTilToday
                    Me.InitDate = New DateTime(Date.Now.Year, Date.Now.Month, 1)
                    Me.EndDate = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day)

                Case DateTemplates.CurrentYearTilToday
                    Me.InitDate = New DateTime(Date.Now.Year, 1, 1)
                    Me.EndDate = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day)
              
                Case DateTemplates.LastWeek
                    Me.CalculateLastWeek()

                Case DateTemplates.LastMonth
                    Me.CalculateLastMonth()
            End Select
        End Sub
    End Class
#End Region

    Public Class DateFormatter
        Public Shared Function FormatToString(ByVal pDate As DateTime) As String
            Dim lFormatter As New DateFormatter

            Return lFormatter.FormatDate(pDate)
        End Function

        Public Shared Function Parse(ByVal pDate As String) As DateTime
            Dim lFormatter As New DateFormatter

            Return lFormatter.ParseDate(pDate)
        End Function

        Public Shared Function GetDateRangeDescription(ByVal pDateRange As DateRange) As String
            Dim lReturnValue As String = String.Empty

            If (pDateRange.InitDate.HasValue) Then
                If (pDateRange.EndDate.HasValue) Then
                    If (pDateRange.IsTodaySelected) Then
                        'Si "hoy" está seleccionado:
                        Select Case (DateFormatter.Culture)
                            Case Cultures.EN
                                lReturnValue = String.Format("Just today {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                            Case Cultures.ES
                                lReturnValue = String.Format("Sólo hoy {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                        End Select
                    Else
                        If (pDateRange.InitDate_EndDate_IsTheSame) Then
                            'Si el dia inicial y el dia final son el mismo:
                            Select Case (DateFormatter.Culture)
                                Case Cultures.EN
                                    lReturnValue = String.Format("Only {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                                Case Cultures.ES
                                    lReturnValue = String.Format("Sólo el día {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                            End Select
                        Else
                            'Rango específico
                            Select Case (DateFormatter.Culture)
                                Case Cultures.EN
                                    lReturnValue = String.Format("Days between {0} and {1}", DateFormatter.FormatToString(pDateRange.InitDate.Value), DateFormatter.FormatToString(pDateRange.EndDate.Value))
                                Case Cultures.ES
                                    lReturnValue = String.Format("Los días desde el {0} hasta el {1} únicamente", DateFormatter.FormatToString(pDateRange.InitDate.Value), DateFormatter.FormatToString(pDateRange.EndDate.Value))
                            End Select
                        End If
                    End If
                Else
                    If (pDateRange.IsToday(pDateRange.InitDate)) Then
                        'Si no existe fecha inicial o final:
                        Select Case (DateFormatter.Culture)
                            Case Cultures.EN
                                lReturnValue = String.Format("Days from today {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                            Case Cultures.ES
                                lReturnValue = String.Format("Sólo los días a partir de hoy {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                        End Select
                    Else
                        'Si no existe fecha inicial o final:
                        Select Case (DateFormatter.Culture)
                            Case Cultures.EN
                                lReturnValue = String.Format("Days from {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                            Case Cultures.ES
                                lReturnValue = String.Format("Sólo los días a partir del {0}", DateFormatter.FormatToString(pDateRange.InitDate.Value))
                        End Select
                    End If
                End If
            Else
                If (pDateRange.EndDate.HasValue) Then
                    If (pDateRange.IsToday(pDateRange.EndDate.Value)) Then
                        'Si no existe fecha inicial o final:
                        Select Case (DateFormatter.Culture)
                            Case Cultures.EN
                                lReturnValue = String.Format("All days until today {0}", DateFormatter.FormatToString(pDateRange.EndDate.Value))
                            Case Cultures.ES
                                lReturnValue = String.Format("Todos los días hasta hoy {0}", DateFormatter.FormatToString(pDateRange.EndDate.Value))
                        End Select
                    Else
                        'Si no existe fecha inicial o final:
                        Select Case (DateFormatter.Culture)
                            Case Cultures.EN
                                lReturnValue = String.Format("All days until {0}", DateFormatter.FormatToString(pDateRange.EndDate.Value))
                            Case Cultures.ES
                                lReturnValue = String.Format("Todos los días anteriores hasta el {0}", DateFormatter.FormatToString(pDateRange.EndDate.Value))
                        End Select
                    End If
                Else
                    'Si no existe fecha inicial o final:
                    Select Case (DateFormatter.Culture)
                        Case Cultures.EN
                            lReturnValue = String.Format("All dates")
                        Case Cultures.ES
                            lReturnValue = String.Format("Todas las fechas")
                    End Select
                End If
            End If

            Return lReturnValue
        End Function

        Public Shared Function Culture() As Cultures
            Dim lFormatter As New DateFormatter

            Return lFormatter.CurrentCulture
        End Function

        Private _ES_MonthShortDescriptions As String() = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}
        Private _EN_MonthShortDescriptions As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

        Public Enum Cultures
            ES
            EN
        End Enum

        Public ReadOnly Property CurrentCulture() As Cultures
            Get
                Dim lReturnValue As Cultures = Cultures.ES

                If (System.Globalization.CultureInfo.CurrentCulture.Name.ToLower.Contains("es")) Then
                    lReturnValue = Cultures.ES
                Else
                    lReturnValue = Cultures.EN
                End If

                Return lReturnValue
            End Get
        End Property

        Private ReadOnly Property Months() As String()
            Get
                If (Me.CurrentCulture = Cultures.ES) Then
                    Return _ES_MonthShortDescriptions
                Else
                    Return _EN_MonthShortDescriptions
                End If
            End Get
        End Property

        Private Enum DateMonths
            January
            February
            March
            April
            May
            June
            July
            August
            September
            October
            November
            December
        End Enum

        Public Function FormatDate(ByVal pDate As DateTime) As String
            Return String.Format("{0:00}/{1}/{2:0000}", pDate.Day, Me.GetMonthDescription(pDate.Month), pDate.Year)
        End Function

        Private Function GetMonthDescription(ByVal pValue As Integer) As String
            Dim lMonth As DateMonths = (pValue - 1)

            Return Me.Months(lMonth).ToLower
        End Function

        Private Function ParseMonthDescrition(ByVal pMonth As String) As Integer
            Dim lReturnValue As Integer = 0

            If (IsNumeric(pMonth)) Then
                lReturnValue = Convert.ToInt32(pMonth)
            Else
                Dim N As Integer
                For N = 0 To 11
                    If Me.Months(N).ToLower = pMonth.ToLower Then
                        lReturnValue = N + 1
                        Exit For
                    End If
                Next
            End If

            If (lReturnValue = 0) Then
                Throw New Exception("Unable to parse month.")
            End If

            Return lReturnValue
        End Function

        Public Function ParseDate(ByVal pDate As String) As DateTime
            Dim lReturnValue As DateTime = Nothing
            Dim lValue As String = pDate

            Try
                If (lValue.Length <> 11) Then
                    Throw New Exception("Invalid date format")
                End If

                Dim lDateArray As String() = lValue.Split("/")

                If (lDateArray.Length <> 3) Then
                    Throw New Exception("Invalid date format")
                End If

                lReturnValue = New Date(Convert.ToInt32(lDateArray(2)), Me.ParseMonthDescrition(lDateArray(1)), Convert.ToInt32(lDateArray(0)))

            Catch ex As Exception

            End Try

            Return lReturnValue
        End Function
    End Class
End Namespace

