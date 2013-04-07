'/*
' * Copyright (C) 2009-2012 Solmead Productions
' *
' * == BEGIN LICENSE ==
' *
' * Licensed under the terms of any of the following licenses at your
' * choice:
' *
' *  - GNU General Public License Version 2 or later (the "GPL")
' *    http://www.gnu.org/licenses/gpl.html
' *
' *  - GNU Lesser General Public License Version 2.1 or later (the "LGPL")
' *    http://www.gnu.org/licenses/lgpl.html
' *
' *  - Mozilla Public License Version 1.1 or later (the "MPL")
' *    http://www.mozilla.org/MPL/MPL-1.1.html
' *
' * == END LICENSE ==
' */

'Imports HundredMilesSoftware

Public Class MP3File
    Public Shared Sub SetAudioData(ByVal File As System.IO.FileInfo, Optional ByVal Album As String = "", Optional ByVal Artist As String = "", Optional ByVal Comment As String = "", Optional ByVal Name As String = "", Optional ByVal Image As System.Drawing.Bitmap = Nothing)
        If Not File.Exists Then
            Return
        End If
        'Dim SR = File.OpenRead

        Dim T = TagLib.File.Create(File.FullName)

        If Album <> "" Then
            T.Tag.Album = Album
        End If
        If Artist <> "" Then
            Dim Arts(0) As String
            Arts(0) = Artist
            T.Tag.Performers = Arts
        End If
        If Comment <> "" Then
            T.Tag.Comment = Comment
        End If
        If Name <> "" Then
            T.Tag.Title = Name
        End If
        'T.Tag.Pictures
        Dim TTFn As New TagLib.Id3v2.AttachedPictureFrame()
        TTFn.Type = TagLib.PictureType.FrontCover
        TTFn.MimeType = "image/jpeg"



        Dim MS As New System.IO.MemoryStream
        Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim Arr As Byte()
        Arr = MS.ToArray

        TTFn.Data = Arr
        Dim Pics(0) As TagLib.IPicture
        Pics(0) = TTFn
        T.Tag.Pictures = Pics
        T.Save()
        



        'Dim myMp3 = New UltraID3Lib.UltraID3()
        'myMp3.Read(File.FullName)

        'Dim ArtworkList = myMp3.ID3v2Tag.Frames.GetFrames(UltraID3Lib.MultipleInstanceID3v2FrameTypes.ID3v23Picture)
        'If ArtworkList.Count > 0 Then
        '    'For a As Integer = 0 To ArtworkList.Count - 1
        '    'Dim ra As ID3v23PictureFrame = ArtworkList(0)
        '    Try
        '        myMp3.ID3v2Tag.Frames.Remove(UltraID3Lib.CommonID3v2FrameTypes.Picture)
        '    Catch ex As Exception

        '    End Try
        '    'Next
        '    ArtworkList.Clear()
        '    myMp3.Write()
        '    myMp3.Read(File.FullName)
        'End If
        'If Image IsNot Nothing Then

        '    Dim AA As UltraID3Lib.ID3v23PictureFrame = myMp3.ID3v2Tag.Frames.Add(UltraID3Lib.ID3v2FrameTypes.ID3v23Picture)
        '    AA.Description = "Attached Picture"
        '    AA.Picture = Image
        '    AA.PictureType = UltraID3Lib.PictureTypes.CoverFront
        '    AA.TextEncodingType = UltraID3Lib.TextEncodingTypes.ISO88591

        '    myMp3.ID3v2Tag.Frames.Add(AA)

        '    Dim AB As UltraID3Lib.ID3v22PictureFrame = myMp3.ID3v2Tag.Frames.Add(UltraID3Lib.ID3v2FrameTypes.ID3v22Picture)
        '    AB.Description = "Attached Picture"
        '    AB.Picture = Image
        '    AB.PictureType = UltraID3Lib.PictureTypes.CoverFront
        '    AB.TextEncodingType = UltraID3Lib.TextEncodingTypes.ISO88591
        '    myMp3.ID3v2Tag.Frames.Add(AB)

        '    Dim AlbumArt = New UltraID3Lib.ID3v23PictureFrame(Image, UltraID3Lib.PictureTypes.CoverFront, "Attached picture", UltraID3Lib.TextEncodingTypes.ISO88591)
        '    myMp3.ID3v2Tag.Frames.Add(AlbumArt)
        'End If
        'If Album <> "" Then
        '    myMp3.ID3v2Tag.Album = Album
        'End If
        'If Artist <> "" Then
        '    myMp3.ID3v2Tag.Artist = Artist
        'End If
        'If Comment <> "" Then
        '    myMp3.ID3v2Tag.Comments = Comment
        'End If
        'If Name <> "" Then
        '    myMp3.ID3v2Tag.Title = Name
        'End If


        'myMp3.Write()

    End Sub
End Class
