# Success History - Clément Darne

## Documents

### Documents du projet

- Fiche de Lancement 
([Local](./doc/Clément_Darne_Fiche_Lancement_Kickoff.pdf))
([Drive](https://docs.google.com/document/d/1ZuqTi5ynLvBm6lz4eAiwqOQUeDUz08ptT6vcpWwiOQE/edit?usp=sharing)) 
- Recherche successive 
([Drive](https://docs.google.com/presentation/d/15R852iybVDg16wd6GARKv_uq93iOW930lfqeFJNdync/edit?usp=sharing))
- Comparaison des technologies 
([Drive](https://docs.google.com/spreadsheets/d/1KkvoeLnuqHdTdF5eDlAFaEZGVZ6jxHvpfm04LW2fIPs/edit?usp=sharing))
- PoC et choix technologiques 
([Local](./doc/Clément_Darne_PoC_et_Choix_technologiques.pdf))
([Drive](https://docs.google.com/document/d/11wGQvmYWSAQvyj1FjM4IuKHJmywe2WRGGacDEhz8f9I/edit?usp=sharing)) 
- Analyse fonctionnelle ([Drive](https://docs.google.com/presentation/d/135o8Wbq9iUsmIQ24OMhoskUaWGAw-txcJaZNcuo_Ilw/edit?usp=sharing))

### Documentation externe

- Collection de bookmarks ([Raindrop](https://raindrop.io/ClementDrn/net-22860221))


## Installation

Si vous voulez juste utiliser l'application, les binaries d'une release suffiront. 

Si vous voulez, compiler l'application depuis le code source, suivez la procédure ci-dessous.

Tout d'abord, il faut cloner le dépôt.

```bash
git clone https://github.com/cegepmatane/Projet-Specialisation-2022-Clement-Darne/
```

### Windows

Le lien de téléchargement pour installer .NET sur Windows se trouve sur le [site de Microsoft](https://dotnet.microsoft.com/en-us/download).

Pour compiler l'application, veuillez installer la version 5 du SDK .NET. Sinon, une version Runtime 5 ou plus fera l'affaire.

### Linux

Sur Linux il faut ensuite installer .NET et ses dépendances. Plusieurs méthodes sont possibles.

#### Installation locale

Pour installer .NET dans le répertoire du projet, il suffit d'exécuter le script dédié. Par contre il faut que les dépendances, comme décrites sur la [documentation .NET](https://docs.microsoft.com/en-us/dotnet/core/install/linux), soient aussi installées.

```bash
scripts/Linux/install-dependencies.sh
```

#### Installation globale

Utiliser un gestionnaire de package qui installe en même temps les dépendances. Si vous utilisez le gestionnaire `apt` vous pouvez télécharger un des dépôt de Microsoft en sélectionnant le bon `packages-microsoft-prod` depuis ce lien : https://packages.microsoft.com/config/. Il faut ensuite l'implémenter dans le gestionnaire de paquets.

```bash
# Exemple Ubuntu 20.04
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

Une fois que le gestionnaire a connaissance des paquets .NET, on peut installer le SDK correspondant compatible avec l'application : **SDK 5.0**.

```bash
sudo apt install dotnet-sdk-5.0
```


## Lancement de l'application

### Windows

L'application peut être compilée et lancée depuis Visual Studio.

### Linux

#### Compilation

```bash
scripts/Linux/build.sh
```

#### Exécution

```bash
scripts/Linux/run.sh
```
