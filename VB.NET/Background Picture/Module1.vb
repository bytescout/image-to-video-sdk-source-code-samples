'****************************************************************************'
'                                                                            '
' Download evaluation version: https://bytescout.com/download/web-installer  '
'                                                                            '
' Signup Cloud API free trial: https://secure.bytescout.com/users/sign_up    '
'                                                                            '
' Copyright © 2017 ByteScout Inc. All rights reserved.                       '
' http://www.bytescout.com                                                   '
'                                                                            '
'****************************************************************************'


Imports BytescoutImageToVideo

Module Module1

    Sub Main()

        Try
            Console.WriteLine("Converting JPG slides to video, please wait...")

            ' Create BytescoutImageToVideoLib.ImageToVideo object instance
            Dim converter As ImageToVideo = New ImageToVideo()

            ' Activate the component
            converter.RegistrationName = "demo"
            converter.RegistrationKey = "demo"

            ' Set default "in" effect for slides (you can also set effects for each single slide)
            converter.Slides.DefaultSlideInEffect = 1 ' teFadeIn (1) - fades in effect for slides transition
            converter.Slides.DefaultSlideInEffectDuration = 500 ' 500 msec for in effect

            ' Set movie background picture
            converter.SetBackgroundPictureFileName("..\..\..\..\background.jpg")

            ' Add images and set slide durations 
            Dim slide As Slide
            slide = converter.AddImageFromFileName("..\..\..\..\slide1.jpg")
            slide.Duration = 3000 ' 3000ms = 3s
            slide = converter.AddImageFromFileName("..\..\..\..\slide2.jpg")
            slide.Duration = 3000
            slide = converter.AddImageFromFileName("..\..\..\..\slide3.jpg")
            slide.Duration = 3000

            ' Set output video size
            converter.OutputWidth = 640
            converter.OutputHeight = 480

            ' Set output video file name
            converter.OutputVideoFileName = "result.wmv"

            ' Run the conversion
            converter.RunAndWait()

            ' Release resources
            System.Runtime.InteropServices.Marshal.ReleaseComObject(converter)

            ' Open the result video file in default media player
            Process.Start("result.wmv")

            Console.WriteLine("Done. Press any key to continue...")
            Console.ReadKey()

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Console.ReadKey()
        End Try

    End Sub

End Module
