using System.Collections.Generic;
using UnityEngine;

public class HurdlesHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> gb_hurdles;

    public void ChangeLayerByName(string layerName)
    {
        // It's safer to use LayerMask.NameToLayer to avoid typos
        int layer = LayerMask.NameToLayer(layerName);

        if (layer != -1) // Check if the layer actually exists
        {
            foreach (GameObject gb in gb_hurdles)
                gb.layer = layer;
        }
    }
}
