Public Class Form1
    'Declaring Variables
    Dim customerid(299) As String
    Dim ticketid(299) As String
    Dim numberoftickets(299) As Integer
    Dim method(299) As String
    'This Button is the main button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_start.Click
        'Sub Routines
        'Sub Routine to read data From the document
        Call readdata(customerid, ticketid, numberoftickets, method)
        'Sub Routine To Calculate
        Call calculations(customerid, ticketid, numberoftickets, method)
        'Sub Routine To Write Data To Document
        Call writedata(customerid, ticketid, numberoftickets, method)
    End Sub
    'This Sub Contains The Code That Reads The Data
    Sub readdata(ByRef customerid, ByRef ticketid, ByRef numberoftickets, ByRef method)
        'Declaring Local Variables
        Dim newsentence, filename As String
        Dim counter As Integer
        Dim Temp(3) As String
        'Telling the computer where to find the data
        filename = "E:\Higher CS\course work\Choral Shield Data File.csv"
        'the computer reading the lines of the csv file and putting them into arrays
        Dim objtextfile As New System.IO.StreamReader(filename)
        For counter = 0 To 299
            newsentence = objtextfile.ReadLine()
            'Splits Data At Delimeter
            Temp = newsentence.Split(","c)
            customerid(counter) = Temp(0)
            ticketid(counter) = Temp(1)
            numberoftickets(counter) = Temp(2)
            method(counter) = Temp(3)
        Next
        'Closing and Disposing the file
        objtextfile.Close()
        objtextfile.Dispose()
    End Sub
    'This Sub Contains The Code That Calculates The Data
    Sub calculations(ByRef customerid, ByRef ticketid, ByRef numberoftickets, ByRef method)
        'Declaring Local Variables
        Dim counter, popular, total As Integer
        Dim msg As String
        'Making the counter so that if people buy the tickets online then it will add one to the counter a.k.a popular
        For counter = 0 To 299
            If method(counter) = "O" Then
                popular = popular + 1
            End If
        Next
        'If the counter popular is over 250 sales then thats more than half the tickets so the best sale method would be Online else School
        If popular > 250 Then
            msg = "The overall favorite method of purchase was Online"
        Else
            msg = "The overall favorite method of purchase was School"
        End If
        'Clearing the total
        total = 0
        'Pricing the nights Friday = £10 Rest = £5
        For counter = 0 To 299
            If ticketid(counter).substring(0, 1) = "F" Then
                total = total + numberoftickets(counter) * 10
            Else
                total = total + numberoftickets(counter) * 5
            End If
        Next
        LbResults.Items.Add("Essell Academy Choral Shield " & DateTime.Now.Year)
        LbResults.Items.Add(msg)
        LbResults.Items.Add("The amount of money raised is " & "£" & total)
    End Sub
    'This Sub Contains The Code That Writes The Data
    Sub writedata(ByRef customerid, ByRef ticketid, ByRef numberoftickets, ByRef method)
        'Declaring Local Variables
        Dim counter As Integer
        Dim newsentence, filename As String
        'setting filename to the destination of the file
        filename = "E:\Higher CS\course work\Test1 (2).csv"
        Dim objtextfile As New System.IO.StreamWriter(filename)
        For counter = 0 To 299
            If ticketid(counter).Substring(0, 1) = "F" Then
                newsentence = customerid(counter) & "," & ticketid(counter) & "," & numberoftickets(counter) & "," & method(counter)
                objtextfile.WriteLine(newsentence)
            End If
        Next
        'Closing The Open File
        objtextfile.Close()
    End Sub
    'This Button Clears The Text From The Listbox
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        LbResults.Items.Clear()
    End Sub
    'This Button Exits From The Program
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Close()
    End Sub

End Class
