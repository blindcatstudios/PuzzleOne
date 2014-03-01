
using UnityEngine;
using UnityEditor;
using System.Reflection;

#if !UNITY_FLASH
public class MegaCopyObjects : MonoBehaviour
{
	[MenuItem("GameObject/Mega Copy Object")]
	static void DoCopyObjects()
	{
		GameObject from = Selection.activeGameObject;
		MegaCopyObject.DoCopyObjects(from);
	}

	[MenuItem("GameObject/Mega Copy Hier")]
	static void DoCopyObjectsHier()
	{
		GameObject from = Selection.activeGameObject;
		MegaCopyObject.DoCopyObjectsChildren(from);
	}

	[MenuItem("GameObject/Create Mega Prefab")]
	static void DoCreateSimplePrefab()
	{
#if true
		GameObject prefab = PrefabUtility.CreatePrefab("Assets/Temporary/" + Selection.activeGameObject.name + ".prefab", Selection.activeGameObject);

		MeshFilter mf = Selection.activeGameObject.GetComponent<MeshFilter>();
		if ( mf )
		{
			MeshFilter newmf = prefab.GetComponent<MeshFilter>();
			newmf.sharedMesh = CloneMesh(mf.sharedMesh);
		}
		PrefabUtility.DisconnectPrefabInstance(prefab);
#else
		Transform[] transforms = Selection.transforms;
		foreach ( Transform t in transforms )
		{
			//Object prefab = EditorUtility.CreateEmptyPrefab("Assets/Temporary/" + t.gameObject.name + ".prefab");
			Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/Temporary/" + t.gameObject.name + ".prefab");

			MeshFilter mf = t.gameObject.GetComponent<MeshFilter>();
			Mesh ms = mf.sharedMesh;
			Debug.Log("Mesh " + ms);
			GameObject newgo = EditorUtility.ReplacePrefab(t.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);

			MeshFilter newmf = newgo.GetComponent<MeshFilter>();
			//Mesh newms = newmf.sharedMesh;
			//Debug.Log("Mesh " + newms);
			newmf.sharedMesh = CloneMesh(ms);
		}
#endif
	}


	static Mesh CloneMesh(Mesh mesh)
	{
		Mesh clonemesh = new Mesh();
		clonemesh.vertices = mesh.vertices;
		clonemesh.uv1 = mesh.uv1;
		clonemesh.uv2 = mesh.uv2;
		clonemesh.uv = mesh.uv;
		clonemesh.normals = mesh.normals;
		clonemesh.tangents = mesh.tangents;
		clonemesh.colors = mesh.colors;

		clonemesh.subMeshCount = mesh.subMeshCount;

		for ( int s = 0; s < mesh.subMeshCount; s++ )
		{
			clonemesh.SetTriangles(mesh.GetTriangles(s), s);
		}

		//clonemesh.triangles = mesh.triangles;

		clonemesh.boneWeights = mesh.boneWeights;
		clonemesh.bindposes = mesh.bindposes;
		clonemesh.name = mesh.name + "_copy";
		clonemesh.RecalculateBounds();

		return clonemesh;
	}
}
#endif