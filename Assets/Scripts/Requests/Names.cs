public static class Names
{
    public static string GetRandomName(SocialClass socialClass)
    {
        string[] names;
        switch (socialClass)
        {
            case SocialClass.Overlord:
                names = Overlord;
                break;
            case SocialClass.Lord:
                names = Lord;
                break;
            case SocialClass.Peasant:
                names = Peasant;
                break;
            default:
                throw new System.Exception("Invalid social class");
        }
        return names[UnityEngine.Random.Range(0, names.Length)];
    }

    public static string[] Overlord = new string[] {
        "Richard",
        "William",
        "Henry",
        "Edward",
        "John",
        "Eleanor",
        "Matilda",
        "Isabella",
        "Philippa",
        "Joan",
        "Adela",
        "Agatha",
        "Alice",
        "Beatrice",
        "Blanche",
        "Constance",
        "Edith",
        "Emma",
        "Gundreda",
        "Mabel",
        "Margaret",
        "Mary",
        "Maude",
        "Melisende",
        "Petronilla",
        "Sibylla",
        "Sybil",
        "Theobald",
        "Waleran"
    };
    public static string[] Lord = new string[] {
        "Geoffrey",
        "Robert",
        "Simon",
        "Thomas",
        "Gilbert",
        "Stephen",
        "Roger",
        "Hugh",
        "Bartholomew",
        "Nicholas",
        "Adam",
        "Alan",
        "Baldwin",
        "Bernard",
        "Brian",
        "Clement",
        "Drogo",
        "Eustace",
        "Fulk",
        "Gervase",
        "Herbert",
        "Humphrey",
        "Ingelram",
        "Jocelin",
        "Lambert",
        "Milo",
        "Odo",
        "Piers",
        "Ralph"
    };
    public static string[] Peasant = new string[] {
        "John",
        "William",
        "Thomas",
        "Robert",
        "Richard",
        "Henry",
        "Roger",
        "Walter",
        "Gilbert",
        "Simon",
        "Adam",
        "Andrew",
        "Baldwin",
        "Bartholomew",
        "Clement",
        "David",
        "Elias",
        "Francis",
        "Gervase",
        "Hamon",
        "Isaac",
        "Jasper",
        "Lucas",
        "Martin",
        "Nicholas",
        "Peter",
        "Ralph",
        "Sampson",
        "Stephen"
    };
}
