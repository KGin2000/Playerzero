using System.Collections.Generic;
using UnityEngine;

public class SO_CropDetailsList : ScriptableObject
{
   [SerializeField]
   public List<CropDetails> cropDetails;

   public CropDetails GetCropDetails(int seedItemCode)
   {
       return cropDetails.Find(x => x.seedItemCode == seedItemCode);
   }
}
