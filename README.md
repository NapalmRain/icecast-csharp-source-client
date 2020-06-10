## Библиотека для работы с IceSact сервером в качестве источника звука

Эта библиотека по факту является просто обёрткой над данным проектом: https://github.com/Zerpico/libShout-csharp
В проект включены как все необходимые библиотеки, так и исходный класс из указанного выше проекта.

При необходисомти можно использовать исходных класс
```csharp
Libshout
```

Так и мою обёртку покруг него
```csharp
IceCastClient
```


Пример
```csharp
IceCastClient client = new IceCastClient( "localhost", 8000, "hackme", "RainRockRadio" );
if (client.open()) {
	client.PlaySong( "D:\\big black dog.mp3" );
}
```

Для полее подробной информации ознакомьтесь с изначальным проектом
