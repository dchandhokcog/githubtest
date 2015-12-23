Imports System
Namespace eStoreFrontVB
    Public Class Base64Encoder
        Public Sub Base64Encoder()

        End Sub
        Public Function Encrypt(ByVal input As String) As String
            Dim source As Byte()
            Dim length As Integer
            Dim length2 As Integer
            Dim blockCount As Integer
            Dim paddingCount As Integer

            If (input Is Nothing) Then
                input = ""
            End If
            If (input = "" Or input.Length = 0) Then
                Return String.Empty
            End If
            source = System.Text.Encoding.ASCII.GetBytes(input)
            length = input.Length

            If (length Mod 3) = 0 Then
                paddingCount = 0
                blockCount = length / 3
            Else
                paddingCount = 3 - (length Mod 3) 'need to add padding
                blockCount = (length + paddingCount) / 3
            End If

            length2 = length + paddingCount 'or blockCount *3
            Dim source2(length2 - 1) As Byte
            'copy data over insert padding
            Dim x As Integer
            While x < length2
                If (x < length) Then
                    source2(x) = source(x)
                Else
                    source2(x) = 0
                End If
                x = x + 1
            End While

            Dim b1, b2, b3 As Byte
            Dim temp, temp1, temp2, temp3, temp4 As Byte
            Dim buffer(blockCount * 4 - 1) As Byte
            Dim result(blockCount * 4 - 1) As Char
            x = 0
            While x < blockCount
                b1 = source2(x * 3)
                b2 = source2(x * 3 + 1)
                b3 = source2(x * 3 + 2)

                temp1 = CByte((b1 And 252) >> 2) 'first

                temp = CByte((b1 And 3) << 4)
                temp2 = CByte((b2 And 240) >> 4)
                temp2 += temp 'Second

                temp = CByte((b2 And 15) << 2)
                temp3 = CByte((b3 And 192) >> 6)
                temp3 += temp 'third

                temp4 = CByte(b3 And 63) 'fourth

                buffer(x * 4) = temp1
                buffer(x * 4 + 1) = temp2
                buffer(x * 4 + 2) = temp3
                buffer(x * 4 + 3) = temp4
                x = x + 1
            End While
            x = 0
            While x < blockCount * 4
                result(x) = sixbit2char(buffer(x))
                x = x + 1
            End While

            'covert last "A"s to "=", based on paddingCount
            Select Case (paddingCount)
                Case 0

                Case 1
                    result(blockCount * 4 - 1) = "="

                Case 2
                    result(blockCount * 4 - 1) = "="
                    result(blockCount * 4 - 2) = "="
            End Select
            Return New String(result)
        End Function


        Private Function sixbit2char(ByVal b As Byte) As Char
            Dim lookupTable() As Char = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/"}
            If ((b >= 0) And (b <= 63)) Then
                Return lookupTable(CInt(b))
            Else
                'should not happen;
                Return " "
            End If
        End Function

        Public Function Decrypt(ByVal input As String) As String

            Dim source As Char()
            Dim length, length2, length3 As Integer
            Dim blockCount As Integer
            Dim paddingCount As Integer
            Dim temp As Integer = 0
            If (input Is Nothing) Then
                input = ""
            End If
            If (input = "" Or input.Length = 0) Then
                Return String.Empty
            End If

            source = input.ToCharArray()
            length = input.Length

            'find how many padding are there
            Dim x As Integer
            x = 0
            While x < 2
                If (source((length - x) - 1) = "=") Then
                    temp = temp + 1
                End If
                x = x + 1
            End While
            paddingCount = temp
            'calculate the blockCount;
            'assuming all whitespace and carriage returns/newline were removed.
            blockCount = length / 4
            length2 = blockCount * 3
            Dim buffer(length - 1) As Byte '= byte(blockCount*4) "[blockCount*4]
            Dim buffer2(length2 - 1) As Byte
            x = 0
            While x < length
                buffer(x) = char2sixbit(source(x))
                x = x + 1
            End While

            Dim b, b1, b2, b3 As Byte
            Dim temp1, temp2, temp3, temp4 As Byte
            x = 0
            While x < blockCount

                temp1 = buffer(x * 4)
                temp2 = buffer(x * 4 + 1)
                temp3 = buffer(x * 4 + 2)
                temp4 = buffer(x * 4 + 3)

                b = CByte(temp1 << 2)
                b1 = CByte((temp2 And 48) >> 4)
                b1 += b

                b = CByte((temp2 And 15) << 4)
                b2 = CByte((temp3 And 60) >> 2)
                b2 += b

                b = CByte((temp3 And 3) << 6)
                b3 = temp4
                b3 += b

                buffer2(x * 3) = b1
                buffer2(x * 3 + 1) = b2
                buffer2(x * 3 + 2) = b3
                x = x + 1
            End While
            'remove paddings
            length3 = length2 - paddingCount
            Dim result(length3 - 1) As Byte
            x = 0
            While x < length3
                result(x) = buffer2(x)
                x = x + 1
            End While
            Return System.Text.Encoding.UTF8.GetString(result)
        End Function

        Private Function char2sixbit(ByVal c As Char) As Byte
            Dim x As Integer
            Dim lookupTable() As Char = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/"}
            If (c = "=") Then
                Return 0
            Else
                x = 0
                While x < 64
                    If (lookupTable(x) = c) Then
                        Return CByte(x)
                    End If
                    x = x + 1
                End While
                'should not reach here
                Return 0
            End If
        End Function
    End Class
End Namespace