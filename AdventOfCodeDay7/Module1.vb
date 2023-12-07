Imports System.Diagnostics.SymbolStore
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.Linq

Module Module1

    Structure Hand
        Dim labels As String
        Dim secLabels As String
        Dim bet As Integer
        Dim handType As String
    End Structure


    Sub Main()
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day7Input.txt")
        'Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day7Test.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim allHands(0) As Hand
        Dim i As Integer
        Dim outputValue
        Do
            ReDim Preserve allHands(i)
            Dim splitValues As String() = Split(textInput, " ")
            allHands(i).labels = splitValues(0)
            allHands(i).bet = splitValues(1)
            allHands(i).handType = FindHandType(allHands(i))
            allHands(i).secLabels = ConvertToSecondLabel(allHands(i).labels)

            i += 1
            textInput = fileReader.ReadLine()
        Loop Until textInput = ""



        Dim sortQuery = From h In allHands
                        Order By h.handType Descending, h.secLabels Ascending
                        Select h

        Dim sb As New System.Text.StringBuilder()
        Dim rank = 1
        For Each hand As Hand In sortQuery
            Console.WriteLine(hand.labels & " " & hand.bet)
            outputValue += hand.bet * rank
            rank += 1
        Next


        Console.WriteLine(outputValue)
        Console.ReadLine()

    End Sub

    Function ConvertToSecondLabel(labels As String)
        Dim word As String
        For i = 0 To labels.Length - 1
            Select Case labels(i)
                Case "A"
                    word += "E"
                Case "K"
                    word += "D"
                Case "Q"
                    word += "C"
                Case "J"
                    word += "1"
                Case "T"
                    word += "A"
                Case Else
                    word += labels(i)
            End Select

        Next
        Return word
    End Function

    Function FindHandType(hand As Hand)
        Dim count(45) As Integer?
        Dim value(4) As Integer
        Dim currentPosition As Integer = 0
        Dim Jcounter As Integer = 0
        Dim handType As String
        Dim handType2 As String
        Dim jokerPosition As Integer
        For a = 0 To count.Length - 1
            count(a) = 0
        Next
        For a = 0 To 4

            If hand.labels.Substring(a, 1) = "J" Then
                Jcounter += 1

            End If
            count(Asc(hand.labels.Substring(a, 1)) - 48) += 1

        Next
        For a = 0 To 44
            If Not (count(a) = 0) Then
                If a = 26 Then

                    jokerPosition = currentPosition

                End If
                value(currentPosition) = count(a)
                currentPosition += 1
            End If
        Next


        If value.Contains(5) Then
            handType = "A"
        ElseIf value.Contains(4) Then
            handType = "B"
        ElseIf (value(1) + value(0)) = 5 Then
            handType = "C"
        ElseIf value.Contains(3) Then
            handType = "D"
        ElseIf value.Count(Function(x) x = "2") = 2 Then
            handType = "E"
        ElseIf value.Contains(2) Then
            handType = "F"
        Else
            handType = "G"
        End If


        For i = 0 To 4
            If Not (i = jokerPosition) Then
                value(i) += Jcounter
            End If
        Next
        If value.Contains(5) Then
            Console.WriteLine("||||||||")
            Console.WriteLine(hand.labels)
            handType2 = "A"
        ElseIf value.Contains(4) Then

            handType2 = "B"
        ElseIf (value.Count(Function(x) x = "3") = 2) And Jcounter = 1 Then

            handType2 = "C"
        ElseIf value.Contains(3) Then
            handType2 = "D"
        ElseIf value.Count(Function(x) x = "2") = 2 Then
            handType2 = "E"
        ElseIf value.Contains(2) Then
            handType2 = "F"
        Else
            handType2 = "G"
        End If

        If Asc(handType2.Substring(0, 1)) < Asc(handType.Substring(0, 1)) Then
            handType = handType2
        End If
        Return handType
    End Function

End Module
'253864580 Too High
'253674297 Wrong
'253611184 Wrong
