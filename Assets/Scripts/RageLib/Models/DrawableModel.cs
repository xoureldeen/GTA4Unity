using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model3DGroup : GeometryModel3D
{
    public List<GeometryModel3D> Children = new List<GeometryModel3D>();
}

public class MeshGeometry3D
{
    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> normals = new List<Vector3>();
    public List<Vector2> textureCoordinates = new List<Vector2>();
    public List<int> triangleIndices = new List<int>();

    public Mesh GetUnityMesh()
    {
        var mesh = new Mesh();
        mesh.vertices = positions.ToArray();
        mesh.normals = normals.ToArray();
        mesh.uv = textureCoordinates.ToArray();
        mesh.triangles = triangleIndices.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.UploadMeshData(false);
        return mesh;
    }
}

public class GeometryModel3D
{
    public MeshGeometry3D geometry;
    public RageMaterial material;
    public GeometryModel3D() { }
    public GeometryModel3D(MeshGeometry3D geometry, RageMaterial material)
    {
        this.geometry = geometry;
        this.material = material;
    }
}

[System.Serializable]
public class RageMaterial
{
    public RageMaterial(string shaderName, string textureName, RageUnityTexture mainTex)
    {
        this.shaderName = shaderName;
        this.textureName = textureName;
        this.mainTex = mainTex;
    }

    public RageUnityTexture mainTex;
    public string shaderName;
    public string textureName;
}

[System.Serializable]

public class RageUnityTexture
{
    public RageUnityTexture(int width, int height, TextureFormat format, bool mipChain)
    {
        this.width = width;
        this.height = height;
        this.format = format;
        this.mipChain = mipChain;
    }

    public string name;
    public int width;
    public int height;
    public TextureFormat format;
    public bool mipChain;
    public Color32[] pixels;

    public Texture2D GetUnityTexture()
    {
        Texture2D texture = new Texture2D(width, height, format, mipChain);
        texture.name = name;
        if (pixels != null)
        {
            texture.SetPixels32(pixels);
        }
        texture.Apply(false, true);
        return texture;
    }
}