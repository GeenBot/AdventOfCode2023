Imports System.IO

Module Module1

    Sub Main()
        'Reads the input into a file and then gets the first line 
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day3Input.txt")
        Dim line() As String = {"", fileReader.ReadLine, fileReader.ReadLine}
        Dim position As Integer
        Dim i As Integer
        Dim partSum As Integer
        Dim length As Integer
        Dim temp As Integer = 99

        While Not (line(1) = "")
            position = 0
            'Checks if position found a new number
            While Not (temp = position)
                temp = position
                position = FindNumber(line(1), position)
                length = FindNumberLength(line(1), position)
                partSum += CheckAdjacentWhole(position, length, line)
                Console.WriteLine(CheckAdjacentWhole(position, length, line))
                position += length
            End While
            line(0) = line(1)
            line(1) = line(2)
            line(2) = fileReader.ReadLine()
        End While
        Console.WriteLine(partSum)
        Console.ReadLine()
    End Sub

    'Finds the next possible part number
    Function FindNumber(line2 As String, position As Integer)
        Dim num As String
        Dim i As Integer = position
        Do
            If line2.Length = i Then
                i += 1
                Exit Do
            End If
            num = line2.Substring(i, 1)
            i += 1
        Loop Until (Asc(num) > 48 And Asc(num) < 58)
        Return (i - 1)
    End Function

    'Finds the length of the possible part number
    Function FindNumberLength(line2 As String, position As Integer)
        Dim i As Integer = position
        Do While (i < line2.Length)
            If (Asc(line2(i)) > 47 And Asc(line2(i)) < 58) Then
                i += 1
            Else
                Exit Do
            End If
        Loop
        Return (i - position)
    End Function

    'Checks each character for whether it has a symbol next to it
    Function CheckAdjacentWhole(position As Integer, numberLength As Integer, line() As String)

        For i = 0 To (numberLength - 1)
            If CheckAdjacentCharacter(position + i, line, (numberLength - 1), i) Then
                Return line(1).Substring(position, numberLength)
            End If
        Next

    End Function

    'Checks an individual character for whether it has a symbol next to it
    Function CheckAdjacentCharacter(position As Integer, line As String(), lastCounter As Integer, counter As Integer)

        'Preforms the actions on each row i firstRow -> thirdRow
        For i = 0 To 2
            'Acts on horizontal position relative to the character they are looking at 1back -> 1forward
            For a = -1 To 1
                'If current line it is looking at is valid 
                If Not line(i) = "" Then
                    'If not looking at the first item or the last item in the row 
                    If Not (position = 0) And Not (position = line(0).Length() - 1) Then
                        'If top or bottom row contains a symbol
                        If Not (Asc(line(i).Substring(position + a, 1)) = 46) And Not (i = 1) Then
                            Return True
                        End If
                    End If
                    'If looking at the first item in the row
                    If position = 0 Then
                        'If right of character or slots above and below character contain a symbol
                        If Not (Asc(line(i).Substring(position, 1)) = 46) And Not i = 1 Then
                            Return True
                        End If
                        If Not (Asc(line(i).Substring(position + 1, 1)) = 46) And Not (line(i)(position + 1) >= "0" And line(i)(position + 1) <= "9") Then
                            Return True
                        End If
                    End If
                    'If looking at the last item in the row
                    If position = line(0).Length() - 1 Then
                        'If left of character or slots above and below character contain a symbol
                        If Not (Asc(line(i).Substring(position, 1)) = 46) And Not i = 1 Then
                            Return True
                        End If
                        If Not (Asc(line(i).Substring(position - 1, 1)) = 46) And Not (line(i)(position - 1) >= "0" And line(i)(position - 1) <= "9") Then
                            Return True
                        End If
                    End If
                End If
            Next

            'If looking at the first digit of a number and not looking at the first item in a row
            If (counter = 0 And Not (position = 0)) Then
                'If the slots to the left of the character contain a symbol
                If Not (Asc(line(1).Substring(position - 1, 1)) = 46) Then
                    Return True
                End If

            End If
            'If looking at the last digit of a number and not looking at the last item in a row
            If counter = lastCounter And Not (position = line(0).Length() - 1) Then
                'If the slots to the right of the character contain a symbol
                If Not (Asc(line(1).Substring(position + 1, 1)) = 46) Then
                    Return True
                End If
            End If

        Next

        Return False
    End Function
End Module
Module Module2

    Sub Main()
        'Reads the input into a file and then gets the first line 
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day3Input.txt")
        Dim line() As String = {"", fileReader.ReadLine, fileReader.ReadLine}
        Dim position As Integer
        Dim i As Integer
        Dim partSum As Integer
        Dim length As Integer
        Dim temp As Integer = 99

        While Not (line(1) = "")
            position = 0
            'Checks if position found a new number
            While Not (temp = position)
                temp = position
                position = FindNumber(line(1), position)
                length = FindNumberLength(line(1), position)
                partSum += CheckAdjacentWhole(position, length, line)
                Console.WriteLine(CheckAdjacentWhole(position, length, line))
                position += length
            End While
            line(0) = line(1)
            line(1) = line(2)
            line(2) = fileReader.ReadLine()
        End While
        Console.WriteLine(partSum)
        Console.ReadLine()
    End Sub

    'Finds the next possible part number
    Function FindNumber(line2 As String, position As Integer)
        Dim num As String
        Dim i As Integer = position
        Do
            If line2.Length = i Then
                i += 1
                Exit Do
            End If
            num = line2.Substring(i, 1)
            i += 1
        Loop Until (Asc(num) > 48 And Asc(num) < 58)
        Return (i - 1)
    End Function

    'Finds the length of the possible part number
    Function FindNumberLength(line2 As String, position As Integer)
        Dim i As Integer = position
        Do While (i < line2.Length)
            If (Asc(line2(i)) > 47 And Asc(line2(i)) < 58) Then
                i += 1
            Else
                Exit Do
            End If
        Loop
        Return (i - position)
    End Function

    'Checks each character for whether it has a symbol next to it
    Function CheckAdjacentWhole(position As Integer, numberLength As Integer, line() As String)

        For i = 0 To (numberLength - 1)
            If CheckAdjacentCharacter(position + i, line, (numberLength - 1), i) Then
                Return line(1).Substring(position, numberLength)
            End If
        Next

    End Function

    'Checks an individual character for whether it has a symbol next to it
    Function CheckAdjacentCharacter(position As Integer, line As String(), lastCounter As Integer, counter As Integer)

        'Preforms the actions on each row i firstRow -> thirdRow
        For i = 0 To 2
            'Acts on horizontal position relative to the character they are looking at 1back -> 1forward
            For a = -1 To 1
                'If current line it is looking at is valid 
                If Not line(i) = "" Then
                    'If not looking at the first item or the last item in the row 
                    If Not (position = 0) And Not (position = line(0).Length() - 1) Then
                        'If top or bottom row contains a symbol
                        If Not (Asc(line(i).Substring(position + a, 1)) = 46) And Not (i = 1) Then
                            Return True
                        End If
                    End If
                    'If looking at the first item in the row
                    If position = 0 Then
                        'If right of character or slots above and below character contain a symbol
                        If Not (Asc(line(i).Substring(position, 1)) = 46) And Not i = 1 Then
                            Return True
                        End If
                        If Not (Asc(line(i).Substring(position + 1, 1)) = 46) And Not (line(i)(position + 1) >= "0" And line(i)(position + 1) <= "9") Then
                            Return True
                        End If
                    End If
                    'If looking at the last item in the row
                    If position = line(0).Length() - 1 Then
                        'If left of character or slots above and below character contain a symbol
                        If Not (Asc(line(i).Substring(position, 1)) = 46) And Not i = 1 Then
                            Return True
                        End If
                        If Not (Asc(line(i).Substring(position - 1, 1)) = 46) And Not (line(i)(position - 1) >= "0" And line(i)(position - 1) <= "9") Then
                            Return True
                        End If
                    End If
                End If
            Next

            'If looking at the first digit of a number and not looking at the first item in a row
            If (counter = 0 And Not (position = 0)) Then
                'If the slots to the left of the character contain a symbol
                If Not (Asc(line(1).Substring(position - 1, 1)) = 46) Then
                    Return True
                End If

            End If
            'If looking at the last digit of a number and not looking at the last item in a row
            If counter = lastCounter And Not (position = line(0).Length() - 1) Then
                'If the slots to the right of the character contain a symbol
                If Not (Asc(line(1).Substring(position + 1, 1)) = 46) Then
                    Return True
                End If
            End If

        Next

        Return False
    End Function
End Module

