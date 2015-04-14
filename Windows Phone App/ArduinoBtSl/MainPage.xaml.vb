Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Windows.Networking.Proximity
Imports Windows.Networking.Sockets

Partial Public Class MainPage
	Inherits PhoneApplicationPage

	Dim bt As StreamSocket

	' Constructor
	Public Sub New()
		InitializeComponent()

		SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape

		' Sample code to localize the ApplicationBar
		'BuildLocalizedApplicationBar()

	End Sub

	' Sample code for building a localized ApplicationBar
	'Private Sub BuildLocalizedApplicationBar()
	'    ' Set the page's ApplicationBar to a new instance of ApplicationBar.
	'    ApplicationBar = New ApplicationBar()

	'    ' Create a new button and set the text value to the localized string from AppResources.
	'    Dim appBarButton As New ApplicationBarIconButton(New Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative))
	'    appBarButton.Text = AppResources.AppBarButtonText
	'    ApplicationBar.Buttons.Add(appBarButton)

	'    ' Create a new menu item with the localized string from AppResources.
	'    Dim appBarMenuItem As New ApplicationBarMenuItem(AppResources.AppBarMenuItemText)
	'    ApplicationBar.MenuItems.Add(appBarMenuItem)
	'End Sub

	Private Function GetBufferFromByteArray(ByVal package As Byte())
		Using dw As Windows.Storage.Streams.DataWriter = New Windows.Storage.Streams.DataWriter
			dw.WriteBytes(package)
			Return dw.DetachBuffer
		End Using
	End Function

	Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
		PeerFinder.Start()
		PeerFinder.AlternateIdentities("Bluetooth:Paired") = ""
		Dim peers = Await PeerFinder.FindAllPeersAsync()
		For Each a In peers
			lstAllPeers.Items.Add(a.DisplayName)
		Next
	End Sub

	Private Async Sub btnHello_Click(sender As Object, e As RoutedEventArgs) Handles btnHello.Click
			If bt IsNot Nothing Then
			Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("Hello"))
			Await bt.OutputStream.WriteAsync(datab)
			MessageBox.Show("Sent")
		Else
			MessageBox.Show("Nothing")
		End If

	End Sub

	Private Async Sub lstAllPeers_Tap(sender As Object, e As GestureEventArgs) Handles lstAllPeers.Tap
		If lstAllPeers.SelectedItem IsNot Nothing Then
			PeerFinder.AlternateIdentities("Bluetooth:Paired") = ""
			Dim pf = Await PeerFinder.FindAllPeersAsync()
			bt = New StreamSocket
			Await bt.ConnectAsync(pf(lstAllPeers.SelectedIndex).HostName, "1")

		End If
	End Sub

	Private Async Sub btnFwd_Click(sender As Object, e As RoutedEventArgs) Handles btnFwd.Click
		Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("A"))
		Await bt.OutputStream.WriteAsync(datab)
	End Sub

	Private Async Sub btnStop_Click(sender As Object, e As RoutedEventArgs) Handles btnStop.Click
		Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("O"))
		Await bt.OutputStream.WriteAsync(datab)
	End Sub

	Private Async Sub btnLeft_Click(sender As Object, e As RoutedEventArgs) Handles btnLeft.Click
		Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("C"))
		Await bt.OutputStream.WriteAsync(datab)
	End Sub

	Private Async Sub btnRight_Click(sender As Object, e As RoutedEventArgs) Handles btnRight.Click
		Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("D"))
		Await bt.OutputStream.WriteAsync(datab)
	End Sub

	Private Async Sub btnBwd_Click(sender As Object, e As RoutedEventArgs) Handles btnBwd.Click
		Dim datab = GetBufferFromByteArray(Text.Encoding.UTF8.GetBytes("B"))
		Await bt.OutputStream.WriteAsync(datab)
	End Sub
End Class