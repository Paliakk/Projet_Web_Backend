# Projet Backend - API ASP.NET Core

## Description
Cette API backend est construite avec ASP.NET Core et fournit des services pour gérer les utilisateurs, les cours et les devoirs. Elle utilise Entity Framework Core pour l'accès aux données et Identity pour la gestion des utilisateurs.

## Prérequis
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation

1. Clonez le dépôt :
    ```bash
    git clone https://github.com/Paliakk/Projet_Web_Backend.git
    ```

2. Accédez au répertoire du projet :
    ```bash
    cd Projet_Web_Backend
    ```

3. Configurez la base de données dans `appsettings.json`.

4. Appliquez les migrations de la base de données :
    ```bash
    dotnet ef database update
    ou
    update-database		
    ```

5. Lancez l'application :
    ```bash
    dotnet run
    ou
    lancement IDE
    ```
## Fonctionnalités principales
Serivces pour :
- Authentification
- Gestion des utilisateurs
- Affichage des cours
- Gestion des cours
- Affichage des devoirs
- Gestion des devoirs
- Tableau de bord utilisateur