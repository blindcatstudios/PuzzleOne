// Type: UnityEngine.Component
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine
{
  public class Component : UnityEngine.Object
  {
    public Transform transform
    {
      get
      {
        return this.InternalGetTransform();
      }
    }

    public Rigidbody rigidbody { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Rigidbody2D rigidbody2D { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Camera camera { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Light light { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Animation animation { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public ConstantForce constantForce { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Renderer renderer { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public AudioSource audio { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public GUIText guiText { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public NetworkView networkView { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Please use guiTexture instead")]
    public GUIElement guiElement { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public GUITexture guiTexture { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Collider collider { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Collider2D collider2D { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public HingeJoint hingeJoint { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public ParticleEmitter particleEmitter { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public ParticleSystem particleSystem { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public GameObject gameObject
    {
      get
      {
        return this.InternalGetGameObject();
      }
    }

    [Obsolete("the active property is deprecated on components. Please use gameObject.active instead. If you meant to enable / disable a single component use enabled instead.")]
    public bool active { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public string tag { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal Transform InternalGetTransform();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal GameObject InternalGetGameObject();

    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Component GetComponent(System.Type type);

    public T GetComponent<T>() where T : Component
    {
      return this.GetComponent(typeof (T)) as T;
    }

    public Component GetComponent(string type)
    {
      return this.gameObject.GetComponent(type);
    }

    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    public Component GetComponentInChildren(System.Type t)
    {
      return this.gameObject.GetComponentInChildren(t);
    }

    public T GetComponentInChildren<T>() where T : Component
    {
      return (T) this.GetComponentInChildren(typeof (T));
    }

    [ExcludeFromDocs]
    public Component[] GetComponentsInChildren(System.Type t)
    {
      bool includeInactive = false;
      return this.GetComponentsInChildren(t, includeInactive);
    }

    public Component[] GetComponentsInChildren(System.Type t, [DefaultValue("false")] bool includeInactive)
    {
      return this.gameObject.GetComponentsInChildren(t, includeInactive);
    }

    public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component
    {
      return this.gameObject.GetComponentsInChildren<T>(includeInactive);
    }

    public T[] GetComponentsInChildren<T>() where T : Component
    {
      return this.GetComponentsInChildren<T>(false);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Component[] GetComponents(System.Type type);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private Component[] GetComponentsWithCorrectReturnType(System.Type type);

    public T[] GetComponents<T>() where T : Component
    {
      return (T[]) this.GetComponentsWithCorrectReturnType(typeof (T));
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public bool CompareTag(string tag);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    [ExcludeFromDocs]
    public void SendMessageUpwards(string methodName, object value)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.SendMessageUpwards(methodName, value, options);
    }

    [ExcludeFromDocs]
    public void SendMessageUpwards(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object obj = (object) null;
      this.SendMessageUpwards(methodName, obj, options);
    }

    public void SendMessageUpwards(string methodName, SendMessageOptions options)
    {
      this.SendMessageUpwards(methodName, (object) null, options);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    [ExcludeFromDocs]
    public void SendMessage(string methodName, object value)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.SendMessage(methodName, value, options);
    }

    [ExcludeFromDocs]
    public void SendMessage(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object obj = (object) null;
      this.SendMessage(methodName, obj, options);
    }

    public void SendMessage(string methodName, SendMessageOptions options)
    {
      this.SendMessage(methodName, (object) null, options);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

    [ExcludeFromDocs]
    public void BroadcastMessage(string methodName, object parameter)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      this.BroadcastMessage(methodName, parameter, options);
    }

    [ExcludeFromDocs]
    public void BroadcastMessage(string methodName)
    {
      SendMessageOptions options = SendMessageOptions.RequireReceiver;
      object parameter = (object) null;
      this.BroadcastMessage(methodName, parameter, options);
    }

    public void BroadcastMessage(string methodName, SendMessageOptions options)
    {
      this.BroadcastMessage(methodName, (object) null, options);
    }
  }
}
