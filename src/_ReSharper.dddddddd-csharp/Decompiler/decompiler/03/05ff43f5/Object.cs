// Type: UnityEngine.Object
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine
{
  [StructLayout(LayoutKind.Sequential)]
  public class Object
  {
    private ReferenceData m_UnityRuntimeReferenceData;
    private string m_UnityRuntimeErrorString;

    public string name { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public HideFlags hideFlags { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public static implicit operator bool(UnityEngine.Object exists)
    {
      return !UnityEngine.Object.CompareBaseObjects(exists, (UnityEngine.Object) null);
    }

    public static bool operator ==(UnityEngine.Object x, UnityEngine.Object y)
    {
      return UnityEngine.Object.CompareBaseObjects(x, y);
    }

    public static bool operator !=(UnityEngine.Object x, UnityEngine.Object y)
    {
      return !UnityEngine.Object.CompareBaseObjects(x, y);
    }

    public override bool Equals(object o)
    {
      return UnityEngine.Object.CompareBaseObjects(this, o as UnityEngine.Object);
    }

    public override int GetHashCode()
    {
      return this.GetInstanceID();
    }

    private static bool CompareBaseObjects(UnityEngine.Object lhs, UnityEngine.Object rhs)
    {
      return UnityEngine.Object.CompareBaseObjectsInternal(lhs, rhs);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static bool CompareBaseObjectsInternal([Writable] UnityEngine.Object lhs, [Writable] UnityEngine.Object rhs);

    [NotRenamed]
    public int GetInstanceID()
    {
      return this.m_UnityRuntimeReferenceData.instanceID;
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static UnityEngine.Object Internal_CloneSingle(UnityEngine.Object data);

    private static UnityEngine.Object Internal_InstantiateSingle(UnityEngine.Object data, Vector3 pos, Quaternion rot)
    {
      return UnityEngine.Object.INTERNAL_CALL_Internal_InstantiateSingle(data, ref pos, ref rot);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static UnityEngine.Object INTERNAL_CALL_Internal_InstantiateSingle(UnityEngine.Object data, ref Vector3 pos, ref Quaternion rot);

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation)
    {
      UnityEngine.Object.CheckNullArgument((object) original, "The prefab you want to instantiate is null.");
      return UnityEngine.Object.Internal_InstantiateSingle(original, position, rotation);
    }

    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static UnityEngine.Object Instantiate(UnityEngine.Object original)
    {
      UnityEngine.Object.CheckNullArgument((object) original, "The thing you want to instantiate is null.");
      return UnityEngine.Object.Internal_CloneSingle(original);
    }

    private static void CheckNullArgument(object arg, string message)
    {
      if (arg == null)
        throw new ArgumentException(message);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static void Destroy(UnityEngine.Object obj, [DefaultValue("0.0F")] float t);

    [ExcludeFromDocs]
    public static void Destroy(UnityEngine.Object obj)
    {
      float t = 0.0f;
      UnityEngine.Object.Destroy(obj, t);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static void DestroyImmediate(UnityEngine.Object obj, [DefaultValue("false")] bool allowDestroyingAssets);

    [ExcludeFromDocs]
    public static void DestroyImmediate(UnityEngine.Object obj)
    {
      bool allowDestroyingAssets = false;
      UnityEngine.Object.DestroyImmediate(obj, allowDestroyingAssets);
    }

    [WrapperlessIcall]
    [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static UnityEngine.Object[] FindObjectsOfType(System.Type type);

    public static T[] FindObjectsOfType<T>() where T : UnityEngine.Object
    {
      return Resources.ConvertObjects<T>(UnityEngine.Object.FindObjectsOfType(typeof (T)));
    }

    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    public static UnityEngine.Object FindObjectOfType(System.Type type)
    {
      UnityEngine.Object[] objectsOfType = UnityEngine.Object.FindObjectsOfType(type);
      if (objectsOfType.Length > 0)
        return objectsOfType[0];
      else
        return (UnityEngine.Object) null;
    }

    public static T FindObjectOfType<T>() where T : UnityEngine.Object
    {
      return (T) UnityEngine.Object.FindObjectOfType(typeof (T));
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static void DontDestroyOnLoad(UnityEngine.Object target);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static void DestroyObject(UnityEngine.Object obj, [DefaultValue("0.0F")] float t);

    [ExcludeFromDocs]
    public static void DestroyObject(UnityEngine.Object obj)
    {
      float t = 0.0f;
      UnityEngine.Object.DestroyObject(obj, t);
    }

    [Obsolete("use Object.FindObjectsOfType instead.")]
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static UnityEngine.Object[] FindSceneObjectsOfType(System.Type type);

    [Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static UnityEngine.Object[] FindObjectsOfTypeIncludingAssets(System.Type type);

    [Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
    public static UnityEngine.Object[] FindObjectsOfTypeAll(System.Type type)
    {
      return Resources.FindObjectsOfTypeAll(type);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public override string ToString();
  }
}
