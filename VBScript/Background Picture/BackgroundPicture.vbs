'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


' Create an instance of BytescoutImageToVideo.ImageToVideo ActiveX object
Set converter = CreateObject("BytescoutImageToVideo.ImageToVideo")

' Activate the component
converter.RegistrationName = "demo"
converter.RegistrationKey = "demo"

' set default in effect for slides (you can also set effects for each single slide)
converter.Slides.DefaultSlideInEffect = 1 ' teFadeIn (1) - fades in effect for slides transition
converter.Slides.DefaultSlideInEffectDuration = 500 ' 500 msec for in effect

' Set movie background picture
converter.SetBackgroundPictureFileName "background.jpg"


' Add images and set the duration for every slide
Set slide = converter.AddImageFromFileName("slide1.jpg")
slide.Duration = 3000 ' 3000ms = 3s
Set slide = converter.AddImageFromFileName("slide2.jpg")
slide.Duration = 3000
Set slide = converter.AddImageFromFileName("slide3.jpg")
slide.Duration = 3000

' Set output video size
converter.OutputWidth = 640
converter.OutputHeight = 480

' Set output video file name
converter.OutputVideoFileName = "result.wmv"

' Run the conversion
converter.RunAndWait()

MsgBox "Result.wmv is ready. Script will try to open the video in default media player"

' Open result in default media player
Set shell = CreateObject("WScript.Shell")
shell.Run "result.wmv", 1, false
Set shell = Nothing

Set converter = Nothing
