
public class CharacterInfo
{
    public string name;
    public uint price;
    public CharacterState state;

    public CharacterInfo(string name, uint price, CharacterState state)
    {
        this.name = name;
        this.price = price;
        this.state = state;
    }
    public CharacterInfo() {
        this.name = "";
        this.price = 0;
        this.state = CharacterState.Sale;
    }
}

public enum CharacterState
{
    Bought,     // Персонаж куплен
    Sale,       // Персонаж не куплен
    Selected    // Персонаж выбран для игры
}