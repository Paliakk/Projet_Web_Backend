# Projet Backend - API ASP.NET Core

## Description
Cette API backend est construite avec ASP.NET Core et fournit des services pour gérer les utilisateurs, les cours et les devoirs. Elle utilise Entity Framework Core pour l'accès aux données et Identity pour la gestion des utilisateurs.

## Installation

1. Clonez le dépôt :

    Avec visual studio
    git clone https://github.com/Paliakk/Projet_Web_Backend.git


2. Accédez au répertoire du projet :
    lancez le projet

3. Configurez la base de données dans `appsettings.json`.

4. Appliquez les migrations de la base de données :
    Bien sélectionner Data comme projet par défaut
    update-database		


5. Lancez l'application :

    lancement IDE

## Fonctionnalités principales
Serivces pour :
- Authentification
- Gestion des utilisateurs
- Affichage des cours
- Gestion des cours
- Affichage des devoirs
- Gestion des devoirs
- Tableau de bord utilisateur

Structure de la db:
	ApplicatioRole : Role personnalisé de Identity
	ApplicationUser : User personnalisé de Identity, englobe les étudiant,admins et instructeurs
	Assignment: Enregistre les devoirs
	Course: Enregistre les cours
	CourseInstructor: Enregistre les cours donnés par instructeur
	CourseStudent: Enregistre les cours suivis par étudiant
	StudentAssignment: Enregistre les devoirs de chaque étudiant
Structure du Backend:
	Domain :
		 -DTO
		 -Modeles
	Data : 	
		-Interfaces
		-Repositories
		-DbContext
		-Migrations
	Business:
		-Service et logique business
		-interfaces
	API: 
		-Controllers

Apres réalisation:
	La structure de la bd aurait pu être plus claire.	


