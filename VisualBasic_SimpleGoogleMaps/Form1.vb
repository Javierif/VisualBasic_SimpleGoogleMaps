Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim webHTML As String
        webHTML = genHead() & genScript(Lat.Text, Lng.Text) & genBody()
        WebBrowser1.Navigate("about:blank")
        WebBrowser1.Document.OpenNew(False)
        WebBrowser1.Document.Write(webHTML)
        WebBrowser1.Refresh()
    End Sub

    Private Function genHead()
        Dim head As String = <![CDATA[
            <!DOCTYPE html>
            <html>
                <head>
                    <title>Simple Map</title>
                    <meta name="viewport">
                    <meta http-equiv="X-UA-Compatible" content="IE=edge">
                    <style>
                        html, body, #map-canvas {
                            margin:0;
                            padding:0;
                            padding:0;
                            height:100%;
                        }
                    </style>
                    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
         ]]>.Value()
        Return head
    End Function

    Private Function genBody()
        Dim body As String = <![CDATA[
            <body>
                <div id="map-canvas"></div>
            </body>
        </html>
        ]]>.Value()
        Return body
    End Function

    Private Function genScript(ByVal lat, ByVal lng)
        Dim scMap As String = <![CDATA[
            <script>
                var map;
                function initialize() {
        ]]>.Value()

        Dim scMapv2 As String = "var mapOptions= {zoom: 13,mapTypeId: google.maps.MapTypeId.ROADMAP,center: new google.maps.LatLng(" + Trim(lat) + "," + Trim(lng) + ")}"

        Dim scMapv3 As String = <![CDATA[
                    map = new google.maps.Map(document.getElementById('map-canvas'),mapOptions);
                }
                google.maps.event.addDomListener(window, 'load', initialize);
            </script>
        ]]>.Value()
        Return scMap & scMapv2 & scMapv3
    End Function
End Class
