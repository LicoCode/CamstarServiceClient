using CamstarServiceClient.Reflection;
using CamstarServiceClient.Service;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace CamstarServiceClient.Reflection {
    /// <summary>
    /// 为提高反射效率，建立反射信息缓存
    /// </summary>
    public class ReflectionCache
    {
        /// <summary>
        /// 缓存service类的属性字段
        /// </summary>
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyInfos = new ConcurrentDictionary<Type, PropertyInfo[]>();
        public static PropertyInfo[] GetPropertyInfos(Type type)
        {
            return _propertyInfos.GetOrAdd(type, t => t.GetProperties());
        }

        /// <summary>
        /// 缓存属性字段的类型（NamedObjectData/RevisionedObject/ICollection/Nullable<Enum>/Nullable<Primitive>等）
        /// </summary>
        private static readonly ConcurrentDictionary<Type, ReflectionTypeEnum> _cdoTypes = new ConcurrentDictionary<Type, ReflectionTypeEnum>();
        public static ReflectionTypeEnum GetCDOTypes(Type type)
        {
            return _cdoTypes.GetOrAdd(type, t => ReflectionUtil.GetCDOType(t));
        }

        /// <summary>
        /// 方法缓存
        /// </summary>
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, MethodInfo>> _methodsCache =
            new ConcurrentDictionary<Type, ConcurrentDictionary<string, MethodInfo>>();
        public static MethodInfo GetMethod(Type type, string methodName)
        {
            var methodsForType = _methodsCache.GetOrAdd(type, t => new ConcurrentDictionary<string, MethodInfo>());

            return methodsForType.GetOrAdd(methodName, name =>
            {
                var method = type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance);
                if (method == null)
                {
                    throw new MissingMethodException($"{type.FullName} does not have a public instance method named '{name}'.");
                }
                return method;
            });
        }

    }
}
