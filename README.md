# Kullanıcı Aktivite ve Sistem Takip Uygulaması

Bu proje, Windows işletim sistemi üzerinde çalışan kullanıcıların oturum hareketlerini, bilgisayar durumlarını ve temel aktivite sürelerini arka planda takip ederek yöneticilere detaylı gün sonu raporları sunan bir masaüstü loglama ve analiz aracıdır.

## Proje Tanıtım Videosu
 [Uygulamanın nasıl çalıştığını görmek için tıklayın](https://youtu.be/m1ZZJExr27k?si=bs7w8vbkzNvpaEn2)

## Proje Amacı
Çalışanların bilgisayar başındaki aktif ve pasif sürelerini, ekran kilitlenme durumlarını şeffaf bir şekilde kayıt altına almak; bu verileri anlamlı metrikler haline getirerek yönetici paneli üzerinden raporlamaktır.

## Öne Çıkan Özellikler

* **Rol Bazlı Giriş Sistemi:** Uygulama açılışında "Çalışan" ve "Yönetici" olmak üzere iki farklı yetkilendirme profili bulunur.
* **Hayalet Mod :** Çalışan girişi yapıldığında uygulama kendini görev çubuğuna gizler ve ekranda görünmeden arka planda sessizce log toplamaya başlar.
* **Dinamik Durum Tespiti:**
  * Oturum açma ve kapatma saatlerinin takibi.
  * Ekran kilidi ve kilit açılma durumlarının algılanması.
  * Bilgisayarın uyku moduna geçişinin anlık tespiti.
* **Idle Analizi:** Windows API'leri kullanılarak klavye ve mouse hareketleri dinlenir; kullanıcının aktif ve pasif olduğu saniyeler milimetrik olarak veritabanına işlenir.
* **Gelişmiş Yönetici Paneli:**
  * Şifre korumalı erişim.
  * Kullanıcı ve tarih bazlı filtreleme mekanizması.
  * Ham saniye verilerinin okunabilir doğal dile ("X Saat Y Dakika Z Saniye") dönüştürülmesi.
  * Seçilen güne ait **Toplam Çalışma, Aktif Süre, Pasif Süre ve Kilitli Kalma Süresi** metriklerinin anlık olarak hesaplanıp özetlenmesi.

## Kullanılan Teknolojiler

* **Geliştirme Ortamı & Dil:** C#, .NET Framework 4.6
* **Arayüz:** Windows Forms (WinForms)
* **Veritabanı:** Microsoft SQL Server
* **Sistem Entegrasyonları:** Windows API (`LASTINPUTINFO`), `SystemEvents` (Güç ve Oturum takibi)
* **Tasarım:** Kurumsal bütünlük için özel #fcb1d7 renk vurguları içeren modern arayüz tasarımı.

##  Kurulum ve Çalıştırma Adımları

1. Projeyi bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/mlkygcc/kullanici-aktivite-ve-sistem-durumu-takip-uygulamasi.git
    ```

2. SQL Server Management Studio'yu açarak sunucunuza bağlanın.

3. Proje dosyaları arasında bulunan UserActivity.sql dosyasını SSMS üzerinde açın ve üst menüden Execute butonuna basın. (Bu işlem veritabanını ve gerekli tabloları otomatik olarak oluşturacaktır).

4. Visual Studio üzerinden projeyi açın (.sln dosyası ile)

5. Form1.cs, DashboardForm.cs ve LoginForm.cs dosyalarındaki connectionString (Veritabanı bağlantı adresi) değişkenini kendi yerel MSSQL sunucu adınıza göre güncelleyin. Ardından projeyi çalıştırın.

Not: Yönetici paneline erişim için varsayılan şifre 123 olarak belirlenmiştir.

**Geliştirici:** Meleksu YAĞCI
