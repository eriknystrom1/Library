# Introduktion

Det här är ett repo för Centrumbibliotekets sida för utlån. Det finns ett projekt som är körbart och som också representeras med ett prefix i mappen. Dessa är följande:

1. API* - Exekverbart system API som integrerar direkt med datakällor och dess syfte är att stå till tjänst för så många användare som möjligt, därav nödvändigheten för ett allmänt API.
2. Databas för klienter* - Är ett bibliotek utav klienter med diverse lån samt böcker med titlar, etc som API:et tjänster använder sig utav.
3. Klient* - Exekverbart system utav Frontend tjänster.
![bild](https://community.devexpress.com/blogs/javascript/18.1Release/DevExtreme-scaffolding-blog.png)
# Komma igång
Behoven varierar för varje exekverbar del och kommer därför visas i ordningsföljd nedan. 

# API
Rent generellt för att applikationen skall fungera behöver vi installera följande:
1. Visual Studio
2. .NET Core
3. Microsoft SQL Server Management Studio
4. Azure konto

För att starta tjänsten:
1. Öppna Visual Studio
2. Tryck F5 eller välj Debug > Start debugging


# Olika sätt att exekvera projektet
Det finns olika sätt att köra projektet på, dessa är följande:
- Exekvera projektet med riktig data
- Exekvera med en lokal server

Med riktig data så använder vi oss av Visual Studio genom att börja debugga och vi hämtar då information från vår databas 'library'.
Med en lokal server så behöver vi gå in på Azure och skapa en SQL databas.

  ![](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api/_static/architecture.png?view=aspnetcore-5.0)

# Installation av databasen 
Den 'Connection String' som vi använder för att koppla upp oss till den databasen 'library' där vi har informationen lagrat lokalt genom MSSMS är följande:

 ``` "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; Database=library; Trusted_Connection=true; User Id=library; password=1234qwer"
  },
  ```

  
