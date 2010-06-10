Namespace ActiveRecord.Query

    Public Class ComparisonConditions

        Private _Query As QueryBuilder
        Private _Comparison As Comparison

        Private Function GetParameter(ByVal pValue As Object) As DataAccess.DataCommandParameter
            Dim lParameter As New DataAccess.DataCommandParameter

            lParameter.Name = Me._Query.Schema.DataService.Dialect.Get_ParameterName(String.Format("{0}Param{1}", _Query.Schema.TableName, _Query.ParamCount))
            lParameter.Type = Me._Comparison.Column.DataType
            lParameter.Value = pValue

            Return lParameter
        End Function

        Private Sub AddComparison(ByVal pComparison As Comparison)
            _Query.Comparisons.Add(pComparison)
        End Sub

        Public Sub New(ByVal pQuery As QueryBuilder, ByVal pComparison As ActiveRecord.Query.Comparison)
            _Query = pQuery
            _Comparison = pComparison
        End Sub

        Public Sub EqualsTo(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueEqualsTo
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(_Comparison)
        End Sub

        Public Sub ValueIsBetween(ByVal pMinValue As Object, ByVal pMaxValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsBetween
            _Comparison.Parameters.Add(Me.GetParameter(pMinValue))
            _Comparison.Parameters.Add(Me.GetParameter(pMaxValue))

            _Query.Comparisons.Add(_Comparison)
        End Sub

        Public Sub AsDateIsBetween(ByVal pMinDate As DateTime, ByVal pMaxDate As DateTime)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsBetween
            _Comparison.Parameters.Add(Me.GetParameter(pMinDate))
            _Comparison.Parameters.Add(Me.GetParameter(pMaxDate))

            _Query.Comparisons.Add(_Comparison)
        End Sub

        Public Sub AsDateEqualsTo(ByVal pDate As DateTime)

            Dim lDif As Double

            Dim lDateWithoutTime As DateTime = New DateTime(pDate.Year, pDate.Month, pDate.Day)

            lDif = pDate.Subtract(lDateWithoutTime).Minutes

            If (lDif = 0) Then
                Me.AsDateIsBetween(lDateWithoutTime, lDateWithoutTime.AddDays(1).AddSeconds(-1))
            Else
                _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueEqualsTo
                _Comparison.Parameters.Add(Me.GetParameter(pDate))

                _Query.Comparisons.Add(_Comparison)
            End If
        End Sub

        Public Sub IsLike(ByVal pText As String)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.TextIsLike
            _Comparison.Parameters.Add(Me.GetParameter(pText))

            _Query.Comparisons.Add(_Comparison)
        End Sub

        Public Sub IsGreaterThan(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsGreaterThan
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(pValue)
        End Sub

        Public Sub IsGreaterThanOrEqualsTo(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsGreaterThanOrEqualsTo
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(pValue)
        End Sub

        Public Sub IsLessThan(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsLessThan
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(pValue)
        End Sub

        Public Sub IsLessThanOrEqualsTo(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsLessThanOrEqualsTo
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(pValue)
        End Sub

        Public Sub IsDifferentFrom(ByVal pValue As Object)
            _Comparison.ComparisonType = Comparison.ComparisonOperation.ValueIsDifferentFrom
            _Comparison.Parameters.Add(Me.GetParameter(pValue))

            _Query.Comparisons.Add(pValue)
        End Sub
    End Class

End Namespace
