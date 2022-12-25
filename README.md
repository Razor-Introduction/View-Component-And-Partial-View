# Partial View

## Released

ASP.NET MVC 1.0

PartialView, başka bir View içeresinde oluşturulan bir view yani görünümdür. PartialView ile oluşturulan HMTL çıktısı, onu çağıran üst görünüme dönüştürülür.

## Avantajları

PartialView lar büyük View yapılarını daha küçük bileşenlere ayırmanın etkili bir yoludur.

View yapısının içerisinin gereksiz yere karmaşık veya büyük hale gelmesinin önüne geçebilir. 

Eğer kullanacağız View yapısı oldukça karmaşık kod düzeni içeriyorsa bunu PartialView’lara bölerek kod karmaşasından kurtarabilirsiniz. Bu sayede View yapısı daha sade bir yapıya kavuşurken PartialView’lar da kendilerine ait işlemleri yapacak .cshtml kodları ile daha spesifik bir ortam sunuyor olacaktır.

 Aynı zamanda bir cshtml yapısını birden fazla View içerisinde kullanmak istiyorsak bunu da yine bir PartialView olarak tasarlayıp kullanmak istediğimiz ilgili View’lar içerisinde ayrı ayrı kod tekrarı yapmadan çağırabiliriz. 


![partial](https://user-images.githubusercontent.com/73026903/209478222-157cb25a-e969-471a-a964-c90bc729a429.png)

# View Component

## Released

ASP.NET Core 1.0

ViewComponent modüler tasarım yapılanmasını oluşturulmasını ve kullanılmasını sağlayan bir yapıdır. .Net Core mimarisi ile hayatımıza giriş yapmıştır. 

Esasında PartialView ile aynı amaca hizmet eder fakat aralarında teknik olarak farklar vardır.

Şimdi basit bir MVC yapısı düşünelim. Kullanıcıdan bir istek yapıldığını düşünürsek bunu önce Controller karşılar daha sonra bir veri taşıyacaksa buna Modelden ulaşır ve en nihayetinde View a ulaştırır. Eğer birde PartialView varsa en son olarak ona ulaşır. Yani kısacası PartialView üzerinde bir veri göstermek istediğimizde en basit döngü yukarıda bahsettiğimiz gibidir.


Peki ViewComponent bu konuda ne diyor. ViewComponent diyor ki beni de modüler olarak parça parça kullanabilirsin fakat eğer bende bir veri göstermek istiyorsan Controller’ı hiç araya katmadan onu yormadan direkt olarak Model ile iletişime geçip veriyi gösterebilirim. İşte PartialView ve ViewComponent arasındaki en temel fark budur.


Burada iş Controller üzerinden çıkıyor ve Controller üzerindeki gereksiz yük hafifliyor. Bu saye de projemiz üzerinde yer alan Controller amacından sapmadan işlerini yapabilir hale geliyorlar.

Özetle toplayacak olursak; PartialView yapılanması ihtiyacı olan dataları Controller üzerinden elde edeceği için Contoller’daki maliyeti artırmakta ve SOLID prensiplere aykırı davranılmasına sebebiyet verebilmektedir. Ayrıca PartialView yapılsak olarak Controller üzerinden beslenmektedir.

ViewComponent ihtiyacı olan dataları Controller üzerinden değil, direkt kendi cs dosyasından elde edebilmektedir. Böyle Controller üzerindeki gereksiz maliyeti ortadan kaldırmayı hedeflenmektedir.


![component](https://user-images.githubusercontent.com/73026903/209478235-8a25dcb8-a110-4911-98d3-40e5f0bc161f.png)

## Via
https://emrecanayar.wordpress.com/2021/03/12/partialview-nedir/

https://emrecanayar.wordpress.com/2021/04/25/viewcomponent-nedir-nasil-olusturulur-nasil-kullanilir/




