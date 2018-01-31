using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour
{

    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public float Floor_Width = 5.0f;
    public float Floor_Depth = 10.0f;
    public float Floor_Height = 0.25f;
    public float Pillar_Radius = 0.2f;
    public float Pillar_Height = 2.0f;
    public float Pillar_Count_Width = 6.0f;
    public float Pillar_Count_Depth = 10.0f;
    public float Roof_Height = 1.0f;

    public Material Floor_Material;
    public Material Pillar_Material;
    public Material Roof_Material;



    [ContextMenu("Parthenon Build")]
    void Parthenon_Build()
    {
        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localPosition = new Vector3(0, 0, 0);
        floor1.transform.localScale = new Vector3(Floor_Width, Floor_Height, Floor_Depth);

        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localPosition = new Vector3(0, Floor_Height, 0);
        floor2.transform.localScale = new Vector3(Floor_Width * 0.95f, Floor_Height, Floor_Depth * 0.95f);

        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localPosition = new Vector3(0, Floor_Height * 2, 0);
        floor3.transform.localScale = new Vector3(Floor_Width * 0.9025f, Floor_Height, Floor_Depth * 0.9025f);
    }

    [ContextMenu("Parthenon Pillar")]
    void Parthenon_Pillar()
    {
    }
}