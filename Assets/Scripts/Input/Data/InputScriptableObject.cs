using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputScriptableObject", order = 1)]
public class InputScriptableObject : ScriptableObject
{
    public new string name;
    public string description;

    public int id
    {
        get => (name + description).GetHashCode();
    }

    public Input ToInput()
    {
        return new Input(name);
    }
}


