// Type: UnityEngine.Vector3
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine
{
  public struct Vector3
  {
    public const float kEpsilon = 1E-05f;
    public float x;
    public float y;
    public float z;

    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.x;
          case 1:
            return this.y;
          case 2:
            return this.z;
          default:
            throw new IndexOutOfRangeException("Invalid Vector3 index!");
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.x = value;
            break;
          case 1:
            this.y = value;
            break;
          case 2:
            this.z = value;
            break;
          default:
            throw new IndexOutOfRangeException("Invalid Vector3 index!");
        }
      }
    }

    public Vector3 normalized
    {
      get
      {
        return Vector3.Normalize(this);
      }
    }

    public float magnitude
    {
      get
      {
        return Mathf.Sqrt((float) ((double) this.x * (double) this.x + (double) this.y * (double) this.y + (double) this.z * (double) this.z));
      }
    }

    public float sqrMagnitude
    {
      get
      {
        return (float) ((double) this.x * (double) this.x + (double) this.y * (double) this.y + (double) this.z * (double) this.z);
      }
    }

    public static Vector3 zero
    {
      get
      {
        return new Vector3(0.0f, 0.0f, 0.0f);
      }
    }

    public static Vector3 one
    {
      get
      {
        return new Vector3(1f, 1f, 1f);
      }
    }

    public static Vector3 forward
    {
      get
      {
        return new Vector3(0.0f, 0.0f, 1f);
      }
    }

    public static Vector3 back
    {
      get
      {
        return new Vector3(0.0f, 0.0f, -1f);
      }
    }

    public static Vector3 up
    {
      get
      {
        return new Vector3(0.0f, 1f, 0.0f);
      }
    }

    public static Vector3 down
    {
      get
      {
        return new Vector3(0.0f, -1f, 0.0f);
      }
    }

    public static Vector3 left
    {
      get
      {
        return new Vector3(-1f, 0.0f, 0.0f);
      }
    }

    public static Vector3 right
    {
      get
      {
        return new Vector3(1f, 0.0f, 0.0f);
      }
    }

    [Obsolete("Use Vector3.forward instead.")]
    public static Vector3 fwd
    {
      get
      {
        return new Vector3(0.0f, 0.0f, 1f);
      }
    }

    public Vector3(float x, float y, float z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public Vector3(float x, float y)
    {
      this.x = x;
      this.y = y;
      this.z = 0.0f;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector3 operator -(Vector3 a)
    {
      return new Vector3(-a.x, -a.y, -a.z);
    }

    public static Vector3 operator *(Vector3 a, float d)
    {
      return new Vector3(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3 operator *(float d, Vector3 a)
    {
      return new Vector3(a.x * d, a.y * d, a.z * d);
    }

    public static Vector3 operator /(Vector3 a, float d)
    {
      return new Vector3(a.x / d, a.y / d, a.z / d);
    }

    public static bool operator ==(Vector3 lhs, Vector3 rhs)
    {
      return (double) Vector3.SqrMagnitude(lhs - rhs) < 0.0 / 1.0;
    }

    public static bool operator !=(Vector3 lhs, Vector3 rhs)
    {
      return (double) Vector3.SqrMagnitude(lhs - rhs) >= 0.0 / 1.0;
    }

    public static Vector3 Lerp(Vector3 from, Vector3 to, float t)
    {
      t = Mathf.Clamp01(t);
      return new Vector3(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t, from.z + (to.z - from.z) * t);
    }

    public static Vector3 Slerp(Vector3 from, Vector3 to, float t)
    {
      return Vector3.INTERNAL_CALL_Slerp(ref from, ref to, t);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_Slerp(ref Vector3 from, ref Vector3 to, float t);

    private static void Internal_OrthoNormalize2(ref Vector3 a, ref Vector3 b)
    {
      Vector3.INTERNAL_CALL_Internal_OrthoNormalize2(ref a, ref b);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void INTERNAL_CALL_Internal_OrthoNormalize2(ref Vector3 a, ref Vector3 b);

    private static void Internal_OrthoNormalize3(ref Vector3 a, ref Vector3 b, ref Vector3 c)
    {
      Vector3.INTERNAL_CALL_Internal_OrthoNormalize3(ref a, ref b, ref c);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void INTERNAL_CALL_Internal_OrthoNormalize3(ref Vector3 a, ref Vector3 b, ref Vector3 c);

    public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent)
    {
      Vector3.Internal_OrthoNormalize2(ref normal, ref tangent);
    }

    public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal)
    {
      Vector3.Internal_OrthoNormalize3(ref normal, ref tangent, ref binormal);
    }

    public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
    {
      Vector3 vector3 = target - current;
      float magnitude = vector3.magnitude;
      if ((double) magnitude <= (double) maxDistanceDelta || (double) magnitude == 0.0)
        return target;
      else
        return current + vector3 / magnitude * maxDistanceDelta;
    }

    public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta)
    {
      return Vector3.INTERNAL_CALL_RotateTowards(ref current, ref target, maxRadiansDelta, maxMagnitudeDelta);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_RotateTowards(ref Vector3 current, ref Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta);

    [ExcludeFromDocs]
    public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed)
    {
      float deltaTime = Time.deltaTime;
      return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    [ExcludeFromDocs]
    public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime)
    {
      float deltaTime = Time.deltaTime;
      float maxSpeed = float.PositiveInfinity;
      return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
    {
      smoothTime = Mathf.Max(0.0001f, smoothTime);
      float num1 = 2f / smoothTime;
      float num2 = num1 * deltaTime;
      float num3 = (float) (1.0 / (1.0 + (double) num2 + 0.479999989271164 * (double) num2 * (double) num2 + 0.234999999403954 * (double) num2 * (double) num2 * (double) num2));
      Vector3 vector = current - target;
      Vector3 vector3_1 = target;
      float maxLength = maxSpeed * smoothTime;
      Vector3 vector3_2 = Vector3.ClampMagnitude(vector, maxLength);
      target = current - vector3_2;
      Vector3 vector3_3 = (currentVelocity + num1 * vector3_2) * deltaTime;
      currentVelocity = (currentVelocity - num1 * vector3_3) * num3;
      Vector3 vector3_4 = target + (vector3_2 + vector3_3) * num3;
      if ((double) Vector3.Dot(vector3_1 - current, vector3_4 - vector3_1) > 0.0)
      {
        vector3_4 = vector3_1;
        currentVelocity = (vector3_4 - vector3_1) / deltaTime;
      }
      return vector3_4;
    }

    public void Set(float new_x, float new_y, float new_z)
    {
      this.x = new_x;
      this.y = new_y;
      this.z = new_z;
    }

    public static Vector3 Scale(Vector3 a, Vector3 b)
    {
      return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public void Scale(Vector3 scale)
    {
      this.x *= scale.x;
      this.y *= scale.y;
      this.z *= scale.z;
    }

    public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3((float) ((double) lhs.y * (double) rhs.z - (double) lhs.z * (double) rhs.y), (float) ((double) lhs.z * (double) rhs.x - (double) lhs.x * (double) rhs.z), (float) ((double) lhs.x * (double) rhs.y - (double) lhs.y * (double) rhs.x));
    }

    public override int GetHashCode()
    {
      return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
    }

    public override bool Equals(object other)
    {
      if (!(other is Vector3))
        return false;
      Vector3 vector3 = (Vector3) other;
      if (this.x.Equals(vector3.x) && this.y.Equals(vector3.y))
        return this.z.Equals(vector3.z);
      else
        return false;
    }

    public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
    {
      return -2f * Vector3.Dot(inNormal, inDirection) * inNormal + inDirection;
    }

    public static Vector3 Normalize(Vector3 value)
    {
      float num = Vector3.Magnitude(value);
      if ((double) num > 9.99999974737875E-06)
        return value / num;
      else
        return Vector3.zero;
    }

    public void Normalize()
    {
      float num = Vector3.Magnitude(this);
      if ((double) num > 9.99999974737875E-06)
        this = this / num;
      else
        this = Vector3.zero;
    }

    public override string ToString()
    {
      string fmt = "({0:F1}, {1:F1}, {2:F1})";
      object[] objArray = new object[3];
      int index1 = 0;
      // ISSUE: variable of a boxed type
      __Boxed<float> local1 = (ValueType) this.x;
      objArray[index1] = (object) local1;
      int index2 = 1;
      // ISSUE: variable of a boxed type
      __Boxed<float> local2 = (ValueType) this.y;
      objArray[index2] = (object) local2;
      int index3 = 2;
      // ISSUE: variable of a boxed type
      __Boxed<float> local3 = (ValueType) this.z;
      objArray[index3] = (object) local3;
      return UnityString.Format(fmt, objArray);
    }

    public string ToString(string format)
    {
      string fmt = "({0}, {1}, {2})";
      object[] objArray = new object[3];
      int index1 = 0;
      string str1 = this.x.ToString(format);
      objArray[index1] = (object) str1;
      int index2 = 1;
      string str2 = this.y.ToString(format);
      objArray[index2] = (object) str2;
      int index3 = 2;
      string str3 = this.z.ToString(format);
      objArray[index3] = (object) str3;
      return UnityString.Format(fmt, objArray);
    }

    public static float Dot(Vector3 lhs, Vector3 rhs)
    {
      return (float) ((double) lhs.x * (double) rhs.x + (double) lhs.y * (double) rhs.y + (double) lhs.z * (double) rhs.z);
    }

    public static Vector3 Project(Vector3 vector, Vector3 onNormal)
    {
      float num = Vector3.Dot(onNormal, onNormal);
      if ((double) num < 1.40129846432482E-45)
        return Vector3.zero;
      else
        return onNormal * Vector3.Dot(vector, onNormal) / num;
    }

    public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat)
    {
      return fromThat - Vector3.Project(fromThat, excludeThis);
    }

    public static float Angle(Vector3 from, Vector3 to)
    {
      return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f)) * 57.29578f;
    }

    public static float Distance(Vector3 a, Vector3 b)
    {
      Vector3 vector3 = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
      return Mathf.Sqrt((float) ((double) vector3.x * (double) vector3.x + (double) vector3.y * (double) vector3.y + (double) vector3.z * (double) vector3.z));
    }

    public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
    {
      if ((double) vector.sqrMagnitude > (double) maxLength * (double) maxLength)
        return vector.normalized * maxLength;
      else
        return vector;
    }

    public static float Magnitude(Vector3 a)
    {
      return Mathf.Sqrt((float) ((double) a.x * (double) a.x + (double) a.y * (double) a.y + (double) a.z * (double) a.z));
    }

    public static float SqrMagnitude(Vector3 a)
    {
      return (float) ((double) a.x * (double) a.x + (double) a.y * (double) a.y + (double) a.z * (double) a.z);
    }

    public static Vector3 Min(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
    }

    public static Vector3 Max(Vector3 lhs, Vector3 rhs)
    {
      return new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
    }

    [Obsolete("Use Vector3.Angle instead. AngleBetween uses radians instead of degrees and was deprecated for this reason")]
    public static float AngleBetween(Vector3 from, Vector3 to)
    {
      return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f));
    }
  }
}
