D:\dokumenter\Visual Studio Code> GoodBooks 

## BACKEND - .NET CORE:
```bash
dotnet new sln
dotnet new webapi -o GoodBooks.Web
dotnet new classlib -f netcoreapp3.1 -o GoodBooks.Data
dotnet new classlib -f netcoreapp3.1 -o GoodBooks.Services
dotnet new xunit -o GoodBooks.Test
dotnet sln add GoodBooks.Web
dotnet sln add GoodBooks.Data
dotnet sln add GoodBooks.Services
dotnet sln add GoodBooks.Test
dotnet build
```

###### weatherforecast class removed, 
###### references WeatherForecastController renamed BooksController
```bash
dotnet build
```
```bash
cd..
cd GoodBooks.Data
```

###### Command Palette (Ctrl+Shift+P)
###### NuGet Package Manager: Add Package
```bash
Microsoft.EntityFrameworkCore (v 3.1.5 selected)
```
```bash
ALTERNATIVE:
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.5
```

###### Command Palette (Ctrl+Shift+P)
###### NuGet Package Manager: Add Package
```bash
Microsoft.EntityFrameworkCore.Sqlite
```
```bash
ALTERNATIVE:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

###### GoodBooks.Data.csproj updated:
###### <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.5"/>
###### <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.5"/>

```bash
cd..
cd GoodBooks.Services
```

###### Add reference to GoodBooks.Services from GoodBooks.Data
```bash
dotnet add reference ../GoodBooks.Data
```
###### GoodBooks.Services.csproj:
###### <ProjectReference Include="..\GoodBooks.Data\GoodBooks.Data.csproj" />

```bash
cd..
cd GoodBooks.Web
```
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.5
dotnet add package NewtonSoft.Json
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
###### dotnet commands changed GoodBooks.Web.csproj like:
######  <ItemGroup>
######    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.5" />
######    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.5">
######      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
######      <PrivateAssets>all</PrivateAssets>
######    </PackageReference>
######    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.5" />
######    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.5">
######      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
######      <PrivateAssets>all</PrivateAssets>
######    </PackageReference>
######    <PackageReference Include="NewtonSoft.Json" Version="12.0.3" />
######  </ItemGroup>

###### Add reference to GoodBooks.Web from GoodBooks.Data and GoodBooks.Services
```bash
dotnet add reference ../GoodBooks.Data
dotnet add reference ../GoodBooks.Services
```
###### GoodBooks.Services.csproj:
###### <ProjectReference Include="..\GoodBooks.Data\GoodBooks.Data.csproj" />
###### <ProjectReference Include="..\GoodBooks.Data\GoodBooks.Services.csproj" />

```bash
dotnet tool update --global dotnet-ef
```
###### Tool 'dotnet-ef' was successfully updated from version '3.1.4' to version '3.1.5'.

###### In .vscode\launch.json
######     "configurations": [
######        {  -------
######           "requireExactSource": false, 
######           -------


###### Database migrations in D:\Dokumenter\Visual Studio Code\GoodBooks>
###### Tables and fields automatic created in sqlite3 file: 
###### D:\\Dokumenter\\Visual Studio Code\\GoodBooks\\GoodBooks.Data\\goodbooks_dev.db
```bash
cd ./GoodBooks.Data ; dotnet ef --startup-project ../GoodBooks.Web/ migrations add Initial ; cd..
cd ./GoodBooks.Data ; dotnet ef --startup-project ../GoodBooks.Web/ database update ; cd..
```


## FRONTEND - VUE.JS:
```bash
vue create goodbooks-vue
```

###### ? Please pick a preset: Manually select features
###### ? Check the features needed for your project: Babel, TS, Router, CSS Pre-processors, Linter
###### ? Use class-style component syntax? Yes
###### ? Use Babel alongside TypeScript (required for modern mode, auto-detected polyfills, transpiling JSX)? Yes
###### ? Use history mode for router? (Requires proper server setup for index fallback in production) Yes
###### ? Pick a CSS pre-processor (PostCSS, Autoprefixer and CSS Modules are supported by default): Sass/SCSS (with dart-sass)
###### ? Pick a linter / formatter config: Basic
###### ? Pick additional lint features: Lint on save
###### ? Where do you prefer placing config for Babel, ESLint, etc.? In dedicated config files
###### ? Save this as a preset for future projects? No

```bash
cd goodbooks-vue
npm run serve
```

###### Make a logo:
###### https://hatchful.shopify.com/

```bash
npm add axios
```
```bash
npm add moment
```
