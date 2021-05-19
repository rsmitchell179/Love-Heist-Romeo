using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    public float fov;
    public float viewDistance;
    private Vector3 origin;
    public float startingAngle, desiredAngle;
    [Range(0, 0.1f)]
    public float rotationSpeed = 1.0f;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        viewDistance = 10f;
        origin = Vector3.zero;
    }

    private void Update()
    {
        //SetAimDirection(GetMouseWorldPosition() - transform.position.normalized);
    }

    private void LateUpdate()
    {
        startingAngle = Mathf.Lerp(startingAngle, desiredAngle, rotationSpeed);
        //Debug.Log("startingAngle :" + startingAngle);
        int rayCount = 200;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D hit = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (hit.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = hit.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetRandomAimDirection(int min = -90, int max = 90)
    {

        desiredAngle = startingAngle + UnityEngine.Random.Range(min, max); //GetAngleFromVectorFloat(aimDirection) + fov / 2f;
        if (desiredAngle < 0) desiredAngle += 360;


        if (desiredAngle > startingAngle)
        {
            //Debug.Log("Fov make a LEFT rotation");
        }
        else
        {
            //Debug.Log("Fov make a RIGHT rotation");
        }
    }

    public void SetAimFromDirection(Vector3 dir)
    {
        dir = dir.normalized;
        desiredAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (desiredAngle < 0) desiredAngle += 360;


        if (desiredAngle > startingAngle)
        {
           // Debug.Log("Fov make a LEFT rotation");
        }
        else
        {
            //Debug.Log("Fov make a RIGHT rotation");
        }
    }

    public void SetFoV(float fov)
    {
        this.fov = fov;
    }

    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * Mathf.PI / 180f;
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    private Vector3 GetMouseWorldPosition()
    {
        var v3 = Input.mousePosition;
        v3.z = 10f;
        v3 = mainCam.ScreenToWorldPoint(v3);
        return v3;
    }
}
