# DataAnalyzeReportProject
DataAnalyzeReport

### Kullanıcı Tarafı (Frontend):

Kullanıcı, tarayıcısında Blazor WebAssembly uygulamasını çalıştırır.
Ana sayfa, kullanıcıyı "Excel Upload" ve "Link Analysis" gibi seçeneklerle karşılar.
Kullanıcı, Excel dosyasını yükleyerek veya bir bağlantıyı analiz ederek işlemlerini gerçekleştirir.

### Excel Upload İşlemi:
Kullanıcı, "Excel Upload" seçeneğini seçer.
Blazor uygulaması, Excel dosyasını seçmek için bir dosya seçme düğmesi sunar.
Kullanıcı, Excel dosyasını seçtikten sonra dosya, Blazor uygulamasına yüklenir.
Uygulama, WebAPI'ya yüklenen Excel dosyasını ileterek analiz isteğini yapar.

### Link Analysis İşlemi:
Kullanıcı, "Link Analysis" seçeneğini seçer.
Blazor uygulaması, kullanıcıdan bir bağlantı girmesini ister.
Kullanıcı, bir bağlantı girdikten sonra, uygulama bu bağlantıyı WebAPI'ya göndererek analiz isteğini yapar.
### WebAPI (Backend):
WebAPI, gelen Excel dosyasını veya bağlantıyı işleyerek ilgili servis (Excel veya Link servisi) üzerinden analiz yapar.
Servis sonuçları, uygun HTTP yanıtıyla birlikte Blazor uygulamasına geri döner.
### Sonuçların Gösterimi:
Blazor uygulaması, WebAPI'den gelen sonuçları alır.
Sonuçlar, kullanıcıya uygun şekilde (örneğin, yüklenen Excel dosyasının analizi veya bağlantı analizi sonuçları) gösterilir.
