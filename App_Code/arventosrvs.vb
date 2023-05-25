Imports System.Data
Imports ArventoSRV
Imports Microsoft.VisualBasic

Public Class arventosrvs

    Shared client = New ArventoReportWebService 'SERVİS BAĞLANTISI İÇİN GEREKLİ KOD'

    'DEĞİŞKENLERİ TANIMLIYORUZ'
    Shared username = ""  '
    Shared pin1 = "."
    Shared pin2 = "."

    Public Shared Function GetDeviceId(ByVal newPlate As String) As String 'GELEN DÜZENLENMİŞ PLAKA İLE SERVİSİ KULLANARAK PLAKA DEVİCEİD BİLGİSİNİ ALIR'
        Dim group = ""
        Dim dateset = client.GetNodes(username, pin1, pin2, group)
        Dim query = "LicensePlate like '%" + newPlate + "%'"
        Dim datarow = dateset.Tables(0).Select(query)
        Dim deviceId = datarow(0).ItemArray(1).ToString

        Return deviceId
    End Function

    Public Shared Function Location(ByVal plate As String) As String 'BU FONKSİYON ARACIN LOCATİON BİLGİSİNİ VERİYOR'
        Dim newPlate = EditPlate(plate) 'GELEN PLAKAYI DÜZENLİYORUZ'
        Dim deviceId = GetDeviceId(newPlate) 'PLAKAYA AİT DeviceId'Yİ ALIYORUZ'
        Dim language = "1"
        Dim dateset = client.GetVehicleStatusByNode(username, pin1, pin2, deviceId, language)
        Dim datarow = dateset.Tables(0).Rows
        Dim locationInfo = "" 'HER PLAKA İÇİN LOCATİON BİLGİSİ ALINACAĞINDAN BAŞTA LOCATİON BİLGİSİNİ TEMİZLİYORUZ'

        For Each item As String In datarow(0).ItemArray

            'SERVİSTEN GELEN LOCATİONBİLGİSİNİN BELLİ DEĞERLERİNİ ALACAĞIMIZ İÇİN BURADA BU KODU TANIMLADIK'
            'locationInfo = item.ItemArray(0).ToString + "|" + item.ItemArray(2).ToString + "|" + item.ItemArray(3).ToString + "|" + item.ItemArray.ToString(5)


            locationInfo += item + " | " 'BURADA SERVİSTEN GELEN TÜM LOKASYON BİLGİSİNİ TEK SATIR OLARAK ALDIK'
        Next

        Return locationInfo 'BURADA LOKASYON BİLGİSİNİ GERİ DÖNDERDİK'
    End Function

    Public Shared Function EditPlate(ByVal plate As String) As String
        Dim newPlate = Regex.Replace(plate.Replace(" ", ""), "(\d+)(\D+)(\d+)", "$1 $2 $3") 'BURADA BOŞ GELEN PLAKALARI YADA YALNIŞ YAZILMIŞ PLAKALARI REGEX KODU İLE DÜZELTTİK'

        Return newPlate
    End Function

End Class
