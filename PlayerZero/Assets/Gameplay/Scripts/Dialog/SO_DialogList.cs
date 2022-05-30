
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_ItemList", menuName = "Scriptable Object/Dialog/Dialog List")]
public class SO_DialogList : ScriptableObject
{
  [SerializeField]
  public List<DialogDetails> dialogDetails;
}