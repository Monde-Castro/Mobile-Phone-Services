Public Class frmMobileService

    'Declare arrays
    Dim decArrPayment() As Decimal
    Dim strArrMonth() As String
    Dim intCounter As Integer

    Private Sub frmMobileService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Prevent Error if arrays are empty
        btnDisplay.Enabled = False
    End Sub

    Private Function CalcAverage() As Decimal
        'Calculate and return the Average Monthly Payment
        Dim J As Integer
        Dim decTotal As Decimal = 0
        Dim decCalcAverage As Decimal = 0

        For J = 0 To UBound(decArrPayment)
            decTotal = decTotal + decArrPayment(J)
        Next
        decCalcAverage = decTotal / intCounter

        Return decCalcAverage
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Check for empty Month textbox
        If txtMonth.Text = " " Then
            Beep()
            MessageBox.Show("Enter a Month", "Enter Error ")
            txtMonth.Focus()
            Exit Sub
        End If

        'Re-dimension Arrays every time a new element is added
        'Preserve keeps data elements that is already in Array
        ReDim Preserve strArrMonth(intCounter)
        ReDim Preserve decArrPayment(intCounter)



        'Assign contents of Month textbox to array variable
        strArrMonth(intCounter) = txtMonth.Text

        'Check for valid Numeric input
        If IsNumeric(txtPayment.Text) Then
            decArrPayment(intCounter) = CDec(txtPayment.Text)
        Else
            Beep()
            MessageBox.Show("Enter a valid payment", "Enter Error")
            txtPayment.Clear()
            txtPayment.Focus()
            Exit Sub
        End If

        intCounter = intCounter + 1

        'Reset Control properties
        txtMonth.Clear()
        txtPayment.Clear()
        txtMonth.Focus()

        If btnDisplay.Enabled = False Then
            btnDisplay.Enabled = True
        End If

    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        'Display data in Listbox
        'Calculate the Average Monthly Payment
        'Display the Monthly Payments above the Average Payment

        Dim J As Integer
        Dim decAverage As Decimal

        lstDisplay.Items.Clear()
        lstDisplay.Items.Add("")
        lstDisplay.Items.Add("Month".PadRight(20) & "Payment".PadLeft(10))

        lstDisplay.Items.Add("")

        For J = 0 To UBound(strArrMonth)
            lstDisplay.Items.Add(strArrMonth(J).PadRight(20) &
            decArrPayment(J).ToString("C2").PadLeft(10))
        Next

        'Call Function to calculate Average Monthly Payment
        decAverage = CalcAverage()

        'Display Months and Payments greater than the Average Payment in the listbox
        lstDisplay.Items.Add("")
        lstDisplay.Items.Add("Average Monthly Payments : ".PadRight(20) &
                             decAverage.ToString("C2").PadLeft(10))
        lstDisplay.Items.Add("")
        lstDisplay.Items.Add("Month(s) with an above Average Payment(s) : ")
        lstDisplay.Items.Add("")

        'Display Months And Paymentd greater then Average Payments in the listbox

        For J = 0 To UBound(strArrMonth)
            If decArrPayment(J) > decAverage Then
                lstDisplay.Items.Add(strArrMonth(J).PadRight(20) &
                                     decArrPayment(J).ToString("C2").PadLeft(10))
            End If
        Next


        'Set focus to Month textbox
        txtMonth.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear the listbox and set focus to the month textbox
        lstDisplay.Items.Clear()
        txtMonth.Focus()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Close the form and terminate the program
        Close()

    End Sub
End Class
