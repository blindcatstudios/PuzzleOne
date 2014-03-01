// Type: UnityEngine.MonoBehaviour
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine
{
  public class MonoBehaviour : Behaviour
  {
    public bool useGUILayout { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public MonoBehaviour();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void Internal_CancelInvokeAll();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private bool Internal_IsInvokingAll();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void Invoke(string methodName, float time);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void InvokeRepeating(string methodName, float time, float repeatRate);

    public void CancelInvoke()
    {
      this.Internal_CancelInvokeAll();
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void CancelInvoke(string methodName);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public bool IsInvoking(string methodName);

    public bool IsInvoking()
    {
      return this.Internal_IsInvokingAll();
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
      return this.StartCoroutine_Auto(routine);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Coroutine StartCoroutine_Auto(IEnumerator routine);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);

    [ExcludeFromDocs]
    public Coroutine StartCoroutine(string methodName)
    {
      object obj = (object) null;
      return this.StartCoroutine(methodName, obj);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void StopCoroutine(string methodName);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void StopAllCoroutines();

    public static void print(object message)
    {
      Debug.Log(message);
    }
  }
}
