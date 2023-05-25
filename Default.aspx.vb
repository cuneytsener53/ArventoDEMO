
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim plate = Request.QueryString("plate") 'BU KODDA İSE QUERYSTRİNG KULLANARAK TARAYICIDAKİ LİNK KISMINDA YAZILAN DEĞERLERİ ALIR'

        If IsNothing(plate) Then 'EĞER GELEN PLAKA BİLGİSİ YADA DEĞER BOŞ İSE BU İF KODU İLE RETURN EDEREK SERVİSİ YORMUYORUZ'
            Return
        End If

        Dim locationInfo = arventosrvs.Location(plate) 'BU KOD PLAKANIN LOCATİON BİLGİSİ İÇİN METHODU ÇAĞIRIYORUZ'

        Response.Write(locationInfo) 'BU KOD LOCATION BİLGİSİNİ EKRANA YAZDIRIR'

    End Sub


End Class
