using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GTIC.Sincronizador.Enums
{
    public static class EnumHelper
    {
        public static string EnumToString<T>(this T t) where T : struct
        {
            return Enum.GetName(typeof(T), t);
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T StringToEnum<T>(this string s, T defaultValue) where T : struct
        {
            T t = defaultValue;
            if (!string.IsNullOrEmpty(s))
            {
                string[] aux = Enum.GetNames(typeof(T));
                if (aux != null && aux.Length > 0)
                {
                    s = s.ToLower();
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (aux[i].ToLower().Equals(s))
                        {
                            t = (T)Enum.GetValues(typeof(T)).GetValue(i);
                            break;
                        }
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// returns true if the description of items of type t contains one by "s" (upper or lower case)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Contains<T>(string s) where T : struct
        {
            if (s == null) s = string.Empty;
            Dictionary<T, string> aux = DisplayNames<T>();
            s = s.ToUpper();
            foreach (string curr in aux.Values)
            {
                if (curr != null && curr.ToUpper() == s)
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetDefaultAtt<T>(T GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (_Attribs != null && _Attribs.Length > 0)
                {
                    string s = ((DescriptionAttribute)_Attribs[0]).Description;
                    if (!string.IsNullOrEmpty(s))
                    {
                        return s;
                    }
                }
            }
            return GenericEnum.ToString();
        }

        private static string GettAtt<T>(T GenericEnum, params object[] attNames)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {

                var atts = memberInfo[0].GetCustomAttributesData();
                if (atts != null && atts.Count > 0)
                {
                    var theAtt = atts[0];
                    if (theAtt != null && theAtt.NamedArguments != null && theAtt.NamedArguments.Count > 0)
                    {
                        foreach (var x in theAtt.NamedArguments)
                        {
                            foreach (var attName in attNames)
                            {
                                if (x.MemberName == attName.ToString() && x.TypedValue.Value != null)
                                {
                                    return x.TypedValue.Value.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return GetDefaultAtt(GenericEnum);
        }

        public static string GetName<T>(this T GenericEnum)
        {
            return GettAtt(GenericEnum, "Name", "Description");
        }

      

        public static string GetCodigo<T>(this T GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {

                var atts = memberInfo[0].GetCustomAttributesData();
                if (atts != null && atts.Count > 0)
                {
                    foreach (var at in atts)
                        if (at.AttributeType.Name.Equals("CodigoAttribute"))
                        {
                            return at.ConstructorArguments[0].Value.ToString();
                        }
                }
            }
            return GetDefaultAtt(GenericEnum);
        }

        public static Dictionary<T, string> DisplayNames<T>() where T : struct
        {
            Dictionary<T, string> retVal = new();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                retVal.Add(item, item.GetDescription());
            }
            return retVal;
        }

        public static Array Getvalues<T>(this T value) where T : struct
        {
            return Enum.GetValues(typeof(T));
        }
        public static string DisplayName<T>(T value) where T : struct
        {
            return value.GetDescription();
        }

        public static string GetDescription<T>(this T GenericEnum)
        {
            return GettAtt(GenericEnum, "Description", "Name");
        }

        public static string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default;
        }
        public static string GetDescriptionFromCode<T>(string code)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {

                var atts = field.GetCustomAttributesData();
                if (atts != null && atts.Count > 0)
                {
                    foreach (var at in atts)
                        if (at.AttributeType.Name.Equals("CodigoAttribute"))
                        {
                            var codeAttribute = at.ConstructorArguments[0].Value.ToString();
                            if (codeAttribute == code)
                                return field.Name;
                        }
                }

            }
            return code;
        }

        public static string GetEnumDescription<TEnum>(int value)
        {
            return GetEnumDescription((Enum)(object)(TEnum)(object)value);  // ugly, but works
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
