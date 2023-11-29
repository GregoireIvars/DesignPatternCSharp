1. **Factory Pattern** : La classe `BookFactory` utilise le pattern de conception _Factory_ pour créer des objets `Book`. Cette classe fournit une méthode `CreateBook` pour instancier des livres.
    
2. **Polymorphisme** : L'utilisation de classes abstraites (`Category`) avec des méthodes virtuelles (`AddBook`, `RemoveBook`) permet aux sous-classes (`BookCategory`) de redéfinir ces méthodes selon leurs besoins spécifiques.
    
3. **Encapsulation** : Les classes `Book`, `Category`, et `Bibliotheque` encapsulent leurs données et fonctionnalités dans des structures logiques distinctes.
    
4. **Interface** : L'interface `IBook` fournit un contrat pour la création de livres (`CreateBook`).


