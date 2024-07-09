using CamstarService.ServiceContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.Reflection
{
    public class ReflectionUtil
    {
        /// <summary>
        /// 获取Type的类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ReflectionTypeEnum GetCDOType(Type type)
        {
            var propertyType = type;
            if (IsPrimitive(propertyType))
            {
                return ReflectionTypeEnum.PrimitiveValue;
            }
            else if (IsString(propertyType))
            {
                return ReflectionTypeEnum.String;
            }
            else if (IsDateTime(propertyType))
            {
                return ReflectionTypeEnum.DateTime;
            }
            else if (IsContainer(propertyType))
            {
                return ReflectionTypeEnum.Container;
            }
            else if (IsRevisionedObjectMaint(propertyType))
            {
                return ReflectionTypeEnum.RevisionedObjectMaint;
            }
            else if (IsNamedDataObjectMaint(propertyType))
            {
                return ReflectionTypeEnum.NamedDataObjectMaint;
            }
            else if (IsNamedDataObject(propertyType))
            {
                return ReflectionTypeEnum.NamedDataObject;
            }
            else if (IsRevisionedObject(propertyType))
            {
                return ReflectionTypeEnum.RevisionedObject;
            }
            else if (IsNamedDataObjectChanges(propertyType))
            {
                return ReflectionTypeEnum.ObjectChanges;
            }
            else if (IsRevisionedObjectChanges(propertyType))
            {
                return ReflectionTypeEnum.ObjectChanges;
            }
            else if (IsNamedSubentityChangesCollection(propertyType))
            {
                return ReflectionTypeEnum.NamedSubentityChangesCollection;
            }
            else if (IsNamedSubentity(propertyType))
            {
                return ReflectionTypeEnum.NamedSubentity;
            }
            else if (IsSubentity(propertyType))
            {
                return ReflectionTypeEnum.Subentity;
            }
            else if (IsSubentityCollection(propertyType))
            {
                return ReflectionTypeEnum.SubentityCollection;
            }
            else if (IsEnum(propertyType))
            {
                return ReflectionTypeEnum.EnumValue;
            }
            else if (IsContainerCollection(propertyType))
            {
                return ReflectionTypeEnum.ContainerCollection;
            }
            else if (IsRevisionedObjectCollection(propertyType))
            {
                return ReflectionTypeEnum.RevisionedObjectCollection;
            }
            else if (IsNamedDataObjectCollection(propertyType))
            {
                return ReflectionTypeEnum.NamedDataObjectCollection;
            }
            else
            {
                return ReflectionTypeEnum.Other; 
            }
        }


        /// <summary>
        /// 是否为NDO
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedDataObject(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(NamedDataObject)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为Container
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsContainer(Type type)
        {
            if (!type.IsGenericType && type.Equals(typeof(ContainerRef)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsRevisionedObjectMaint(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(RevisionedObjectMaint)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedDataObjectMaint(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(NamedDataObjectMaint)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为RO
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsRevisionedObject(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(RevisionedObject)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为ROChanges
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsRevisionedObjectChanges(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(RevisionedObjectChanges)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为ROChanges
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedDataObjectChanges(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(NamedDataObjectChanges)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为ServiceData
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsSubentity(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(Subentity)) && !IsNamedSubentity(type))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为ServiceData
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedSubentity(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(NamedSubentity)))
            {
                return true;
            }
            return false;
        }
        private static bool IsNamedSubentityChanges(Type type)
        {
            if (!type.IsGenericType && type.IsSubclassOf(typeof(NamedSubentityChanges)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为ServiceData集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsSubentityCollection(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && IsSubentity(arg[0]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为namedsubentitychanges集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedSubentityChangesCollection(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && IsNamedSubentityChanges(arg[0]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为NDO集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNamedDataObjectCollection(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && IsNamedDataObject(arg[0]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为Container集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsContainerCollection(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && IsContainer(arg[0]))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 是否为RO集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsRevisionedObjectCollection(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && IsRevisionedObject(arg[0]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为可为null的枚举类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsEnum(Type type)
        {

            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && arg[0].IsEnum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return type.IsEnum;
            }
        }
        /// <summary>
        /// 是否为可为null的基本数据类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsPrimitive(Type type)
        {
            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && arg[0].IsPrimitive)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return type.IsPrimitive;
            }
        }
        /// <summary>
        /// 是否为字符串
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsString(Type type)
        {

            if (!type.IsGenericType && type.Equals(typeof(string)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为时间格式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsDateTime(Type type)
        {
            if (type.IsGenericType)
            {
                Type[] arg = type.GetGenericArguments();
                if (arg.Length > 0 && arg[0].Equals(typeof(DateTime)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (!type.IsGenericType && type.Equals(typeof(DateTime)))
            {
                return true;
            }
            return false;
        }
    }
}
