
using System;
using System.Linq;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public float floorWidth = 31.0f;
    public float floorDepth = 69.5f;
    public float floorHeight = 0.1f;
    public float pillarRadius = 0.5f;
    public float pillarHeight = 1.0f;
    public float pillarCountWidth = 3;
    public float pillarCountDepth = 6;
    public float roofHeight = 1.0f;
    public Material floorMaterial;
    public Material pillarMaterial;
    public Material roofMaterial;

    float topFloorWidth;
    float topFloorDepth;
    float topFloorHeight;

    [ContextMenu("Build Now")]
    void BuildNow()
    {
        DestroyAllChildren();
        InstantiateFloor();
        InstantiatePillars();
        InstantiateRoof();
    }

    private void InstantiateRoof()
    {
        var roof = Instantiate(cubePrefab, transform);
        roof.transform.localScale = new Vector3(topFloorWidth, roofHeight, topFloorDepth);
        roof.transform.Translate(Vector3.up * (topFloorHeight + pillarHeight));
        roof.GetComponentInChildren<Renderer>().material = roofMaterial;
    }

    private void InstantiatePillars()
    {
        var pillarIntervalWidth = 2 * (topFloorWidth / 2 - pillarRadius) / (pillarCountWidth - 1);
        InstantiatePillarWidthDirection(pillarIntervalWidth, -topFloorDepth / 2 + pillarRadius);
        InstantiatePillarWidthDirection(pillarIntervalWidth, +topFloorDepth / 2 - pillarRadius);

        var pillarIntervalDepth = 2 * (topFloorDepth / 2 - pillarRadius) / (pillarCountDepth - 1);
        InstantiatePillarDepthDirection(pillarIntervalDepth, -topFloorWidth / 2 + pillarRadius);
        InstantiatePillarDepthDirection(pillarIntervalDepth, +topFloorWidth / 2 - pillarRadius);
    }

    private void InstantiatePillarWidthDirection(float pillarIntervalWidth, float z)
    {
        for (int i = 0; i < pillarCountWidth; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            pillar.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar.transform.localPosition = new Vector3(-topFloorWidth / 2 + pillarRadius + pillarIntervalWidth * i, topFloorHeight, z);
            pillar.GetComponentInChildren<Renderer>().material = pillarMaterial;
        }
    }

    private void InstantiatePillarDepthDirection(float pillarIntervalDepth, float x)
    {
        for (int i = 1; i < pillarCountDepth - 1; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            pillar.transform.localScale = new Vector3(pillarRadius / 0.5f, pillarHeight, pillarRadius / 0.5f);
            pillar.transform.localPosition = new Vector3(x, topFloorHeight, -topFloorDepth / 2 + pillarRadius + pillarIntervalDepth * i);
            pillar.GetComponentInChildren<Renderer>().material = pillarMaterial;
        }
    }

    private void InstantiateFloor()
    {
        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localScale = new Vector3(floorWidth, floorHeight, floorDepth);
        floor1.GetComponentInChildren<Renderer>().material = floorMaterial;

        var unitSizeDecrement = floorWidth / 20;

        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localScale = new Vector3(floorWidth - unitSizeDecrement, floorHeight, floorDepth - unitSizeDecrement);
        floor2.transform.Translate(Vector3.up * floorHeight);
        floor2.GetComponentInChildren<Renderer>().material = floorMaterial;

        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localScale = new Vector3(floorWidth - unitSizeDecrement * 2, floorHeight, floorDepth - unitSizeDecrement * 2);
        floor3.transform.Translate(Vector3.up * floorHeight * 2);
        floor3.GetComponentInChildren<Renderer>().material = floorMaterial;

        topFloorWidth = floor3.transform.localScale.x;
        topFloorHeight = floorHeight * 3;
        topFloorDepth = floor3.transform.localScale.z;
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(child.gameObject);
        }
        Debug.Assert(transform.childCount == 0);
    }
}