namespace RPGAdventureTome.Items;

public abstract class Item
{
    public string name { get; }
    public string description { get; }
    public ItemType itemType { get; }

    protected Item(string name, string description,  ItemType itemType)
    {
        this.name = name;
        this.description = description;
        this.itemType = itemType;
    }
}