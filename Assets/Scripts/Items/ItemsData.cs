using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Item Data", order = 51)]
public class ItemsData : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private int type;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private bool stackable;

    public int Id{
        get{
            return id;
        }
    }
    
    public int Type{
        get{
            return type;
        }
    }
    public string ItemName{
        get{
            return itemName;
        }
    }
    public bool Stackable{
        get{
            return stackable;
        }
    }
}
