Namespace Utilities

    ''' <summary>
    ''' It exposes useful methods for handling datasets
    ''' </summary>
    Public Class Data

        ''' <summary>
        ''' Determines if the first row of the first table contains information.
        ''' </summary>
        ''' <param name="pDataSet">The instance of the dataset to be evaluated.</param>
        ''' <returns>Returns true if the first row of the first table contains data.</returns>
        Public Shared Function FirstTableHasRows(ByVal pDataSet As System.Data.DataSet) As Boolean
            Dim lReturnValue As Boolean = False

            If Not (pDataSet Is Nothing) Then
                If (pDataSet.Tables.Count > 0) Then
                    If (pDataSet.Tables(0).Rows.Count > 0) Then
                        lReturnValue = True
                    End If
                End If
            End If

            Return lReturnValue
        End Function
    End Class
End Namespace

