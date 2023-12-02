Imports System.IO

Module Module1

    Sub Main()
        'Reads the input into a file and then gets the first line 
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCodeDay1\TextInputs\Day1Input.txt")
        Dim textInput As String = fileReader.ReadLine
        Dim calibrationSum As Integer

        'Continues adding calibration found on each line then fetching the new line until no lines are left
        While Not (textInput = "")
            calibrationSum += FindLineCalibration(textInput)
            textInput = fileReader.ReadLine
        End While


        Console.WriteLine(calibrationSum)
        Console.ReadLine()
    End Sub
    'Checks whether the following letters of a character makes a number and turns that character into the number if it does
    Function ConvertToSingleChar(Line, i)
        Dim result As Integer
        'Extra space to prevent array overflow without if statements
        Line = Line + "      "

        'Creates possible number words by finding the characters after the current one
        Dim threeLetterWord = Line(i) + Line(i + 1) + Line(i + 2)
        Dim fourLetterWord = Line(i) + Line(i + 1) + Line(i + 2) + Line(i + 3)
        Dim fiveLetterWord = Line(i) + Line(i + 1) + Line(i + 2) + Line(i + 3) + Line(i + 4)

        'Defines the dictionaries that can turn the number words into integers
        Dim Dic As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Dic.Add("one", 1)
        Dic.Add("two", 2)
        Dic.Add("six", 6)
        Dic.Add("four", 4)
        Dic.Add("five", 5)
        Dic.Add("nine", 9)
        Dic.Add("three", 3)
        Dic.Add("seven", 7)
        Dic.Add("eight", 8)

        'Checks the key number words against the dictionary to find out if it matches any of the dictionaries
        If Dic.TryGetValue(threeLetterWord, result) Then
            Return result
        ElseIf Dic.TryGetValue(fourLetterWord, result) Then
            Return result
        ElseIf Dic.TryGetValue(fiveLetterWord, result) Then
            Return result
        End If
    End Function




    Function FindLineCalibration(Line As String)
        Dim readChar As String = Line(0)
        Dim firstValue As Integer = 0
        Dim secondValue As Integer = 0
        For i = 0 To Line.Length - 1

            readChar = Line(i)
            'Checks if the character it is looking at is already a number
            If Asc(readChar) > 47 And Asc(readChar) < 58 Then
                If firstValue = 0 Then
                    firstValue = readChar
                    secondValue = readChar
                Else
                    secondValue = readChar
                End If

            Else
                'Gets the number word that starts at the character it is looking at and outputs "" if it isn't a number word
                readChar = ConvertToSingleChar(Line, i)

                'If it was a number word then sets it to the firstValue if it was the first number found and sets the latestValue to it
                If Not (readChar = "") Then
                    If firstValue = 0 Then
                        firstValue = readChar
                        secondValue = readChar
                    Else
                        secondValue = readChar
                    End If
                End If
            End If
        Next

        'Turns the first value into the 1st digit by multiplying it by 10 and then adding the 2nd digit
        Console.WriteLine(firstValue * 10 + secondValue)
        Return (firstValue * 10 + secondValue)
    End Function

End Module
