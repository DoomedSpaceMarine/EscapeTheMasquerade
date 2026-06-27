using UnityEngine;

[CreateAssetMenu(fileName = "ClothItem", menuName = "Scriptable Objects/ClothItem")]
public class ClothItemSO : ScriptableObject
{
    public Sprite wardrobeSprite;
    public Sprite wornSprite;
    public ClothType clothType;
    public ClothTag clothTag;
}
