# WAPI The 
Contact: AUBERT ROMAIN - aubertromainpro@gmail.com

Wapi-the (Prononcé WAPITI) est l'accronyme de Web API - Tower of HEroes. 

Il s'agit d'une Web Api dont le front a été crée via un tutorial Angular et d'un Back crée avec l'entiereté de mes connaissances C# / .NetCore 3.1.

L'objectif était de créer une Web API intégrale avec Front en Angular et Back en .NetCore. 
J'ai utiliser MySql pour la BDD et entity Framework pour faire la liaison entre les deux. 
J'ai reproduit une Layered Arch / Clean Archi. 

Un Projet de TU est crée et couvre environ 80% du code nécéssaire de vérifier (soit le Service car les entitée, les DTO et les repository n'ont pas besoin d'etre testé sur ce projet ). 

Une CI existe avec 2 jobs
- Build & Test qui fait le build de l'appli, Lance les TU et sort le rapport TRX dans les artefact ( pour une intégration de SonarScanner possible ) 
- Publish qui fait le publish de l'appli et sort le dossier publish dans les artefact

